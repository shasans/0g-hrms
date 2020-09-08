using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Models
{
    public class Jul19Payroll
    {
        [Key]
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Employee Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string Position { get; set; }

        [Display(Name = "Salary [AED]")]
        public int Salary { get; set; }
        [Display(Name = "A1")]
        public int Allowance1 { get; set; }
        [Display(Name = "A2")]
        public int Allowance2 { get; set; }
        [Display(Name = "A3")]
        public int Allowance3 { get; set; }
        public int Deduction { get; set; }

        [Display(Name = "Overtime Hours")]
        public int OvertimeHours { get; set; }

        public int Bonus { get; set; }
        [Display(Name = "Total [AED]")]
        public int Total { get; set; }

        public Employee Employee { get; set; }
        public string OwnerID { get; set; }
    }
}
