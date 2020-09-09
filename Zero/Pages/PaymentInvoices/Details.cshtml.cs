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

namespace Zero.Pages.PaymentInvoices
{
    public class DetailsModel : RecieverNamePageModelModel
    {
        public DetailsModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public PaymentInvoice PaymentInvoice { get; set; }

        public int? MyTot { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            PaymentInvoice = await Context.PaymentInvoice.AsNoTracking().Include(c => c.Client).Include(v => v.Vendor).FirstOrDefaultAsync(m => m.PaymentInvoiceID == id);

            MyTot = HttpContext.Session.GetInt32("mytotal");//get session here

            if (PaymentInvoice == null)
            {
                return NotFound();
            }

            var isAuthorized = User.IsInRole(Constants.PaymentInvoiceManagersRole) ||
                               User.IsInRole(Constants.PaymentInvoiceAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized
                && currentUserId != PaymentInvoice.OwnerID)
            {
                return new ChallengeResult();
            }

            

            return Page();

        }


    }
}
