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

namespace Zero.Pages.PaymentInvoices
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
        public PaymentInvoice PaymentInvoice { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            PaymentInvoice = await Context.PaymentInvoice.AsNoTracking().Include(c => c.Client).Include(v => v.Vendor).FirstOrDefaultAsync(m => m.PaymentInvoiceID == id);

            if (PaymentInvoice == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, PaymentInvoice,
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
            PaymentInvoice = await Context.PaymentInvoice.AsNoTracking()
            .FirstOrDefaultAsync(m => m.PaymentInvoiceID == id);

            var paymentInvoice = await Context
                .PaymentInvoice.AsNoTracking()
                .FirstOrDefaultAsync(m => m.PaymentInvoiceID == id);

            if (paymentInvoice == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, paymentInvoice,
                                                     EmployeeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.PaymentInvoice.Remove(PaymentInvoice);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");


        }
    }
}
