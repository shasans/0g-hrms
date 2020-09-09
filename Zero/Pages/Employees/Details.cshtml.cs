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
    public class DetailsModel : DI_BasePageModel
    {
        //private readonly Zero.Data.ApplicationDbContext _context;

        public DetailsModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Employee = await Context.Employee.FirstOrDefaultAsync(m => m.ID == id);

            if (Employee == null)
            {
                return NotFound();
            }

            var isAuthorized = User.IsInRole(Constants.EmployeeManagersRole) ||
                               User.IsInRole(Constants.EmployeeAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized
                && currentUserId != Employee.OwnerID)
               /* && Employee.Status != ContactStatus.Approved)*/
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


    }
}
