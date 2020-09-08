using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Models
{
    public class Invoice
    {
        public int ID { get; set; } // (Invoice #)
        [DataType(DataType.Date)]
        [Display(Name = "Invoice Valid Until")]
        public DateTime Date { get; set; } // (Valid Till Date)
        public string Project { get; set; } // (Project Name)
        [Display(Name = "Receiver Name")]
        public string Name { get; set; } // (Client Name)
        public string Address { get; set; } // (Client Address)
        
        //  public IList<SelectListItem> Countries { get; set; } // Client Country selectlist
        public string City { get; set; } // (Client City)
        public string Country { get; set; } // (Client Country)

        //  public IList<InvoiceItem> Items { get; set; } // (Invoice items)

        //public ICollection<InvoiceItem> Items { get; set; }
        [Display(Name = "Item")]
        public string Item1 { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity1 { get; set; }
        [Display(Name = "Rate [AED]")]
        public double? Rate1 { get; set; }
        public double? Amount1
    {
        get { return this.Quantity1 * this.Rate1; }
    }

        public string Item2 { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity2 { get; set; }
        [Display(Name = "Rate [AED]")]
        public double? Rate2 { get; set; }
        public double? Amount2
        {
            get { return this.Quantity2 * this.Rate2; }
        }

        public string Item3 { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity3 { get; set; }
        [Display(Name = "Rate [AED]")]
        public double? Rate3 { get; set; }
        public double? Amount3
        {
            get { return this.Quantity3 * this.Rate3; }
        }

        public string Item4 { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity4 { get; set; }
        [Display(Name = "Rate [AED]")]
        public double? Rate4 { get; set; }
        public double? Amount4
        {
            get { return this.Quantity4 * this.Rate4; }
        }

        public string Item5 { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity5 { get; set; }
        [Display(Name = "Rate [AED]")]
        public double? Rate5 { get; set; }
        public double? Amount5
        {
            get { return this.Quantity5 * this.Rate5; }
        }

        public string Item6 { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity6 { get; set; }
        [Display(Name = "Rate [AED]")]
        public double? Rate6 { get; set; }
        public double? Amount6
        {
            get { return this.Quantity6 * this.Rate6; }
        }

        public string Item7 { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity7 { get; set; }
        [Display(Name = "Rate [AED]")]
        public double? Rate7 { get; set; }
        public double? Amount7
        {
            get { return this.Quantity7 * this.Rate7; }
        }


        public double? Subtotal
        {
            get { return this.Amount1+ this.Amount2+ this.Amount3+ this.Amount4+ this.Amount5+ this.Amount6+ this.Amount7; }
        }

        public double? Total
        {
            get { return this.Amount1 + this.Amount2 + this.Amount3 + this.Amount4 + this.Amount5 + this.Amount6 + this.Amount7; }
        }


        // public string Notes { get; set; }
        public string SelectedFormat { get; set; }

       // [Display(Name = "Contact person")]
       // public string ContactPerson { get; set; } // (Client Name)

        public static string FormatNumber(double value)
        {
            return value.ToString("F2", CultureInfo.InvariantCulture);
        }


     /*   public double GrandTotal
        {
            get { return this.Items.Select(i => i.Total).Sum(); }
        }

        public string GrandTotalText
        {
            get { return FormatNumber(this.GrandTotal); }
        } */
    }
}