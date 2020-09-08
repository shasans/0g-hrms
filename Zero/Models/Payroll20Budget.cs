using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Models
{
    public class Payroll20Budget
    {

        public int ID { get; set; }

        [Display(Name = "Budget Name")]
        public string Name { get; set; }

        [Display(Name = "Budget Amount [AED]")]
        public int Amount { get; set; }

        //   public int Amount2 { get; set; }

        [Display(Name = "Remaining Amount [AED]")]
        public int Remaining { get; set; }

        [Display(Name = "Date & Time")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime UploadDT { get; set; }

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
        public string OwnerID { get; set; }
    }
}
