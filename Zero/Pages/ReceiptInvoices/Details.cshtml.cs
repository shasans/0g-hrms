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

namespace Zero.Pages.ReceiptInvoices
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

        public ReceiptInvoice ReceiptInvoice { get; set; }
        public int? Totally { get; set; }
        public int? Totally2 { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            ReceiptInvoice = await Context.ReceiptInvoice.AsNoTracking().Include(c => c.Client).Include(v => v.Vendor).FirstOrDefaultAsync(m => m.ReceiptInvoiceID == id);

            if (ReceiptInvoice == null)
            {
                return NotFound();
            }

            var isAuthorized = User.IsInRole(Constants.ReceiptInvoiceManagersRole) ||
                               User.IsInRole(Constants.ReceiptInvoiceAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized
                && currentUserId != ReceiptInvoice.OwnerID)
            {
                return new ChallengeResult();
            }

            Totally = HttpContext.Session.GetInt32("exp");
            Totally2 = HttpContext.Session.GetInt32("con");

            return Page();

        }


    }
}
