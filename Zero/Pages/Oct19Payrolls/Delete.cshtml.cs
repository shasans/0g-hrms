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

namespace Zero.Pages.Oct19Payrolls
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
        public Oct19Payroll Oct19Payroll { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            Oct19Payroll = await Context.Oct19Payroll
                .Include(j => j.Employee).FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (Oct19Payroll == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, Oct19Payroll,
                                                     EmployeeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();


        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Oct19Payroll = await Context.Oct19Payroll.FindAsync(id);

            var oct19payroll = await Context
                .Oct19Payroll.AsNoTracking()
                .FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (oct19payroll == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, oct19payroll,
                                                     EmployeeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.Oct19Payroll.Remove(Oct19Payroll);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");


        }
    }
}
