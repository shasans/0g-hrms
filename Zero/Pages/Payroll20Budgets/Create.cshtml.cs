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
using Zero.Pages.Employees;

namespace Zero.Pages.Payroll20Budgets
{
    public class CreateModel : DI_BasePageModel
    {


        public CreateModel(ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Payroll20Budget Payroll20Budget { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Payroll20Budget.OwnerID = UserManager.GetUserId(User);

            // requires using ContactManager.Authorization;
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, Payroll20Budget,
                                                        EmployeeOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }
            Payroll20Budget.UploadDT = DateTime.Now;

            Context.Payroll20Budget.Add(Payroll20Budget);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}