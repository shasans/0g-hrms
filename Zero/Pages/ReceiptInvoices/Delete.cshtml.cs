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

namespace Zero.Pages.ReceiptInvoices
{
    public class DeleteModel : RecieverNamePageModelModel
    {

        public DeleteModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public ReceiptInvoice ReceiptInvoice { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            ReceiptInvoice = await Context.ReceiptInvoice.AsNoTracking().Include(c => c.Client).Include(v => v.Vendor).FirstOrDefaultAsync(m => m.ReceiptInvoiceID == id);

            if (ReceiptInvoice == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, ReceiptInvoice,
                                                     EmployeeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            // PaymentInvoice = await Context.PaymentInvoice.FindAsync(id);
            ReceiptInvoice = await Context.ReceiptInvoice.AsNoTracking()
            .FirstOrDefaultAsync(m => m.ReceiptInvoiceID == id);

            var receiptInvoice = await Context
                .ReceiptInvoice.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ReceiptInvoiceID == id);

            if (receiptInvoice == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, receiptInvoice,
                                                     EmployeeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.ReceiptInvoice.Remove(ReceiptInvoice);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");


        }
    }
}
