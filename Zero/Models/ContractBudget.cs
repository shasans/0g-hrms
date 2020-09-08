using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Models
{
    public class ContractBudget
    {

        public int ID { get; set; }

        [Display(Name = "Budget Name")]
        public string Name { get; set; }

        [Display(Name = "Budget Amount [AED]")]
        public int Amount { get; set; }

        [Display(Name = "Remaining Amount [AED]")]
        public int? Remaining { get; set; }

        [Display(Name = "Date & Time")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime UploadDT { get; set; }

        public ReceiptInvoice ReceiptInvoice { get; set; }
        public string OwnerID { get; set; }
    }
}
