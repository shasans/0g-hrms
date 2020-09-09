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
    public class DetailsModel : PageModel
    {
        private readonly Zero.Data.ApplicationDbContext _context;

        public DetailsModel(Zero.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Vendor Vendor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vendor = await _context.Vendor.FirstOrDefaultAsync(m => m.ID == id);

            if (Vendor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
