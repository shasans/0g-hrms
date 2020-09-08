using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Models
{
    public class PaymentBudget
    {

        public int ID { get; set; }

        [Display(Name = "Budget Name")]
        public string Name { get; set; }
        [Display(Name = "Amount [AED]")]
        public decimal Amount { get; set; }

        [Display(Name = "Remaining Amount [AED]")]
        public decimal Remaining { get; set; }

        [Display(Name = "Date & Time")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime UploadDT { get; set; }

        /* public decimal PayrollBudget { get; set; }

         public decimal ExpensesBudget { get; set; }

         public decimal ContractBudget { get; set; }

         public decimal ReceivingBudget { get; set; }*/

        public Jan19Payroll Jan19Payroll { get; set; }
    }
}
