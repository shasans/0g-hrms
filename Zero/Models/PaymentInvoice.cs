using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zero.Models
{
    public class PaymentInvoice
    {
        [Display(Name = "Invoice #")]
        public int PaymentInvoiceID { get; set; }

        //   public string Reciever { get; set; }

        //  [BindProperty]
        [Display(Name = "Received From")]
        public string RecieverType { get; set; }

        //   [BindProperty]
        //  public bool RecieverTypeClient { get; set; }

        // public string[] RecieverTypes = new[] { "Client", "Vendor"};

        //  public bool IsClient { get; set; }

        [Display(Name = "Name")]
        public string RecieverName { get; set; }

        public int? ClientID { get; set; }

        public int? VendorID { get; set; }

        [Display(Name = "Bank Account")]
        public string BankAccount { get; set; }

        [Required]
        [Display(Name = "Amount [AED]")]
        public int Amount { get; set; }

        //   [BindProperty]
        //    public IFormFile image { get; set; }
        // [BindProperty]
        [Display(Name = "Invoice Upload")]
        public string ImageName { set; get; }

        [Display(Name = "Uploaded")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime UploadDT { get; set; }

        //one payment invoice is for one client
        public Client Client { get; set; }

        public Vendor Vendor { get; set; }

        public string OwnerID { get; set; }


        //public ICollection<ReceivingBudget> ReceivingBudgets { get; set; }


    }
}
