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
using Zero.Pages.Employees;

namespace Zero.Pages.Oct19Payrolls
{
    public class DetailsModel : DI_BasePageModel
    {

        public DetailsModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public Oct19Payroll Oct19Payroll { get; set; }
        public int OvertimeAmount { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Oct19Payroll = await Context.Oct19Payroll.Include(j => j.Employee)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (Oct19Payroll == null)
            {
                return NotFound();
            }

            var isAuthorized = User.IsInRole(Constants.Oct19PayrollManagersRole) ||
                               User.IsInRole(Constants.Oct19PayrollAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized
                && currentUserId != Oct19Payroll.OwnerID)
            {
                return new ChallengeResult();
            }
            int CalcOvertime(int salary, int hours)
            {
                return ((salary / ((30 - 4) * 8)) * hours);
            }

            OvertimeAmount = CalcOvertime(Oct19Payroll.Employee.Salary, Oct19Payroll.OvertimeHours);
            return Page();


        }


    }
}
