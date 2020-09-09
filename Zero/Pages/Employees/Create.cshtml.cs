using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zero.Authorization;
using Zero.Data;
using Zero.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.WebSockets.Internal; 

namespace Zero.Pages.Employees
{
    public class CreateModel : DI_BasePageModel
    {
      //  private readonly Zero.Data.ApplicationDbContext _context;

        public CreateModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager) //(Zero.Data.ApplicationDbContext context)
        {
        }

        public IActionResult OnGet()
        {

          //  Employee = new Employee{FirstName="Suha", LastName="Siddiqui", Gender=Gender.Female, Nationality="Pakistan", DoB=DateTime.Parse("1998-04-10"), Grade=7, Position="Developer",MaritalStatus=MaritalStatus.Single, Salary=2000,Allowance1=1000, Allowance2=500,Allowance3=500, HiringDate=DateTime.Parse("2019-09-01") }
          //  ;
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            Employee.OwnerID = UserManager.GetUserId(User);

            // requires using ContactManager.Authorization;
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, Employee,
                                                        EmployeeOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }


            Context.Employee.Add(Employee);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}