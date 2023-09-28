using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Xls;
using SpireDemo.NOPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpireDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NOPIDemo2.demo();
            //Workbook workbook = new Workbook();
            //workbook.LoadFromFile("D:\\Projects\\CSharp\\SpireDemo\\pdf\\1.xlsx");
            //workbook.SaveToFile("Protected.xlsx", ExcelVersion.Version2013);

            //Worksheet sheet = workbook.CreateEmptySheet("newSheet");
            //PdfDocument doc = new PdfDocument();
            //PdfPageBase page = doc.Pages.Add();
            //page.Canvas.DrawString("Hello World",
            //    new PdfFont(PdfFontFamily.Helvetica, 13f),
            //    new PdfSolidBrush(Color.Black),
            //    new PointF(50, 50));

            //doc.SaveToFile("Output.pdf");

            //IWorkbook workbook1 = new XSSFWorkbook("D:\\Projects\\CSharp\\SpireDemo\\pdf\\1.xlsx");
            //workbook1.SaveToFile("Protected.xlsx", ExcelVersion.Version2013);
        }
    }
}
