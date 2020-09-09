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

namespace Zero.Pages.Employees
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
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            Employee = await Context.Employee.FirstOrDefaultAsync(
                                             m => m.ID == id);

            if (Employee == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, Employee,
                                                     EmployeeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();


            /* if (id == null)
             {
                 return NotFound();
             }

             Employee = await _context.Employee.FirstOrDefaultAsync(m => m.ID == id);

             if (Employee == null)
             {
                 return NotFound();
             }
             return Page();*/
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Employee = await Context.Employee.FindAsync(id);

            var employee = await Context
                .Employee.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (employee == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, employee,
                                                     EmployeeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.Employee.Remove(Employee);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");



            /* if (id == null)
             {
                 return NotFound();
             }

             Employee = await _context.Employee.FindAsync(id);

             if (Employee != null)
             {
                 _context.Employee.Remove(Employee);
                 await _context.SaveChangesAsync();
             }

             return RedirectToPage("./Index");*/
        }
    }
}
