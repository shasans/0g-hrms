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

namespace Zero.Pages.Apr20Payrolls
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
        public Apr20Payroll Apr20Payroll { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Apr20Payroll = await Context.Apr20Payroll.Include(j => j.Employee).FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (Apr20Payroll == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(Context.Employee, "ID", "FullName");
            // return Page();

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                  User, Apr20Payroll,
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
            var apr20payroll = await Context
                .Apr20Payroll.AsNoTracking()
                .FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (apr20payroll == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, apr20payroll,
                                                     EmployeeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Apr20Payroll.OwnerID = apr20payroll.OwnerID;

            Context.Attach(Apr20Payroll).State = EntityState.Modified;


            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool Apr20PayrollExists(int id)
        {
            return Context.Apr20Payroll.Any(e => e.EmployeeID == id);
        }
    }
}


