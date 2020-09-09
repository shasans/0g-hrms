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

namespace Zero.Pages.ReceiptInvoices
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
        public ReceiptInvoice ReceiptInvoice { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ReceiptInvoice = await Context.ReceiptInvoice.Include(c => c.Client).Include(v => v.Vendor).FirstOrDefaultAsync(m => m.ReceiptInvoiceID == id);

            if (ReceiptInvoice == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(Context.Client, "ID", "ID");
            ViewData["VendorID"] = new SelectList(Context.Vendor, "ID", "ID");

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                  User, ReceiptInvoice,
                                                  EmployeeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            PopulateRecieverDropDownList(Context, ReceiptInvoice.ClientID);
            PopulateReciever2DropDownList(Context, ReceiptInvoice.VendorID);

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
            var receiptInvoice = await Context
                .ReceiptInvoice.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ReceiptInvoiceID == id);

            if (receiptInvoice == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, receiptInvoice,
                                                     EmployeeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            ReceiptInvoice.OwnerID = receiptInvoice.OwnerID;

            Context.Attach(ReceiptInvoice).State = EntityState.Modified;

            ///

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptInvoiceExists(ReceiptInvoice.ReceiptInvoiceID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");


            /* var receiptInvoiceToUpdate = await Context.ReceiptInvoice.FindAsync(id);

             if (await TryUpdateModelAsync<ReceiptInvoice>(
                  receiptInvoiceToUpdate,
                  "receiptinvoice",   // Prefix for form value.
                    s => s.ReceiptInvoiceID, s => s.RecieverType, s => s.ClientID, s => s.VendorID, s => s.BankAccount, s => s.Amount))
             {
                 await Context.SaveChangesAsync();
                 return RedirectToPage("./Index");
             }
             PopulateRecieverDropDownList(Context, receiptInvoiceToUpdate.ClientID);
             PopulateReciever2DropDownList(Context, receiptInvoiceToUpdate.VendorID);
             return Page();*/



            //await Context.SaveChangesAsync();

            //return RedirectToPage("./Index");
        }

        private bool ReceiptInvoiceExists(int id)
        {
            return Context.ReceiptInvoice.Any(e => e.ReceiptInvoiceID == id);
        }
    }
}


