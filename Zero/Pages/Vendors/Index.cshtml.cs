using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zero.Data;
using Zero.Models;

namespace Zero.Pages.Vendors
{
    public class IndexModel : PageModel
    {
        private readonly Zero.Data.ApplicationDbContext _context;

        public IndexModel(Zero.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Vendor> Vendor { get;set; }

        public async Task OnGetAsync()
        {
            Vendor = await _context.Vendor.ToListAsync();
        }
    }
}
