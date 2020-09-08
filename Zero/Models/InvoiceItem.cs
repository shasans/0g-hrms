using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Models
{
    public class InvoiceItem
    {
        public string InvoiceItemID { get; set; }
        public string Date { get; set; } // (Item Name)
        public int Hours { get; set; } // Hours (Quantity)
        public double Price { get; set; } // (Rate)

        public string PriceText // (Rate text)
        {
            get { return Invoice.FormatNumber(this.Price); }
            set { this.Price = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result) ? result : 0.0; }
        }

        public double Total // (Amount)
        {
            get { return this.Hours * this.Price; }
        }

        public string TotalText // (Amount text) (wow i wish i had this 3 months ago hahaah)
        {
            get { return Invoice.FormatNumber(this.Hours * this.Price); }
        }

        public Invoice Invoice { get; set; }
    }
}