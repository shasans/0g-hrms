using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Models
{
    public class ReceivingBudget
    {
        public int ID { get; set; }

        [Display(Name = "Budget Name")]
        public string Name { get; set; }

        [Display(Name = "Starting Amount [AED]")]
        public int Amount { get; set; }

     //   public int Amount2 { get; set; }

        [Display(Name = "Accumulated Amount [AED]")]
        public int? Remaining { get; set;}

        [Display(Name = "Date & Time")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime UploadDT { get; set; }

        public Employee Employee { get; set; }

        //one budget has many payment invoices
        // public ICollection<PaymentInvoice> PaymentInvoices { get; set; }

        public PaymentInvoice PaymentInvoice { get; set; }

        public string OwnerID { get; set; }
    }
}
