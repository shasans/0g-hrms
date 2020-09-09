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

namespace Zero.Pages.Nov20Payrolls
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
        public Nov20Payroll Nov20Payroll { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            Nov20Payroll = await Context.Nov20Payroll
                .Include(j => j.Employee).FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (Nov20Payroll == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, Nov20Payroll,
                                                     EmployeeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();


        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Nov20Payroll = await Context.Nov20Payroll.FindAsync(id);

            var nov20payroll = await Context
                .Nov20Payroll.AsNoTracking()
                .FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (nov20payroll == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, nov20payroll,
                                                     EmployeeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.Nov20Payroll.Remove(Nov20Payroll);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");


        }
    }
}
