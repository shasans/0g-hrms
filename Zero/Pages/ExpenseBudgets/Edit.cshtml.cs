using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zero.Authorization;
using Zero.Data;
using Zero.Models;
using Zero.Pages.Employees;

namespace Zero.Pages.ExpenseBudgets
{
    public class EditModel : DI_BasePageModel
    {
        public EditModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public ExpenseBudget ExpenseBudget { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ExpenseBudget = await Context.ExpenseBudget.FirstOrDefaultAsync(
                                             m => m.ID == id);

            if (ExpenseBudget == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                  User, ExpenseBudget,
                                                  EmployeeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ///
            // Fetch Contact from DB to get OwnerID.
            var budget = await Context
                .ExpenseBudget.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (budget == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, budget,
                                                     EmployeeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            ExpenseBudget.OwnerID = budget.OwnerID;

            ExpenseBudget.UploadDT = DateTime.Now;

            Context.Attach(ExpenseBudget).State = EntityState.Modified;


            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool ExpenseBudgetExists(int id)
        {
            return Context.ExpenseBudget.Any(e => e.ID == id);
        }
    }
}
