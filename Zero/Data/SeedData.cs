using Zero.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Zero.Authorization;

// dotnet aspnet-codegenerator razorpage -m Contact -dc ApplicationDbContext -udl -outDir Pages\Contacts --referenceScriptLibraries

namespace Zero.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // SeedDB(context, "0");
                var adminID2 = await EnsureUser(serviceProvider, testUserPw, "admin@0g.ae");
                await EnsureRole(serviceProvider, adminID2, Constants.EmployeeAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Jan19PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Feb19PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Mar19PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Apr19PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.May19PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Jun19PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Jul19PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Aug19PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Sep19PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Oct19PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Nov19PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Dec19PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Jan20PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Feb20PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Mar20PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Apr20PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.May20PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Jun20PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Jul20PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Aug20PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Sep20PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Oct20PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Nov20PayrollAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Dec20PayrollAdministratorsRole);

                await EnsureRole(serviceProvider, adminID2, Constants.PaymentInvoiceAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.ReceiptInvoiceAdministratorsRole);

                await EnsureRole(serviceProvider, adminID2, Constants.BudgetAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.ContractBudgetAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.ExpenseBudgetAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Payroll19BudgetAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.Payroll20BudgetAdministratorsRole);
                await EnsureRole(serviceProvider, adminID2, Constants.ReceivingBudgetAdministratorsRole);

                // allowed user can create and edit contacts that they create
                var managerID1 = await EnsureUser(serviceProvider, testUserPw, "moderator@0g.ae");
                await EnsureRole(serviceProvider, managerID1, Constants.EmployeeManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Jan19PayrollManagersRole);

                await EnsureRole(serviceProvider, managerID1, Constants.Feb19PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Mar19PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Apr19PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.May19PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Jun19PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Jul19PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Aug19PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Sep19PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Oct19PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Nov19PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Dec19PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Jan20PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Feb20PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Mar20PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Apr20PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.May20PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Jun20PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Jul20PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Aug20PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Sep20PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Oct20PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Nov20PayrollManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Dec20PayrollManagersRole);

                await EnsureRole(serviceProvider, managerID1, Constants.PaymentInvoiceManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.ReceiptInvoiceManagersRole);

                await EnsureRole(serviceProvider, managerID1, Constants.BudgetManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.ContractBudgetManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.ExpenseBudgetManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Payroll19BudgetManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.Payroll20BudgetManagersRole);
                await EnsureRole(serviceProvider, managerID1, Constants.ReceivingBudgetManagersRole);


                SeedDB(context, adminID2);

            }
        }

        public static void SeedDB(ApplicationDbContext context, string adminID2)
        {
            context.Database.EnsureCreated();

            if (context.Employee.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
            new Employee{FirstName="Suha", LastName="Hasan", Gender=Gender.Female, Nationality="Pakistan", DoB=DateTime.Parse("1998-04-10"), Grade=7, Position="Developer",MaritalStatus=MaritalStatus.Single, Salary=2000,Allowance1=400, Allowance2=0,Allowance3=0, HiringDate=DateTime.Parse("2019-09-01"),OwnerID=adminID2 }
            };
            foreach (Employee e in employees)
            {
                context.Employee.Add(e);
            }
            context.SaveChanges();

            var clients = new Client[]
            {
            new Client{Project="SABRA.AE", Name="Islam Al Khalifa", Address="i.khalifa@mins.ae", Mobile="+971503374373", Company="Sabra Tourism & Travel LLC", Country="United Arab Emirates"}
            
            };
            foreach (Client cl in clients)
            {
                context.Client.Add(cl);
            }
            context.SaveChanges();

            var vendors = new Vendor[]
            {
            new Vendor{Name="Planet01", Address="hassan@planet01.net", Mobile="+92-2136942939, +92-3452201069", Company="Planet 01", Country="Pakistan", BankName="Faysal Bank", IBAN ="0119007000006436", BankCountry="Pakistan"}
            };
            foreach (Vendor ve in vendors)
            {
                context.Vendor.Add(ve);
            }
            context.SaveChanges();

            var invoiceitems = new InvoiceItem[]
            {
            new InvoiceItem{Date = "Hosting Unlimited Storage, Unlimited Emails Accounts", Hours = 1, Price = 1000.0},
            new InvoiceItem{Date = "Web Security Shield and SSL Certificate", Hours = 1, Price = 1050.0},
            new InvoiceItem{Date = "Website Transfer and 30 Emails Setup Fees", Hours = 1, Price = 1200.0},
            new InvoiceItem{Date = "Free Domain Name", Hours = 1, Price = 0.0}
            };
            foreach (InvoiceItem ii in invoiceitems)
            {
                context.InvoiceItem.Add(ii);
            }
            context.SaveChanges();

            /* var jan19payrolls = new Jan19Payroll[]
             {
             new Jan19Payroll{EmployeeID=employees.Single( e => e.LastName == "Hasan").ID, Deduction=0, OvertimeHours=0, Bonus=0, OwnerID=adminID2}
             };
             foreach (Jan19Payroll j in jan19payrolls)
             {
                 context.Jan19Payroll.Add(j);
             }
             context.SaveChanges(); */

            var jan19payrolls = new Jan19Payroll[]
            {
            new Jan19Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Jan19Payroll j in jan19payrolls)
            {
                context.Jan19Payroll.Add(j);
            }
            context.SaveChanges();

            var jan20payrolls = new Jan20Payroll[]
            {
            new Jan20Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Jan20Payroll jj in jan20payrolls)
            {
                context.Jan20Payroll.Add(jj);
            }
            context.SaveChanges();

            var feb19payrolls = new Feb19Payroll[]
            {
            new Feb19Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Feb19Payroll f in feb19payrolls)
            {
                context.Feb19Payroll.Add(f);
            }
            context.SaveChanges();

            var feb20payrolls = new Feb20Payroll[]
            {
            new Feb20Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Feb20Payroll ff in feb20payrolls)
            {
                context.Feb20Payroll.Add(ff);
            }
            context.SaveChanges();

            var mar19payrolls = new Mar19Payroll[]
            {
            new Mar19Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Mar19Payroll m in mar19payrolls)
            {
                context.Mar19Payroll.Add(m);
            }
            context.SaveChanges();

            var mar20payrolls = new Mar20Payroll[]
            {
            new Mar20Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Mar20Payroll mm in mar20payrolls)
            {
                context.Mar20Payroll.Add(mm);
            }
            context.SaveChanges();

            var apr19payrolls = new Apr19Payroll[]
            {
            new Apr19Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Apr19Payroll a in apr19payrolls)
            {
                context.Apr19Payroll.Add(a);
            }
            context.SaveChanges();

            var apr20payrolls = new Apr20Payroll[]
            {
            new Apr20Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Apr20Payroll aa in apr20payrolls)
            {
                context.Apr20Payroll.Add(aa);
            }
            context.SaveChanges();

            var may19payrolls = new May19Payroll[]
            {
            new May19Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (May19Payroll y in may19payrolls)
            {
                context.May19Payroll.Add(y);
            }
            context.SaveChanges();

            var may20payrolls = new May20Payroll[]
            {
            new May20Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (May20Payroll yy in may20payrolls)
            {
                context.May20Payroll.Add(yy);
            }
            context.SaveChanges();

            var jun19payrolls = new Jun19Payroll[]
            {
            new Jun19Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Jun19Payroll u in jun19payrolls)
            {
                context.Jun19Payroll.Add(u);
            }
            context.SaveChanges();

            var jun20payrolls = new Jun20Payroll[]
            {
            new Jun20Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Jun20Payroll uu in jun20payrolls)
            {
                context.Jun20Payroll.Add(uu);
            }
            context.SaveChanges();

            var jul19payrolls = new Jul19Payroll[]
            {
            new Jul19Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Jul19Payroll l in jul19payrolls)
            {
                context.Jul19Payroll.Add(l);
            }
            context.SaveChanges();

            var jul20payrolls = new Jul20Payroll[]
            {
            new Jul20Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Jul20Payroll ll in jul20payrolls)
            {
                context.Jul20Payroll.Add(ll);
            }
            context.SaveChanges();

            var aug19payrolls = new Aug19Payroll[]
            {
            new Aug19Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Aug19Payroll g in aug19payrolls)
            {
                context.Aug19Payroll.Add(g);
            }
            context.SaveChanges();

            var aug20payrolls = new Aug20Payroll[]
            {
            new Aug20Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Aug20Payroll gg in aug20payrolls)
            {
                context.Aug20Payroll.Add(gg);
            }
            context.SaveChanges();

            var sep19payrolls = new Sep19Payroll[]
            {
            new Sep19Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Sep19Payroll p in sep19payrolls)
            {
                context.Sep19Payroll.Add(p);
            }
            context.SaveChanges();

            var sep20payrolls = new Sep20Payroll[]
            {
            new Sep20Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Sep20Payroll pp in sep20payrolls)
            {
                context.Sep20Payroll.Add(pp);
            }
            context.SaveChanges();

            var oct19payrolls = new Oct19Payroll[]
            {
            new Oct19Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Oct19Payroll o in oct19payrolls)
            {
                context.Oct19Payroll.Add(o);
            }
            context.SaveChanges();

            var oct20payrolls = new Oct20Payroll[]
            {
            new Oct20Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Oct20Payroll oo in oct20payrolls)
            {
                context.Oct20Payroll.Add(oo);
            }
            context.SaveChanges();

            var nov19payrolls = new Nov19Payroll[]
            {
            new Nov19Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Nov19Payroll n in nov19payrolls)
            {
                context.Nov19Payroll.Add(n);
            }
            context.SaveChanges();

            var nov20payrolls = new Nov20Payroll[]
            {
            new Nov20Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Nov20Payroll nn in nov20payrolls)
            {
                context.Nov20Payroll.Add(nn);
            }
            context.SaveChanges();

            var dec19payrolls = new Dec19Payroll[]
            {
            new Dec19Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Dec19Payroll d in dec19payrolls)
            {
                context.Dec19Payroll.Add(d);
            }
            context.SaveChanges();

            var dec20payrolls = new Dec20Payroll[]
            {
            new Dec20Payroll{Total=0, OwnerID=adminID2}
            };
            foreach (Dec20Payroll dd in dec20payrolls)
            {
                context.Dec20Payroll.Add(dd);
            }
            context.SaveChanges();

            var receiptinvoices = new ReceiptInvoice[]
            {
            new ReceiptInvoice{ PaymentType="Expense", Amount=0},
            new ReceiptInvoice{ PaymentType="Contract", Amount=0}
            };
            foreach (ReceiptInvoice rr in receiptinvoices)
            {
                context.ReceiptInvoice.Add(rr);
            }
            context.SaveChanges();

            var paymentinvoices = new PaymentInvoice[]
            {
            new PaymentInvoice{Amount=0}
            };
            foreach (PaymentInvoice rr in paymentinvoices)
            {
                context.PaymentInvoice.Add(rr);
            }
            context.SaveChanges();


            /* var paymentinvoices = new PaymentInvoice[]
             {
             new PaymentInvoice{RecieverType= "Client", ClientID = 1, BankAccount="123", Amount=2000, ImageName="completion certificate_6036.pdf", OwnerID=adminID2}
             };
             foreach (PaymentInvoice v in paymentinvoices)
             {
                 context.PaymentInvoice.Add(v);
             }
             context.SaveChanges();*/


        }


        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                            string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser { UserName = UserName };
                await userManager.CreateAsync(user, testUserPw);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }



    }
}