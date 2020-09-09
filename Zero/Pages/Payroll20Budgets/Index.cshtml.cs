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

namespace Zero.Pages.Payroll20Budgets
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

        public IList<Payroll20Budget> Payroll20Budget { get;set; }


        public int? Jan20Tot { get; set; }
        public int? Feb20Tot { get; set; }
        public int? Mar20Tot { get; set; }
        public int? Apr20Tot { get; set; }
        public int? May20Tot { get; set; }
        public int? Jun20Tot { get; set; }
        public int? Jul20Tot { get; set; }
        public int? Aug20Tot { get; set; }
        public int? Sep20Tot { get; set; }
        public int? Oct20Tot { get; set; }
        public int? Nov20Tot { get; set; }
        public int? Dec20Tot { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Payroll20Budget = await Context.Payroll20Budget.ToListAsync();

            Jan20Tot = HttpContext.Session.GetInt32("jan20total");//get session here
            Feb20Tot = HttpContext.Session.GetInt32("feb20total");//get session here
            Mar20Tot = HttpContext.Session.GetInt32("mar20total");//get session here
            Apr20Tot = HttpContext.Session.GetInt32("apr20total");//get session here
            May20Tot = HttpContext.Session.GetInt32("may20total");//get session here
            Jun20Tot = HttpContext.Session.GetInt32("jun20total");//get session here
            Jul20Tot = HttpContext.Session.GetInt32("jul20total");//get session here
            Aug20Tot = HttpContext.Session.GetInt32("aug20total");//get session here
            Sep20Tot = HttpContext.Session.GetInt32("sep20total");//get session here
            Oct20Tot = HttpContext.Session.GetInt32("oct20total");//get session here
            Nov20Tot = HttpContext.Session.GetInt32("nov20total");//get session here
            Dec20Tot = HttpContext.Session.GetInt32("dec20total");//get session here

            return Page();
        }
    }
}
