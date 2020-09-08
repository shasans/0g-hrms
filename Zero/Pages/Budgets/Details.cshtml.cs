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

namespace Zero.Pages.Budgets
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

        public Budget Budget { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Budget = await Context.Budget.FirstOrDefaultAsync(m => m.ID == id);

            if (Budget == null)
            {
                return NotFound();
            }

            var isAuthorized = User.IsInRole(Constants.BudgetManagersRole) ||
                               User.IsInRole(Constants.BudgetAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized
                && currentUserId != Budget.OwnerID)
            {
                return new ChallengeResult();
            }

            return Page();

        }


    }
}
