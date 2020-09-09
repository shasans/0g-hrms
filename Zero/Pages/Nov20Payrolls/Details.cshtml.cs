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

namespace Zero.Pages.Nov20Payrolls
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

        public Nov20Payroll Nov20Payroll { get; set; }
        public int OvertimeAmount { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Nov20Payroll = await Context.Nov20Payroll.Include(j => j.Employee)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (Nov20Payroll == null)
            {
                return NotFound();
            }

            var isAuthorized = User.IsInRole(Constants.Nov20PayrollManagersRole) ||
                               User.IsInRole(Constants.Nov20PayrollAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized
                && currentUserId != Nov20Payroll.OwnerID)
            {
                return new ChallengeResult();
            }
            int CalcOvertime(int salary, int hours)
            {
                return ((salary / ((30 - 4) * 8)) * hours);
            }

            OvertimeAmount = CalcOvertime(Nov20Payroll.Employee.Salary, Nov20Payroll.OvertimeHours);
            return Page();


        }


    }
}
