using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zero.Models;

namespace Zero.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Zero.Models.Employee> Employee { get; set; }
        public DbSet<Zero.Models.Jan19Payroll> Jan19Payroll { get; set; }
        public DbSet<Zero.Models.Feb19Payroll> Feb19Payroll { get; set; }
        public DbSet<Zero.Models.Mar19Payroll> Mar19Payroll { get; set; }
        public DbSet<Zero.Models.Apr19Payroll> Apr19Payroll { get; set; }
        public DbSet<Zero.Models.May19Payroll> May19Payroll { get; set; }
        public DbSet<Zero.Models.Jun19Payroll> Jun19Payroll { get; set; }
        public DbSet<Zero.Models.Jul19Payroll> Jul19Payroll { get; set; }
        public DbSet<Zero.Models.Aug19Payroll> Aug19Payroll { get; set; }
        public DbSet<Zero.Models.Sep19Payroll> Sep19Payroll { get; set; }
        public DbSet<Zero.Models.Oct19Payroll> Oct19Payroll { get; set; }
        public DbSet<Zero.Models.Nov19Payroll> Nov19Payroll { get; set; }
        public DbSet<Zero.Models.Dec19Payroll> Dec19Payroll { get; set; }


        public DbSet<Zero.Models.Jan20Payroll> Jan20Payroll { get; set; }
        public DbSet<Zero.Models.Feb20Payroll> Feb20Payroll { get; set; }
        public DbSet<Zero.Models.Mar20Payroll> Mar20Payroll { get; set; }
        public DbSet<Zero.Models.Apr20Payroll> Apr20Payroll { get; set; }
        public DbSet<Zero.Models.May20Payroll> May20Payroll { get; set; }
        public DbSet<Zero.Models.Jun20Payroll> Jun20Payroll { get; set; }
        public DbSet<Zero.Models.Jul20Payroll> Jul20Payroll { get; set; }
        public DbSet<Zero.Models.Aug20Payroll> Aug20Payroll { get; set; }
        public DbSet<Zero.Models.Sep20Payroll> Sep20Payroll { get; set; }
        public DbSet<Zero.Models.Oct20Payroll> Oct20Payroll { get; set; }
        public DbSet<Zero.Models.Nov20Payroll> Nov20Payroll { get; set; }
        public DbSet<Zero.Models.Dec20Payroll> Dec20Payroll { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Jan19Payroll>().ToTable("Jan19Payroll");

            modelBuilder.Entity<Feb19Payroll>().ToTable("Feb19Payroll");
            modelBuilder.Entity<Mar19Payroll>().ToTable("Mar19Payroll");
            modelBuilder.Entity<Apr19Payroll>().ToTable("Apr19Payroll");
            modelBuilder.Entity<May19Payroll>().ToTable("May19Payroll");
            modelBuilder.Entity<Jun19Payroll>().ToTable("Jun19Payroll");
            modelBuilder.Entity<Jul19Payroll>().ToTable("Jul19Payroll");
            modelBuilder.Entity<Aug19Payroll>().ToTable("Aug19Payroll");
            modelBuilder.Entity<Sep19Payroll>().ToTable("Sep19Payroll");
            modelBuilder.Entity<Oct19Payroll>().ToTable("Oct19Payroll");
            modelBuilder.Entity<Nov19Payroll>().ToTable("Nov19Payroll");
            modelBuilder.Entity<Dec19Payroll>().ToTable("Dec19Payroll");


            modelBuilder.Entity<Jan20Payroll>().ToTable("Jan20Payroll");
            modelBuilder.Entity<Feb20Payroll>().ToTable("Feb20Payroll");
            modelBuilder.Entity<Mar20Payroll>().ToTable("Mar20Payroll");
            modelBuilder.Entity<Apr20Payroll>().ToTable("Apr20Payroll");
            modelBuilder.Entity<May20Payroll>().ToTable("May20Payroll");
            modelBuilder.Entity<Jun20Payroll>().ToTable("Jun20Payroll");
            modelBuilder.Entity<Jul20Payroll>().ToTable("Jul20Payroll");
            modelBuilder.Entity<Aug20Payroll>().ToTable("Aug20Payroll");
            modelBuilder.Entity<Sep20Payroll>().ToTable("Sep20Payroll");
            modelBuilder.Entity<Oct20Payroll>().ToTable("Oct20Payroll");
            modelBuilder.Entity<Nov20Payroll>().ToTable("Nov20Payroll");
            modelBuilder.Entity<Dec20Payroll>().ToTable("Dec20Payroll");

            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Vendor>().ToTable("Vendor");
            modelBuilder.Entity<PaymentInvoice>().ToTable("PaymentInvoice");
            modelBuilder.Entity<ReceiptInvoice>().ToTable("ReceiptInvoice");

            modelBuilder.Entity<Invoice>().ToTable("Invoice");
            modelBuilder.Entity<InvoiceItem>().ToTable("InvoiceItem");

            modelBuilder.Entity<Jan19Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Feb19Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Mar19Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Apr19Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<May19Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Jun19Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Jul19Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Aug19Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Sep19Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Oct19Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Nov19Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Dec19Payroll>()
                .HasKey(c => new { c.EmployeeID });


            modelBuilder.Entity<Jan20Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Feb20Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Mar20Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Apr20Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<May20Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Jun20Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Jul20Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Aug20Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Sep20Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Oct20Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Nov20Payroll>()
                .HasKey(c => new { c.EmployeeID });
            modelBuilder.Entity<Dec20Payroll>()
                .HasKey(c => new { c.EmployeeID });
        }

        public DbSet<Zero.Models.Client> Client { get; set; }

        public DbSet<Zero.Models.Vendor> Vendor { get; set; }

        public DbSet<Zero.Models.PaymentInvoice> PaymentInvoice { get; set; }

        public DbSet<Zero.Models.ReceiptInvoice> ReceiptInvoice { get; set; }

        public DbSet<Zero.Models.Budget> Budget { get; set; }

        public DbSet<Zero.Models.PaymentBudget> PaymentBudget { get; set; }

        public DbSet<Zero.Models.ReceivingBudget> ReceivingBudget { get; set; }

        public DbSet<Zero.Models.Payroll19Budget> Payroll19Budget { get; set; }

        public DbSet<Zero.Models.Payroll20Budget> Payroll20Budget { get; set; }

        public DbSet<Zero.Models.ExpenseBudget> ExpenseBudget { get; set; }

        public DbSet<Zero.Models.ContractBudget> ContractBudget { get; set; }

        public DbSet<Zero.Models.Invoice> Invoice { get; set; }

        public DbSet<Zero.Models.InvoiceItem> InvoiceItem { get; set; }


    }
}
