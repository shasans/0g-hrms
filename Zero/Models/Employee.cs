using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zero.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum MaritalStatus
    {
        Single,
        Married
    }

    public class Employee
    {

        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Required]
        public Gender? Gender { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DoB { get; set; }

        public int Grade { get; set; }


        public string Position { get; set; }

        [Display(Name = "Marital Status")]
        public MaritalStatus? MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Salary [AED]")]
        public int Salary { get; set; }

        [Display(Name = "Allowance 1")]
        public int Allowance1 { get; set; }

        [Display(Name = "Allowance 2")]
        public int Allowance2 { get; set; }

        [Display(Name = "Allowance 3")]
        public int Allowance3 { get; set; }

        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime HiringDate { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }



        public Jan19Payroll Jan19Payroll { get; set; }
        public Feb19Payroll Feb19Payroll { get; set; }
        public Mar19Payroll Mar19Payroll { get; set; }
        public Apr19Payroll Apr19Payroll { get; set; }
        public May19Payroll May19Payroll { get; set; }
        public Jun19Payroll Jun19Payroll { get; set; }
        public Jul19Payroll Jul19Payroll { get; set; }
        public Aug19Payroll Aug19Payroll { get; set; }
        public Sep19Payroll Sep19Payroll { get; set; }
        public Oct19Payroll Oct19Payroll { get; set; }
        public Nov19Payroll Nov19Payroll { get; set; }
        public Dec19Payroll Dec19Payroll { get; set; }

        public Jan20Payroll Jan20Payroll { get; set; }
        public Feb20Payroll Feb20Payroll { get; set; }
        public Mar20Payroll Mar20Payroll { get; set; }
        public Apr20Payroll Apr20Payroll { get; set; }
        public May20Payroll May20Payroll { get; set; }
        public Jun20Payroll Jun20Payroll { get; set; }
        public Jul20Payroll Jul20Payroll { get; set; }
        public Aug20Payroll Aug20Payroll { get; set; }
        public Sep20Payroll Sep20Payroll { get; set; }
        public Oct20Payroll Oct20Payroll { get; set; }
        public Nov20Payroll Nov20Payroll { get; set; }
        public Dec20Payroll Dec20Payroll { get; set; }



    }
}