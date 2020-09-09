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

namespace Zero.Pages.Employees
{
    public class IndexModel : DI_BasePageModel
    {
        //private readonly Zero.Data.ApplicationDbContext _context;

        public IndexModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public string CurrentFilter { get; set; }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            IQueryable<Employee> employeeIQ = from e in Context.Employee
                                              select e;

          //  var employees = from c in Context.Employee
          //                  select c;

            CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                employeeIQ = employeeIQ.Where(e => e.LastName.Contains(searchString)
                                       || e.FirstName.Contains(searchString));
            }

            var isAuthorized = User.IsInRole(Constants.EmployeeManagersRole) ||
                               User.IsInRole(Constants.EmployeeAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            // Only approved contacts are shown UNLESS you're authorized to see them
            // or you are the owner. 
            if (!isAuthorized)
            {
                employeeIQ = employeeIQ.Where(c => c.OwnerID == currentUserId);
            }

            Employee = await employeeIQ.AsNoTracking().ToListAsync();
           // Employee = await employees.ToListAsync();


        }
    }
}
