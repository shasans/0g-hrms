using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zero.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zero.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Zero.Pages.ReceiptInvoices
{
    public class RecieverNamePageModelModel : PageModel
    {
        public SelectList RecieverNameSL { get; set; }
        public void PopulateRecieverDropDownList(ApplicationDbContext _context,
            object selectedReciever = null)
        {
            var recieversQuery = from r in _context.Client
                                 orderby r.Name // Sort by name.
                                 select r;

            RecieverNameSL = new SelectList(recieversQuery.AsNoTracking(),
                        "ID", "Name", selectedReciever);
        }

        public SelectList Reciever2NameSL { get; set; }
        public void PopulateReciever2DropDownList(ApplicationDbContext _context,
            object selected2Reciever = null)
        {
            var recievers2Query = from v in _context.Vendor
                                  orderby v.Name // Sort by name.
                                  select v;

            Reciever2NameSL = new SelectList(recievers2Query.AsNoTracking(),
                        "ID", "Name", selected2Reciever);
        }


        protected ApplicationDbContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<IdentityUser> UserManager { get; }

        public RecieverNamePageModelModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager) : base()
        {
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
        }



    }
}