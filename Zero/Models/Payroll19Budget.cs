using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Zero.Models
{
    public class Payroll19Budget
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
        public string OwnerID { get; set; }
    }
}
