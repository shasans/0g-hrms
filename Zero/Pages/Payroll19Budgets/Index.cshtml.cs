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

namespace Zero.Pages.Payroll19Budgets
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

        public IList<Payroll19Budget> Payroll19Budget { get;set; }

        public int? Jan19Tot { get; set; } = 0;
        public int? Feb19Tot { get; set; } = 0;
        public int? Mar19Tot { get; set; } = 0;
        public int? Apr19Tot { get; set; } = 0;
        public int? May19Tot { get; set; } = 0;
        public int? Jun19Tot { get; set; } = 0;
        public int? Jul19Tot { get; set; } = 0;
        public int? Aug19Tot { get; set; } = 0;
        public int? Sep19Tot { get; set; } = 0;
        public int? Oct19Tot { get; set; } = 0;
        public int? Nov19Tot { get; set; } = 0;
        public int? Dec19Tot { get; set; } = 0;

        public string Msg { get; set; }

         public async Task<IActionResult> OnGetAsync()
         {
             Payroll19Budget = await Context.Payroll19Budget.ToListAsync();





             Jan19Tot = HttpContext.Session.GetInt32("jan19total");//get session here
             Feb19Tot = HttpContext.Session.GetInt32("feb19total");//get session here
             Mar19Tot = HttpContext.Session.GetInt32("mar19total");//get session here
             Apr19Tot = HttpContext.Session.GetInt32("apr19total");//get session here
             May19Tot = HttpContext.Session.GetInt32("may19total");//get session here
             Jun19Tot = HttpContext.Session.GetInt32("jun19total");//get session here
             Jul19Tot = HttpContext.Session.GetInt32("jul19total");//get session here
             Aug19Tot = HttpContext.Session.GetInt32("aug19total");//get session here
             Sep19Tot = HttpContext.Session.GetInt32("sep19total");//get session here
             Oct19Tot = HttpContext.Session.GetInt32("oct19total");//get session here
             Nov19Tot = HttpContext.Session.GetInt32("nov19total");//get session here
             Dec19Tot = HttpContext.Session.GetInt32("dec19total");//get session here

           /* if (command.Equals("submit1"))
            {
                Msg = "S1";
            }
            else
            {
                Msg = "S2";
            }
             */
            return Page();

         }

        

        /*  public void OnGet()
          {
          }

          public void OnPostWork1()
          {
              Msg = "Work 1";
          }

          public void OnPostWork2()
          {
              Msg = "Work 2";
          }

      */
    }
}
