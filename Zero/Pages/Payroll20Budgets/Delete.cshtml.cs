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

namespace Zero.Pages.Payroll20Budgets
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
        public Payroll20Budget Payroll20Budget { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            Payroll20Budget = await Context.Payroll20Budget.FirstOrDefaultAsync(m => m.ID == id);

            if (Payroll20Budget == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, Payroll20Budget,
                                                     EmployeeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            Payroll20Budget = await Context.Payroll20Budget.FindAsync(id);

            var budget = await Context
                .Payroll20Budget.AsNoTracking()
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

            Context.Payroll20Budget.Remove(Payroll20Budget);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
