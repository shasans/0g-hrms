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

namespace Zero.Pages.ExpenseBudgets
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
        public ExpenseBudget ExpenseBudget { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ExpenseBudget.OwnerID = UserManager.GetUserId(User);

            // requires using ContactManager.Authorization;
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, ExpenseBudget,
                                                        EmployeeOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            ExpenseBudget.UploadDT = DateTime.Now;

            Context.ExpenseBudget.Add(ExpenseBudget);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}