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

namespace Zero.Pages.PaymentInvoices
{
    public class IndexModel : RecieverNamePageModelModel
    {
        //private readonly Zero.Data.ApplicationDbContext _context;

        public IndexModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }


        public IList<PaymentInvoice> PaymentInvoice { get; set; }

        public async Task OnGetAsync()
        {

            var paymentInvoices = from c in Context.PaymentInvoice.Include(c => c.Client)
                .Include(v => v.Vendor)
                .AsNoTracking()
                      select c;

          /*   foreach (var item in PaymentInvoice)
              {
                 if (item.Amount == null)
                {
                    item.Amount = 0;
                }
              }
            //set session*/
            
            /*    var isAuthorized = User.IsInRole(Jan19PayrollConstants.Jan19PayrollManagersRole) ||
                                  User.IsInRole(Jan19PayrollConstants.Jan19PayrollAdministratorsRole);

                var currentUserId = UserManager.GetUserId(User); */

            // if(isAuthorized)
            PaymentInvoice = await paymentInvoices.ToListAsync();


            var data = PaymentInvoice.Sum(i => i.Amount);
            HttpContext.Session.SetInt32("mytotal", data);
            
        }

       /* public void OnPostWork1()
        {
            var data = PaymentInvoice.Sum(i => i.Amount);
            HttpContext.Session.SetInt32("mytotal", data);
        } */


    }
}
