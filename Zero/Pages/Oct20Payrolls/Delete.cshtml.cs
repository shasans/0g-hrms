using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zero.Data;
using Zero.Models;

namespace Zero.Pages.Oct20Payrolls
{
    public class DeleteModel : PageModel
    {
        private readonly Zero.Data.ApplicationDbContext _context;

        public DeleteModel(Zero.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Oct20Payroll Oct20Payroll { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Oct20Payroll = await _context.Oct20Payroll
                .Include(o => o.Employee).FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (Oct20Payroll == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Oct20Payroll = await _context.Oct20Payroll.FindAsync(id);

            if (Oct20Payroll != null)
            {
                _context.Oct20Payroll.Remove(Oct20Payroll);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
