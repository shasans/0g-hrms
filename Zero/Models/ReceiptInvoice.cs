using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Models
{
    public class ReceiptInvoice
    {
        [Display(Name = "Invoice #")]
        public int ReceiptInvoiceID { get; set; }

        [Display(Name = "Issued From")]
        public string RecieverType { get; set; }

        [Display(Name = "Receiver Name")]
        public string RecieverName { get; set; }

        public int? ClientID { get; set; }

        public int? VendorID { get; set; }

        [Required]
        [Display(Name = "Amount [AED]")]
        public int Amount { get; set; }

        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }

        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }

        [Display(Name = "Receipt Upload")]
        public string ImageName { set; get; }

        [Display(Name = "Uploaded")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime UploadDT { get; set; }

        public Client Client { get; set; }

        public Vendor Vendor { get; set; }

        public string OwnerID { get; set; }

    }
}
