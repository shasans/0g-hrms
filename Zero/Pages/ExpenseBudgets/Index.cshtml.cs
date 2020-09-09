using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zero.Authorization;
using Zero.Data;
using Zero.Models;
using Zero.Pages.Employees;

namespace Zero.Pages.ExpenseBudgets
{
    public class IndexModel : DI_BasePageModel
    {

        public IndexModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IList<ExpenseBudget> ExpenseBudget { get;set; }

        public int? ExpTotal { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            ExpenseBudget = await Context.ExpenseBudget.ToListAsync();

            ExpTotal = HttpContext.Session.GetInt32("exp");

            return Page();
        }
    }
}
