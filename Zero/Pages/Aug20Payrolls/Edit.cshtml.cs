﻿using System;
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
using Zero.Pages.Employees;

namespace Zero.Pages.Aug20Payrolls
{
    public class EditModel : DI_BasePageModel
    {
        //  private readonly Zero.Data.ApplicationDbContext _context;

        public EditModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Aug20Payroll Aug20Payroll { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Aug20Payroll = await Context.Aug20Payroll.Include(j => j.Employee).FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (Aug20Payroll == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(Context.Employee, "ID", "FullName");
            // return Page();

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                  User, Aug20Payroll,
                                                  EmployeeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

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
            var aug20payroll = await Context
                .Aug20Payroll.AsNoTracking()
                .FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (aug20payroll == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, aug20payroll,
                                                     EmployeeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Aug20Payroll.OwnerID = aug20payroll.OwnerID;

            Context.Attach(Aug20Payroll).State = EntityState.Modified;


            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool Aug20PayrollExists(int id)
        {
            return Context.Aug20Payroll.Any(e => e.EmployeeID == id);
        }
    }
}


