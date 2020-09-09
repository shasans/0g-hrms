using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zero.Authorization;
using Zero.Data;
using Zero.Models;
using Zero.Pages.Employees;

namespace Zero.Pages.ExpenseBudgets
{
    public class DeleteModel : DI_BasePageModel
    {
        //  private readonly Zero.Data.ApplicationDbContext _context;

        public DeleteModel(
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

            ExpenseBudget = await Context.ExpenseBudget.FirstOrDefaultAsync(m => m.ID == id);

            if (ExpenseBudget == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, ExpenseBudget,
                                                     EmployeeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            ExpenseBudget = await Context.ExpenseBudget.FindAsync(id);

            var budget = await Context
                .ExpenseBudget.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (budget == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, budget,
                                                     EmployeeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.ExpenseBudget.Remove(ExpenseBudget);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
