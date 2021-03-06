﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zero.Authorization;
using Zero.Data;
using Zero.Models;
using Zero.Pages.Employees;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.FileProviders;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Zero.Pages.Jan20Payrolls
{
    public class IndexModel : DI_BasePageModel
    {
        private IHostingEnvironment _hostingEnvironment;
        public IndexModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager, IHostingEnvironment hostingEnvironment)
        : base(context, authorizationService, userManager)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        public IList<Jan20Payroll> Jan20Payroll { get; set; }

        public async Task OnGetAsync()
        {
            var jan20payrolls = from c in Context.Jan20Payroll.Include(j => j.Employee)
              .AsNoTracking()
                                select c;

            Jan20Payroll = await jan20payrolls.ToListAsync();

            foreach (var item in Jan20Payroll)
            {
                item.Total = CalculateTotal(item.Employee.Salary, item.Employee.Allowance1, item.Employee.Allowance2, item.Employee.Allowance3, item.Deduction, CalcOvertime((item.Employee.Salary), (item.OvertimeHours)), item.Bonus);
            }
            var data = Jan20Payroll.Sum(i => i.Total);
            HttpContext.Session.SetInt32("jan20total", data);//set session here
        }
        int CalcOvertime(int salary, int hours)
        {
            return ((salary / ((31 - 5) * 8)) * hours);
        }
        int CalculateTotal(int salary, int a1, int a2, int a3, int deduction, int overtime, int bonus)
        {
            return (salary + a1 + a2 + a3 - deduction + overtime + bonus);
        }

        public async Task<IActionResult> OnPostExporttoExcel()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string fileName = @"Jan20Payroll.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, fileName);
            FileInfo file = new FileInfo(Path.Combine(webRootPath, fileName));
            var memoryStream = new MemoryStream();
            // --- Below code would create excel file with dummy data----  
            using (var fs = new FileStream(Path.Combine(webRootPath, fileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Jan20Payroll");

                IRow row = excelSheet.CreateRow(0);
                row.CreateCell(0).SetCellValue("EmployeeID");
                row.CreateCell(1).SetCellValue("FullName");
                row.CreateCell(2).SetCellValue("Salary");
                row.CreateCell(3).SetCellValue("Allowance1");
                row.CreateCell(4).SetCellValue("Allowance2");
                row.CreateCell(5).SetCellValue("Allowance3");
                row.CreateCell(6).SetCellValue("Deduction");
                row.CreateCell(7).SetCellValue("OvertimeHours");
                row.CreateCell(8).SetCellValue("Bonus");
                row.CreateCell(9).SetCellValue("Total");


                var jan20payrolls = from s in Context.Jan20Payroll.Include(j => j.Employee)
                .AsNoTracking()
                                    select s;
                int counter = 1;
                foreach (var jan20payroll in jan20payrolls)
                {
                    row = excelSheet.CreateRow(counter);
                    row.CreateCell(0).SetCellValue(jan20payroll.Employee.ID);
                    row.CreateCell(1).SetCellValue(jan20payroll.Employee.FullName);
                    row.CreateCell(2).SetCellValue(jan20payroll.Employee.Salary);
                    row.CreateCell(3).SetCellValue(jan20payroll.Employee.Allowance1);
                    row.CreateCell(4).SetCellValue(jan20payroll.Employee.Allowance2);
                    row.CreateCell(5).SetCellValue(jan20payroll.Employee.Allowance3);
                    row.CreateCell(6).SetCellValue(jan20payroll.Deduction);
                    row.CreateCell(7).SetCellValue(jan20payroll.OvertimeHours);
                    row.CreateCell(8).SetCellValue(jan20payroll.Bonus);
                    row.CreateCell(9).SetCellValue(CalculateTotal(jan20payroll.Employee.Salary, jan20payroll.Employee.Allowance1, jan20payroll.Employee.Allowance2, jan20payroll.Employee.Allowance3, jan20payroll.Deduction, CalcOvertime((jan20payroll.Employee.Salary), (jan20payroll.OvertimeHours)), jan20payroll.Bonus));
                    counter++;
                }
                workbook.Write(fs);
            }
            using (var fileStream = new FileStream(Path.Combine(webRootPath, fileName), FileMode.Open))
            {
                await fileStream.CopyToAsync(memoryStream);
            }
            memoryStream.Position = 0;
            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

    }
    
}
