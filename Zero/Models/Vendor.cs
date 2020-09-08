using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Models
{
    public class Vendor
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        public string Address { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Country { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        public string IBAN { get; set; }

        [Display(Name = "Bank Country")]
        public string BankCountry { get; set; }

        public ICollection<PaymentInvoice> PaymentInvoices { get; set; }

        public ICollection<ReceiptInvoice> ReceiptInvoices { get; set; }

      //  public string OwnerID { get; set; }
    }
}
