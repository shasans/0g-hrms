using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Models
{
    public class Client
    {
        public int ID { get; set; }


        public string Project { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        public string Address { get; set; }

        [Required]
        public string Mobile { get; set; }

        public string Company { get; set; }

        public string Country { get; set; }

        //one client can have many invoices
        public ICollection<PaymentInvoice> PaymentInvoices { get; set; }
        public ICollection<ReceiptInvoice> ReceiptInvoices { get; set; }

       // public string OwnerID { get; set; }

    }
}
