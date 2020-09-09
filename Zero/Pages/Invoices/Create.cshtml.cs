using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zero.Data;
using Zero.Models;

using Microsoft.AspNetCore.Hosting;

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Authorization;
// using GemBox.Document;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;
using Spire.Pdf.AutomaticFields;
using Spire.Pdf.Tables;
using Spire.Pdf.Grid;

namespace Zero.Pages.Invoices
{
    public class CreateModel : PageModel
    {
        private readonly Zero.Data.ApplicationDbContext _context;

        private IHostingEnvironment _hostingEnvironment;

        public CreateModel(Zero.Data.ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

      /*  private static SaveOptions GetSaveOptions(string format)
        {
            switch (format.ToUpperInvariant())
            {
                case "DOCX":
                    return SaveOptions.DocxDefault;
                //   case "PDF":
                //       return SaveOptions.PdfDefault;
                default:
                    throw new NotSupportedException("Format '" + format + "' is not supported.");
            }
        }


        private static byte[] GetBytes(DocumentModel document, SaveOptions options)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream, options);
                return stream.ToArray();
            }
        }




        private DocumentModel Process(Invoice model)
        //include the for var sth in something
        //CONTEXT
        {
            string path = Path.Combine(this._hostingEnvironment.ContentRootPath, "MyInvoiceTemp22.docx");

            // Load template document
            DocumentModel document = DocumentModel.Load(path);


            // Fill invoice data
            /* document.MailMerge.Execute(
                 new
                 {
                     //      Number = model.ID, // there ARE 0 id's right now
                     // InvoiceDate = model.Date.ToShortDateString() // make this todays date
                     Number = Invoice.ID,
                     InvoiceDate = DateTime.Now.ToLongDateString(), //DateTime.Now.ToShortDateString(),
                     //Country = Invoice.Country

                 }) ;


             // it is getting added in the database, just need to read the values from the database and insert them into the document and we done bois 


             // Fill customer data
             document.MailMerge.Execute(
                 new Dictionary<string, object>()
                 {
                     { "ContactPerson" , Invoice.ContactPerson },
                     { "Name", Invoice.Name }
                 });

                
             document.MailMerge.Execute(
                new Dictionary<string, object>()
                {
                     { "Address" , Invoice.Address },
                     { "Country" , Invoice.Country },
                     { "Rate" , Invoice.Address },
                     { "Amount" , Invoice.Address },
                     { "Amount" , Invoice.Amount },
                     { "Amount" , Invoice.Amount }

                });

            var data = new
            {
                Number = Invoice.ID,
                InvoiceDate = DateTime.Now.ToString("MMM dd, yyyy"),
                Date = Invoice.Date.ToString("MMM dd, yyyy"),
                Name = Invoice.Name,
                Project = Invoice.Project,
                Item1 = Invoice.Item1,
                Quantity1 = Invoice.Quantity1,
                Rate1 = Invoice.Rate1,
                Amount1 = Invoice.Amount1

            };

            // Execute mail merge process.
            document.MailMerge.Execute(data);


            return document;
        } */



        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Invoice Invoice { get; set; }





        static PdfPageTemplateElement CreateHeaderTemplate(PdfDocument doc, PdfMargins margins)
        {
            //get page size
            SizeF pageSize = doc.PageSettings.Size;

            //create a PdfPageTemplateElement object as header space
            PdfPageTemplateElement headerSpace = new PdfPageTemplateElement(pageSize.Width, 170);
            headerSpace.Foreground = false;

            //declare two float variables
            float x = margins.Left;
            float y = 0;

            //draw image in header space 
            PdfImage headerImage = PdfImage.FromFile("1.png");
            float width = headerImage.Width / 2;
            float height = headerImage.Height / 2;
            headerSpace.Graphics.DrawImage(headerImage, x, margins.Top - height + 130, width, height);

            /*  //draw line in header space
              PdfPen pen = new PdfPen(PdfBrushes.Gray, 1);
              headerSpace.Graphics.DrawLine(pen, x, y + margins.Top - 2, pageSize.Width - x, y + margins.Top - 2);

              //draw text in header space
              PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Impact", 25f, FontStyle.Bold));
              PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
              String headerText = "HEADER TEXT";
              SizeF size = font.MeasureString(headerText, format);
              headerSpace.Graphics.DrawString(headerText, font, PdfBrushes.Gray, pageSize.Width - x - size.Width - 2, margins.Top - (size.Height + 5), format);
              */

            PdfImage headerImage2 = PdfImage.FromFile("2.png");
            float width2 = headerImage.Width / 2;
            float height2 = headerImage.Height / 5;
            headerSpace.Graphics.DrawImage(headerImage2, x + 230, margins.Top - height2 + 50, width2, height2);


            PdfImage headerImage3 = PdfImage.FromFile("3.png");
            float width3 = headerImage.Width / 4;
            float height3 = headerImage.Height / 5;
            headerSpace.Graphics.DrawImage(headerImage3, x + 510, margins.Top - height3 + 50, width3, height3);

            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 28.5f, FontStyle.Bold));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
            String headerText = "Invoice";
            SizeF size = font.MeasureString(headerText, format);
            headerSpace.Graphics.DrawString(headerText, font, PdfBrushes.Black, pageSize.Width - x - size.Width - 40, margins.Top - (size.Height - 130), format);


            //return headerSpace
            return headerSpace;
        }


        static PdfPageTemplateElement CreateFooterTemplate(PdfDocument doc, PdfMargins margins)
        {
            //get page size
            SizeF pageSize = doc.PageSettings.Size;

            //create a PdfPageTemplateElement object which works as footer space
            PdfPageTemplateElement footerSpace = new PdfPageTemplateElement(pageSize.Width, 250);
            footerSpace.Foreground = false;

            //declare two float variables
            float x = margins.Left;
            float y = 0;


            PdfImage footerImage6 = PdfImage.FromFile("6.png");
            float width6 = footerImage6.Width / 2;
            float height6 = footerImage6.Height / 2;
            footerSpace.Graphics.DrawImage(footerImage6, x, 130, width6, height6);

            PdfImage footerImage7 = PdfImage.FromFile("7.png");
            float width7 = footerImage7.Width / 2;
            float height7 = footerImage7.Height / 2;
            footerSpace.Graphics.DrawImage(footerImage7, x+450, 100, width7, height7);

            PdfImage footerImage4 = PdfImage.FromFile("4.png");
            float width4 = footerImage4.Width / 3;
            float height4 = footerImage4.Height / 3;
            footerSpace.Graphics.DrawImage(footerImage4, x+100, -5, width4, height4);

            PdfImage footerImage5 = PdfImage.FromFile("5.png");
            float width5 = footerImage5.Width / 3;
            float height5 = footerImage5.Height / 3;
            footerSpace.Graphics.DrawImage(footerImage5, x+150, 10, width5, height5);


            /* //draw line in footer space
             PdfPen pen = new PdfPen(PdfBrushes.Gray, 1);
             footerSpace.Graphics.DrawLine(pen, x, y, pageSize.Width - x, y);

             //draw text in footer space
             y = y + 5;
             PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Impact", 10f), true);
             PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
             String footerText = "E-iceblue Technology Co., Ltd.\nTel:028-81705109\nWebsite:http://www.e-iceblue.com";
             footerSpace.Graphics.DrawString(footerText, font, PdfBrushes.Gray, x, y, format); 

             //draw dynamic field in footer space
             PdfPageNumberField number = new PdfPageNumberField();
             PdfPageCountField count = new PdfPageCountField();
             PdfCompositeField compositeField = new PdfCompositeField(font, PdfBrushes.Gray, "Page {0} of {1}", number, count);
             compositeField.StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Top);
             SizeF size = font.MeasureString(compositeField.Text);
             compositeField.Bounds = new RectangleF(pageSize.Width - x, y, size.Width, size.Height);
             compositeField.Draw(footerSpace.Graphics); */

            //return footerSpace
            return footerSpace;
        }





        public async Task<IActionResult> OnPostAsync(Invoice model)
        //public IActionResult OnPost(Invoice model)
        {
            // ComponentInfo.SetLicense("FREE-LICENSE-KEY");

             if (!ModelState.IsValid)
             {
                 return Page();
             }

             _context.Invoice.Add(Invoice);
             await _context.SaveChangesAsync();

           /*  SaveOptions options = GetSaveOptions(model.SelectedFormat);
             DocumentModel document = this.Process(model);


             return File(GetBytes(document, options), options.ContentType, "Invoice." + model.SelectedFormat.ToLowerInvariant());
             // return RedirectToPage("./Index"); */




           // string webRootPath = _hostingEnvironment.WebRootPath;
            string fileName = @"Invoice.pdf";
        //    string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, fileName);
        //    FileInfo file = new FileInfo(Path.Combine(fileName));
            var memoryStream = new MemoryStream();


            //create a PDF document
            PdfDocument doc = new PdfDocument();
            doc.PageSettings.Size = PdfPageSize.A4;

            //reset the default margins to 0
            doc.PageSettings.Margins = new PdfMargins(0);

            //create a PdfMargins object, the parameters indicate the page margins you want to set
            PdfMargins margins = new PdfMargins(0, 40, 0, 40);

            //create a header template with content and apply it to page template
            doc.Template.Top = CreateHeaderTemplate(doc, margins);
            doc.Template.Bottom = CreateFooterTemplate(doc, margins);

            //apply blank templates to other parts of page template
            //  doc.Template.Bottom = new PdfPageTemplateElement(doc.PageSettings.Size.Width, margins.Bottom);
            doc.Template.Left = new PdfPageTemplateElement(margins.Left, doc.PageSettings.Size.Height);
            doc.Template.Right = new PdfPageTemplateElement(margins.Right, doc.PageSettings.Size.Height);


            PdfPageBase page = doc.Pages.Add();
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 18f, FontStyle.Bold));
            PdfSolidBrush brush = new PdfSolidBrush(Color.Gray);
            page.Canvas.DrawString(String.Format("#{0}",Invoice.ID), font, brush, new PointF(520, 0));


            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold));
            PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold));
            PdfSolidBrush brush2 = new PdfSolidBrush(Color.Black);
            PdfSolidBrush brush3 = new PdfSolidBrush(Color.White);

            page.Canvas.DrawString("Date:\nValid Until: ", font2, brush, new PointF(420, 25));

            page.Canvas.DrawString(String.Format("{0}\n{1}", DateTime.Now.ToString("MMM dd, yyyy"), Invoice.Date.ToString("MMM dd, yyyy")), font2, brush2, new PointF(490, 25));

            page.Canvas.DrawString("Bill To:", font3, brush, new PointF(70, 55));
            page.Canvas.DrawString(String.Format("{0}\n{1}\n{2}, {3}",Invoice.Name,Invoice.Project,Invoice.City,Invoice.Country), font3, brush2, new PointF(70, 70));



        /*    String[] data
         = {
     "Item;Quantity;Rate;Amount",
     String.Format("{0};{1};{2};{3}",Invoice.Item1,Invoice.Quantity1,Invoice.Rate1,Invoice.Amount1)
         };
            String[][] dataSource
                = new String[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                dataSource[i] = data[i].Split(';');
            }

            PdfTable table = new PdfTable();
            table.Style.CellPadding = 3;
            table.Style.BorderPen = new PdfPen(brush3, 0.75f);
            table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            table.Style.HeaderSource = PdfHeaderSource.Rows;
            table.Style.HeaderRowCount = 1;
            table.Style.ShowHeader = true;
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.Black;
            table.DataSource = dataSource;
            foreach (PdfColumn column in table.Columns)
            {
                column.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            }
            table.Draw(page, new PointF(100, 135));
             */






            PdfGrid grid = new PdfGrid();
            grid.Columns.Add(5);
            float width = page.Canvas.ClientSize.Width - (grid.Columns.Count + 1);
            for (int j = 0; j < grid.Columns.Count; j++)
            {
               grid.Columns[j].Width = width * 0.20f;
            }

             PdfGridRow row0 = grid.Rows.Add();
             PdfGridRow row1 = grid.Rows.Add();
            PdfGridRow row2 = grid.Rows.Add();
            PdfGridRow row3 = grid.Rows.Add();
            PdfGridRow row4 = grid.Rows.Add();
            PdfGridRow row5 = grid.Rows.Add();
            PdfGridRow row6 = grid.Rows.Add();
            PdfGridRow row7 = grid.Rows.Add();
            float height = 20.0f;
             for (int i = 0; i < grid.Rows.Count; i++)
             {
               grid.Rows[i].Height = height;
              }


             //SET CAP ~56 LETTERS


            row0.Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold), true);
            row0.Style.TextBrush = new PdfSolidBrush(Color.White);
            row1.Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold), true);
            

            row0.Cells[0].Value = "\tItem";
            row0.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            row0.Cells[0].Style.BackgroundBrush = PdfBrushes.Black;
            // row0.Cells[0].RowSpan = 2;
            row0.Cells[0].ColumnSpan = 2;
            //  row0.Cells[0].Style.BackgroundBrush = PdfBrushes.Black;

            row1.Cells[0].Value = String.Format(" {0}", Invoice.Item1);
            row1.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            row1.Cells[0].ColumnSpan = 2;

            row2.Cells[0].Value = String.Format(" {0}", Invoice.Item2);
            row2.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            row2.Cells[0].ColumnSpan = 2;
            row3.Cells[0].Value = String.Format(" {0}", Invoice.Item3);
            row3.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            row3.Cells[0].ColumnSpan = 2;
            row4.Cells[0].Value = String.Format(" {0}", Invoice.Item4);
            row4.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            row4.Cells[0].ColumnSpan = 2;
            row5.Cells[0].Value = String.Format(" {0}", Invoice.Item5);
            row5.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            row5.Cells[0].ColumnSpan = 2;
            row6.Cells[0].Value = String.Format(" {0}", Invoice.Item6);
            row6.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            row6.Cells[0].ColumnSpan = 2;
            row7.Cells[0].Value = String.Format(" {0}", Invoice.Item7);
            row7.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            row7.Cells[0].ColumnSpan = 2;


            row0.Cells[2].Value = "Quantity";
            row0.Cells[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row0.Cells[2].Style.BackgroundBrush = PdfBrushes.Black;

            row1.Cells[2].Value = String.Format("{0}", Invoice.Quantity1);
            row1.Cells[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row2.Cells[2].Value = String.Format("{0}", Invoice.Quantity2);
            row2.Cells[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row3.Cells[2].Value = String.Format("{0}", Invoice.Quantity3);
            row3.Cells[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row4.Cells[2].Value = String.Format("{0}", Invoice.Quantity4);
            row4.Cells[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row5.Cells[2].Value = String.Format("{0}", Invoice.Quantity5);
            row5.Cells[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row6.Cells[2].Value = String.Format("{0}", Invoice.Quantity6);
            row6.Cells[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row7.Cells[2].Value = String.Format("{0}", Invoice.Quantity7);
            row7.Cells[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            row0.Cells[3].Value = "Rate [AED]";
            row0.Cells[3].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row0.Cells[3].Style.BackgroundBrush = PdfBrushes.Black;
            //   row0.Cells[1].ColumnSpan = 3;

            row1.Cells[3].Value = String.Format("{0}", Invoice.Rate1);
            row1.Cells[3].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row2.Cells[3].Value = String.Format("{0}", Invoice.Rate2);
            row2.Cells[3].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row3.Cells[3].Value = String.Format("{0}", Invoice.Rate3);
            row3.Cells[3].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row4.Cells[3].Value = String.Format("{0}", Invoice.Rate4);
            row4.Cells[3].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row5.Cells[3].Value = String.Format("{0}", Invoice.Rate5);
            row5.Cells[3].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row6.Cells[3].Value = String.Format("{0}", Invoice.Rate6);
            row6.Cells[3].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row7.Cells[3].Value = String.Format("{0}", Invoice.Rate7);
            row7.Cells[3].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            row0.Cells[4].Value = "Amount [AED]";
         //   row0.Cells[4].Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold | FontStyle.Italic), true);
            row0.Cells[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row0.Cells[4].Style.BackgroundBrush = PdfBrushes.Black;

            row1.Cells[4].Value = String.Format("{0}", Invoice.Amount1);
            row1.Cells[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row2.Cells[4].Value = String.Format("{0}", Invoice.Amount2);
            row2.Cells[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row3.Cells[4].Value = String.Format("{0}", Invoice.Amount3);
            row3.Cells[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row4.Cells[4].Value = String.Format("{0}", Invoice.Amount4);
            row4.Cells[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row5.Cells[4].Value = String.Format("{0}", Invoice.Amount5);
            row5.Cells[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row6.Cells[4].Value = String.Format("{0}", Invoice.Amount6);
            row6.Cells[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row7.Cells[4].Value = String.Format("{0}", Invoice.Amount7);
            row7.Cells[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);


            // row1.Cells[1].Value = "Amount [AED]";
            // row1.Cells[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            // row1.Cells[1].ColumnSpan = 4;


            PdfBorders border = new PdfBorders();
            border.All = new PdfPen(Color.Transparent);

            foreach (PdfGridRow pgr in grid.Rows)
            {
                foreach (PdfGridCell pgc in pgr.Cells)
                {
                    pgc.Style.Borders = border;
                }
            }

            grid.Draw(page, new PointF(2, 135)); 

            
         /*   row0.Cells[0].Value = "Item";
            row0.Cells[0].ColumnSpan = 2;


            row0.Cells[2].Value = "Quantity";
       //     row0.Cells[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            

            row0.Cells[3].Value = "Rate [AED]";
        //    row0.Cells[4].Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold | FontStyle.Italic), true);
        //    row0.Cells[3].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
        //    row0.Cells[3].Style.BackgroundBrush = PdfBrushes.LightGreen;


            row0.Cells[4].Value = "Amount [AED]";
            //  row1.Cells[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            //  row1.Cells[4].ColumnSpan = 4;

            row1.Cells[0].Value = "This is an Item yo";
            row1.Cells[0].ColumnSpan = 2; */


            //save the file
            doc.SaveToFile("Invoice.pdf");

/*
            PdfDocument destDoc = new PdfDocument();
            float top = 20;
            float bottom = 20;
            float left = 20;
            float right = 20;

            foreach (PdfPageBase page in doc.Pages)
                    {
                    PdfPageBase newPage = destDoc.Pages.Add(page.Size, new PdfMargins(0));
                    newPage.Canvas.ScaleTransform((page.ActualSize.Width - left - right) / page.ActualSize.Width,
                        (page.ActualSize.Height - top - bottom) / page.ActualSize.Height);
                    newPage.Canvas.DrawTemplate(page.CreateTemplate(), new PointF(left, top));
                    }

            destDoc.SaveToFile("result.pdf", FileFormat.PDF);*/





            // System.Diagnostics.Process.Start("PdfHeader.pdf");

            //let the user save it and open it and yeah
            // save the file with a unique name each time -- why? let it get over written each time np

            // return Page();
            using (var fileStream = new FileStream(Path.Combine(fileName), FileMode.Open))
            {
                await fileStream.CopyToAsync(memoryStream);
            }
            memoryStream.Position = 0;
            return File(memoryStream, "application/pdf", fileName);

        }
    }
}