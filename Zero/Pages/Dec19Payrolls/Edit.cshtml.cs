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

namespace Zero.Pages.Dec19Payrolls
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
        public Dec19Payroll Dec19Payroll { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Dec19Payroll = await Context.Dec19Payroll.Include(j => j.Employee).FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (Dec19Payroll == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(Context.Employee, "ID", "FullName");
            // return Page();

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                  User, Dec19Payroll,
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
            var dec19payroll = await Context
                .Dec19Payroll.AsNoTracking()
                .FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (dec19payroll == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, dec19payroll,
                                                     EmployeeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Dec19Payroll.OwnerID = dec19payroll.OwnerID;

            Context.Attach(Dec19Payroll).State = EntityState.Modified;


            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool Dec19PayrollExists(int id)
        {
            return Context.Dec19Payroll.Any(e => e.EmployeeID == id);
        }
    }
}


