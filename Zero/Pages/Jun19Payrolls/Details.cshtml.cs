﻿using System;
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

namespace Zero.Pages.Jun19Payrolls
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

        public Jun19Payroll Jun19Payroll { get; set; }
        public int OvertimeAmount { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Jun19Payroll = await Context.Jun19Payroll.Include(j => j.Employee)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (Jun19Payroll == null)
            {
                return NotFound();
            }

            var isAuthorized = User.IsInRole(Constants.Jun19PayrollManagersRole) ||
                               User.IsInRole(Constants.Jun19PayrollAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized
                && currentUserId != Jun19Payroll.OwnerID)
            {
                return new ChallengeResult();
            }
            int CalcOvertime(int salary, int hours)
            {
                return ((salary / ((30 - 4) * 8)) * hours);
            }

            OvertimeAmount = CalcOvertime(Jun19Payroll.Employee.Salary, Jun19Payroll.OvertimeHours);
            return Page();


        }


    }
}
