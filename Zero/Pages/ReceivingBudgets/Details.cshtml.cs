using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zero.Data;
using Zero.Models;

namespace Zero.Pages.ReceivingBudgets
{
    public class DetailsModel : PageModel
    {
        private readonly Zero.Data.ApplicationDbContext _context;

        public DetailsModel(Zero.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ReceivingBudget ReceivingBudget { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReceivingBudget = await _context.ReceivingBudget.FirstOrDefaultAsync(m => m.ID == id);

            if (ReceivingBudget == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
