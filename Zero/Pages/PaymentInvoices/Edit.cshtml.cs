using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zero.Authorization;
using Zero.Data;
using Zero.Models;

namespace Zero.Pages.PaymentInvoices
{
    public class EditModel : RecieverNamePageModelModel
    {
        public EditModel(
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
            PaymentInvoice = await Context.PaymentInvoice.Include(c => c.Client).Include(v => v.Vendor).FirstOrDefaultAsync(m => m.PaymentInvoiceID == id);

            if (PaymentInvoice == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                  User, PaymentInvoice,
                                                  EmployeeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            PopulateRecieverDropDownList(Context, PaymentInvoice.ClientID);
            PopulateReciever2DropDownList(Context, PaymentInvoice.VendorID);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ///
            // Fetch Contact from DB to get OwnerID.
            var paymentInvoice = await Context
                .PaymentInvoice.AsNoTracking()
                .FirstOrDefaultAsync(m => m.PaymentInvoiceID == id);

            if (paymentInvoice == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, paymentInvoice,
                                                     EmployeeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            PaymentInvoice.OwnerID = paymentInvoice.OwnerID;

            Context.Attach(PaymentInvoice).State = EntityState.Modified;

            ///

            var paymentinvoiceToUpdate = await Context.PaymentInvoice.FindAsync(id);

            if (await TryUpdateModelAsync<PaymentInvoice>(
                 paymentinvoiceToUpdate,
                 "paymentinvoice",   // Prefix for form value.
                   s => s.PaymentInvoiceID, s => s.RecieverType, s => s.ClientID, s => s.VendorID, s => s.BankAccount, s => s.Amount))
            {
                await Context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateRecieverDropDownList(Context, paymentinvoiceToUpdate.ClientID);
            PopulateReciever2DropDownList(Context, paymentinvoiceToUpdate.VendorID);
            return Page();


            //await Context.SaveChangesAsync();

            //return RedirectToPage("./Index");
        }

        private bool PaymentInvoiceExists(int id)
        {
            return Context.PaymentInvoice.Any(e => e.PaymentInvoiceID == id);
        }
    }
}


