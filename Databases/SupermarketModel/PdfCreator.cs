using System;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;

namespace SupermarketModel
{
    public static class PdfCreator
    {
        public static void GeneratePdf()
        {
            System.IO.FileStream fs = new FileStream(String.Format("..//..//..//Resources//PdfReports") + "//" + "pdfReport3.pdf", FileMode.Create);

            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            //Create an instance to the PDF file by creating an instance of the PDF 
            //Writer class using the document and the filestrem in the constructor.
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            //Open the document to enable you to write to the document
            document.Open();

            PdfPTable table = new PdfPTable(5);
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            var fontintestazione = FontFactory.GetFont("Verdana", 10, Font.BOLD);

            PdfPCell cell = new PdfPCell(new Phrase("Aggregated Sales Report", fontintestazione));
            cell.Colspan = 5;
            cell.Padding = 10;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            using (var context = new SupermarketContext())
            {
                decimal grandSum = 0;

                var grouppedProducts = context.Reports.GroupBy(x => x.Date);

                foreach (var date in grouppedProducts)
                {
                    PdfPCell cell1 = new PdfPCell(new Phrase("Date: " + date.Key.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)));
                    cell1.Colspan = 5;
                    cell1.BackgroundColor = new BaseColor(217, 217, 217);
                    table.AddCell(cell1);

                    PdfPCell productCell = new PdfPCell(new Phrase("Product", fontintestazione));
                    productCell.BackgroundColor = new BaseColor(217, 217, 217);
                    table.AddCell(productCell);
                    PdfPCell quantityCell = new PdfPCell(new Phrase("Quantity", fontintestazione));
                    quantityCell.BackgroundColor = new BaseColor(217, 217, 217);
                    table.AddCell(quantityCell);
                    PdfPCell unitPriceCell = new PdfPCell(new Phrase("Unit Price", fontintestazione));
                    unitPriceCell.BackgroundColor = new BaseColor(217, 217, 217);
                    table.AddCell(unitPriceCell);
                    PdfPCell locationCell = new PdfPCell(new Phrase("Location", fontintestazione));
                    locationCell.BackgroundColor = new BaseColor(217, 217, 217);
                    table.AddCell(locationCell);
                    PdfPCell sumCell = new PdfPCell(new Phrase("Sum", fontintestazione));
                    sumCell.BackgroundColor = new BaseColor(217, 217, 217);
                    table.AddCell(sumCell);

                    decimal sum = 0;
                    foreach (var report in date)
                    {
                        table.AddCell(report.Product.Name);
                        table.AddCell(report.Quantity + " " + report.Product.Measure.Name);
                        table.AddCell(report.UnitPrice.ToString("0.00"));
                        table.AddCell(report.Location.Name);
                        table.AddCell(report.Sum.ToString("0.00"));

                        sum += report.Sum;
                    }
                    grandSum += sum;
                    
                    PdfPCell cell2 = new PdfPCell(new Phrase("Total sum for: " + date.Key.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)));
                    cell2.Colspan = 4;
                    cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell2);
                    table.AddCell(sum.ToString("0.00"));
                }
                PdfPCell grandTotalSumCell = new PdfPCell(new Phrase("Grand Total:"));
                grandTotalSumCell.Colspan = 4;
                grandTotalSumCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(grandTotalSumCell);
                table.AddCell(grandSum.ToString("0.00"));
                document.Add(table);
                document.Close();

                writer.Close();

                fs.Close();
            }
        }
    }
}
           
