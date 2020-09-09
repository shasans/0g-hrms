using System;
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

namespace Zero.Pages.Jan19Payrolls
{
    public class IndexModel : DI_BasePageModel
    {
        //private readonly Zero.Data.ApplicationDbContext _context;

        private IHostingEnvironment _hostingEnvironment;
        public IndexModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager, IHostingEnvironment hostingEnvironment)
        : base(context, authorizationService, userManager)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        public IList<Jan19Payroll> Jan19Payroll { get; set; }

        public async Task OnGetAsync()
        {
            //Employee = await _context.Employee.ToListAsync();

              var jan19payrolls = from c in Context.Jan19Payroll.Include(j => j.Employee)
                .AsNoTracking()
                                  select c;


        /*    var isAuthorized = User.IsInRole(Jan19PayrollConstants.Jan19PayrollManagersRole) ||
                              User.IsInRole(Jan19PayrollConstants.Jan19PayrollAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User); */

           // if(isAuthorized)
            Jan19Payroll = await jan19payrolls.ToListAsync();

            foreach (var item in Jan19Payroll)
            {
                item.Total = CalculateTotal(item.Employee.Salary, item.Employee.Allowance1, item.Employee.Allowance2, item.Employee.Allowance3, item.Deduction, CalcOvertime((item.Employee.Salary), (item.OvertimeHours)), item.Bonus);
            }
            var data1 = Jan19Payroll.Sum(i => i.Total);
            HttpContext.Session.SetInt32("jan19total", data1);//set session here
        }
        int CalcOvertime(int salary, int hours)
        {
            return ((salary / ((31 - 4) * 8)) * hours);
        }
        int CalculateTotal(int salary, int a1, int a2, int a3, int deduction, int overtime, int bonus)
        {
            return (salary + a1 + a2 + a3 - deduction + overtime + bonus);
        }

        // private string fileName { get; set; }

        //   public IActionResult OnPostCreateDocument()
        //{

        // var fileMemoryStream = await GenerateReportAndWriteToMemoryStream(...);

        /*    var path = Path.Combine(
                     Directory.GetCurrentDirectory(),
                     "wwwroot", filename);
/////////////
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(
                memory,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "report.xlsx"); */
        //

        /*   ExcelExport exp = new ExcelExport();
           var DataSource = _context.Orders.Take(100).ToList();
           GridProperties gridProp = ConvertGridObject(GridModel);
           GridExcelExport excelExp = new GridExcelExport();
           excelExp.FileName = "Export.xlsx"; excelExp.Excelversion = ExcelVersion.Excel2010;
           excelExp.Theme = "flat-saffron";
           return exp.Export(gridProp, DataSource, excelExp); */

        //////
        ///

        /*     string filePath = hostingEnvironment.WebRootPath;
             IFileProvider provider = new PhysicalFileProvider(filePath);
             IFileInfo fileInfo = provider.GetFileInfo(fileName);
             var fileMemoryStream = fileInfo.CreateReadStream();
             return File(
                 fileMemoryStream,
                 "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                 "report.xlsx");


         }*/

        /*  public IActionResult OnPostCreateDocument()
          {
              var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
             // string wwwrootPath = hostingEnvironment.WebRootPath;
              fileName = @"report.xlsx";
              FileInfo file = new FileInfo(Path.Combine(wwwrootPath, fileName));
              return downloadFile(wwwrootPath);
          }
          public FileResult downloadFile(string filePath)
          {
              IFileProvider provider = new PhysicalFileProvider(filePath);
              IFileInfo fileInfo = provider.GetFileInfo(fileName);
              var readStream = fileInfo.CreateReadStream();
              var mimeType = "application/vnd.ms-excel";
              return File(readStream, mimeType, fileName);
          }*/


        public async Task<IActionResult> OnPostExporttoExcel()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string fileName = @"Jan19Payroll.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, fileName);
            FileInfo file = new FileInfo(Path.Combine(webRootPath, fileName));
            var memoryStream = new MemoryStream();
            // --- Below code would create excel file with dummy data----  
            using (var fs = new FileStream(Path.Combine(webRootPath, fileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Jan19Payroll");

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


                var jan19payrolls = from s in Context.Jan19Payroll.Include(j => j.Employee)
                .AsNoTracking()
                          select s;
                int counter = 1;
                foreach (var jan19payroll in jan19payrolls)
                {
                    row = excelSheet.CreateRow(counter);
                    row.CreateCell(0).SetCellValue(jan19payroll.Employee.ID);
                    row.CreateCell(1).SetCellValue(jan19payroll.Employee.FullName);
                    row.CreateCell(2).SetCellValue(jan19payroll.Employee.Salary);
                    row.CreateCell(3).SetCellValue(jan19payroll.Employee.Allowance1);
                    row.CreateCell(4).SetCellValue(jan19payroll.Employee.Allowance2);
                    row.CreateCell(5).SetCellValue(jan19payroll.Employee.Allowance3);
                    row.CreateCell(6).SetCellValue(jan19payroll.Deduction);
                    row.CreateCell(7).SetCellValue(jan19payroll.OvertimeHours);
                    row.CreateCell(8).SetCellValue(jan19payroll.Bonus);
                    row.CreateCell(9).SetCellValue(CalculateTotal(jan19payroll.Employee.Salary, jan19payroll.Employee.Allowance1, jan19payroll.Employee.Allowance2, jan19payroll.Employee.Allowance3, jan19payroll.Deduction, CalcOvertime((jan19payroll.Employee.Salary), (jan19payroll.OvertimeHours)), jan19payroll.Bonus));
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

    
    

