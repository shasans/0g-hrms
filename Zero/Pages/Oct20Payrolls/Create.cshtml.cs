﻿using System;
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

namespace Zero.Pages.Oct20Payrolls
{
    public class CreateModel : DI_BasePageModel
    {

        public CreateModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            ViewData["EmployeeID"] = new SelectList(Context.Employee, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Oct20Payroll Oct20Payroll { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            Oct20Payroll.OwnerID = UserManager.GetUserId(User);

            // requires using ContactManager.Authorization;
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, Oct20Payroll,
                                                        EmployeeOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }


            Context.Oct20Payroll.Add(Oct20Payroll);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}