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

namespace Zero.Pages.Dec20Payrolls
{
    public class EditModel : DI_BasePageModel
    {
        //  private readonly Zero.Data.ApplicationDbContext _context;

        public EditModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Dec20Payroll Dec20Payroll { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Dec20Payroll = await Context.Dec20Payroll.Include(j => j.Employee).FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (Dec20Payroll == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(Context.Employee, "ID", "FullName");
            // return Page();

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                  User, Dec20Payroll,
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
            var dec20payroll = await Context
                .Dec20Payroll.AsNoTracking()
                .FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (dec20payroll == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, dec20payroll,
                                                     EmployeeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Dec20Payroll.OwnerID = dec20payroll.OwnerID;

            Context.Attach(Dec20Payroll).State = EntityState.Modified;


            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool Dec20PayrollExists(int id)
        {
            return Context.Dec20Payroll.Any(e => e.EmployeeID == id);
        }
    }
}


