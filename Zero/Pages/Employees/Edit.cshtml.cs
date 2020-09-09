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

namespace Zero.Pages.Employees
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
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Employee = await Context.Employee.FirstOrDefaultAsync(
                                             m => m.ID == id);

            if (Employee == null)
            {
                return NotFound();
            }

            /*Employee = await _context.Employee.FirstOrDefaultAsync(m => m.ID == id);

            if (Employee == null)
            {
                return NotFound();
            }*/
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                  User, Employee,
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
            var employee = await Context
                .Employee.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (employee == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, employee,
                                                     EmployeeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Employee.OwnerID = employee.OwnerID;

            Context.Attach(Employee).State = EntityState.Modified;

            /* if (contact.Status == EmployeeStatus.Approved)
             {
                 // If the contact is updated after approval, 
                 // and the user cannot approve,
                 // set the status back to submitted so the update can be
                 // checked and approved.
                 var canApprove = await AuthorizationService.AuthorizeAsync(User,
                                         contact,
                                         ContactOperations.Approve);

                 if (!canApprove.Succeeded)
                 {
                     contact.Status = ContactStatus.Submitted;
                 }
             }*/

            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            return Context.Employee.Any(e => e.ID == id);
        }
    }
}


         /*   _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.ID == id);
        }
    }
}

    */
      