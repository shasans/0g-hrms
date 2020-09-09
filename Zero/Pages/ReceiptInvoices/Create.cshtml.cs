using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zero.Authorization;
using Zero.Data;
using Zero.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Zero.Pages.ReceiptInvoices
{
    public class CreateModel : RecieverNamePageModelModel
    {

        private readonly IHostingEnvironment hostingEnvironment;

        public CreateModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            PopulateRecieverDropDownList(Context);
            PopulateReciever2DropDownList(Context);

            return Page();
        }

        [BindProperty]
        public ReceiptInvoice ReceiptInvoice { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ReceiptInvoice.UploadDT = DateTime.Now;



            ReceiptInvoice.OwnerID = UserManager.GetUserId(User);

            // requires using ContactManager.Authorization;
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, ReceiptInvoice,
                                                        EmployeeOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }


            var emptyReceiptInvoice = new ReceiptInvoice();

            if (await TryUpdateModelAsync<ReceiptInvoice>(
                 emptyReceiptInvoice,
                 "receiptinvoice",   // Prefix for form value.
                 s => s.ReceiptInvoiceID, s => s.RecieverType, s => s.ClientID, s => s.VendorID, s => s.Amount, s => s.PaymentType, s => s.ImageName))
            {

                if (Image != null)
                {
                    var fileName = GetUniqueName(Image.FileName);
                    ReceiptInvoice.ImageName = fileName;
                    var uploaded = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    var filePath = Path.Combine(uploaded, fileName);
                    var memory = new MemoryStream();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);

                    }
                }
                Context.ReceiptInvoice.Add(ReceiptInvoice);
                await Context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateRecieverDropDownList(Context, emptyReceiptInvoice.ClientID);
            PopulateReciever2DropDownList(Context, emptyReceiptInvoice.VendorID);
            return Page();

        }
    }
}