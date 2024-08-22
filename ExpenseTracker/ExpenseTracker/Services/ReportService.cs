using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Services.Interfaces;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace ExpenseTracker.Services;

public class ReportService : IReportService
{
    public byte[] GenerateIncomePdfReport(IEnumerable<IncomeDTO> incomes)
    {
        using (var document = new PdfDocument())
        {
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var fontHeader = new XFont("Arial", 16);
            var fontSubHeader = new XFont("Arial", 14);
            var fontContent = new XFont("Arial", 12);

            // Draw header
            gfx.DrawString("Income Report", fontHeader, XBrushes.Black,
                new XRect(0, 20, page.Width, 0),
                XStringFormats.TopCenter);

            // Draw sub-header (column titles)
            double yPosition = 60;
            gfx.DrawString("Name", fontSubHeader, XBrushes.Black,
                new XRect(50, yPosition, 100, 0),
                XStringFormats.TopLeft);
            gfx.DrawString("Description", fontSubHeader, XBrushes.Black,
                new XRect(150, yPosition, 200, 0),
                XStringFormats.TopLeft);
            gfx.DrawString("Amount", fontSubHeader, XBrushes.Black,
                new XRect(350, yPosition, 100, 0),
                XStringFormats.TopLeft);
            gfx.DrawString("Date", fontSubHeader, XBrushes.Black,
                new XRect(450, yPosition, 100, 0),
                XStringFormats.TopLeft);

            yPosition += 30;

            gfx.DrawLine(XPens.Black, 50, yPosition - 10, page.Width - 50, yPosition - 10);

            foreach (var income in incomes)
            {
                // Draw content
                gfx.DrawString(income.IncomeName, fontContent, XBrushes.Black,
                    new XRect(50, yPosition, 100, 0),
                    XStringFormats.TopLeft);
                gfx.DrawString(income.IncomeDescription, fontContent, XBrushes.Black,
                    new XRect(150, yPosition, 200, 0),
                    XStringFormats.TopLeft);
                gfx.DrawString(income.IncomeAmount.ToString(), fontContent, XBrushes.Black,
                    new XRect(350, yPosition, 100, 0),
                    XStringFormats.TopLeft);
                gfx.DrawString(income.IncomeDate.ToString("MM/dd/yyyy"), fontContent, XBrushes.Black,
                    new XRect(450, yPosition, 100, 0),
                    XStringFormats.TopLeft);

                yPosition += 30; // Space between entries

                // Draw line separator
                gfx.DrawLine(XPens.LightGray, 50, yPosition - 10, page.Width - 50, yPosition - 10);
            }

            // Save the document to a memory stream
            using (var ms = new MemoryStream())
            {
                document.Save(ms, false);
                return ms.ToArray();
            }
        }
    }



    public byte[] GenerateExpensePdfReport(IEnumerable<ExpenseDTO> expenses)
    {
        using (var document = new PdfDocument())
        {
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var fontHeader = new XFont("Arial", 16);
            var fontSubHeader = new XFont("Arial", 14);
            var fontContent = new XFont("Arial", 12);

            // Draw header
            gfx.DrawString("Expense Report", fontHeader, XBrushes.Black,
                new XRect(0, 20, page.Width, 0),
                XStringFormats.TopCenter);

            // Draw sub-header (column titles)
            double yPosition = 60;
            gfx.DrawString("Name", fontSubHeader, XBrushes.Black,
                new XRect(50, yPosition, 100, 0),
                XStringFormats.TopLeft);
            gfx.DrawString("Description", fontSubHeader, XBrushes.Black,
                new XRect(150, yPosition, 200, 0),
                XStringFormats.TopLeft);
            gfx.DrawString("Amount", fontSubHeader, XBrushes.Black,
                new XRect(350, yPosition, 100, 0),
                XStringFormats.TopLeft);
            gfx.DrawString("Date", fontSubHeader, XBrushes.Black,
                new XRect(450, yPosition, 100, 0),
                XStringFormats.TopLeft);

            yPosition += 30;

            gfx.DrawLine(XPens.Black, 50, yPosition - 10, page.Width - 50, yPosition - 10);

            yPosition += 10;

            foreach (var expense in expenses)
            {
                // Draw content
                gfx.DrawString(expense.ExpenseName, fontContent, XBrushes.Black,
                    new XRect(50, yPosition, 100, 0),
                    XStringFormats.TopLeft);
                gfx.DrawString(expense.ExpenseDescription, fontContent, XBrushes.Black,
                    new XRect(150, yPosition, 200, 0),
                    XStringFormats.TopLeft);
                gfx.DrawString(expense.ExpenseAmount.ToString(), fontContent, XBrushes.Black,
                    new XRect(350, yPosition, 100, 0),
                    XStringFormats.TopLeft);
                gfx.DrawString(expense.ExpenseDate.ToString("MM/dd/yyyy"), fontContent, XBrushes.Black,
                    new XRect(450, yPosition, 100, 0),
                    XStringFormats.TopLeft);

                yPosition += 30; // Space between entries

                // Draw line separator
                gfx.DrawLine(XPens.LightGray, 50, yPosition - 10, page.Width - 50, yPosition - 10);
            }

            // Save the document to a memory stream
            using (var ms = new MemoryStream())
            {
                document.Save(ms, false);
                return ms.ToArray();
            }
        }
    }
}
