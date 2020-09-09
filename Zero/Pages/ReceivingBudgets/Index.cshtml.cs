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

namespace Zero.Pages.ReceivingBudgets
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

        public IList<ReceivingBudget> ReceivingBudget { get;set; }

        /*public async Task OnGetAsync()
        {
            ReceivingBudget = await _context.ReceivingBudget.ToListAsync();
        }*/

        public int? MyTota { get; set; }
        
        public async Task<IActionResult> OnGetAsync()
        {
            ReceivingBudget = await Context.ReceivingBudget.ToListAsync();

            MyTota = HttpContext.Session.GetInt32("mytotal");//get session here
            
            return Page();
        }


    }
}
