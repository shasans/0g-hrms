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

namespace Zero.Pages.ReceiptInvoices
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


        public IList<ReceiptInvoice> ReceiptInvoice { get; set; }

        public async Task OnGetAsync()
        {

            var receiptInvoices = from c in Context.ReceiptInvoice.Include(c => c.Client)
                .Include(v => v.Vendor)
                .AsNoTracking()
                                  select c;


            /*    var isAuthorized = User.IsInRole(Jan19PayrollConstants.Jan19PayrollManagersRole) ||
                                  User.IsInRole(Jan19PayrollConstants.Jan19PayrollAdministratorsRole);

                var currentUserId = UserManager.GetUserId(User); */

            // if(isAuthorized)
            ReceiptInvoice = await receiptInvoices.ToListAsync();


            /*    foreach (var item in ReceiptInvoice)
                {
                    if (item.PaymentType == "Contract")
                    {

                    }


                */

            /* if (item.PaymentType == "Contract")

                 var data1 = ReceiptInvoice.Sum(i => i.Amount);

             else if (item.PaymentType == "Expense")*/

            var expensestotal = ReceiptInvoice.Where(s => s.PaymentType == "Expense").Select(s => s);
            var data111 = expensestotal.Sum(i => i.Amount);
            HttpContext.Session.SetInt32("exp", data111);

            var contractsstotal = ReceiptInvoice.Where(p => p.PaymentType == "Contract").Select(p => p);
            var data222 = contractsstotal.Sum(a => a.Amount);
            HttpContext.Session.SetInt32("con", data222);
        }

         //   var daya = ReceiptInvoice.Where(foreach (var item in ReceiptInvoice)item.PaymentType== "Contract").Sum(i => i.Amount);

         //   var data = Payroll.Sum(i => i.Total).ToString("0,0.00");
          //  HttpContext.Session.SetString("total", data);//set session here


        //}
    }

}
