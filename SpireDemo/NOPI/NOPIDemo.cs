using iTextSharp.text;
using iTextSharp.text.pdf;
using NPOI.SS.UserModel;
using NPOI.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpireDemo.NOPI
{
    public class NOPIDemo
    {
        public static void demo()
        {
            var fileExcelname = "D:\\Projects\\CSharp\\SpireDemo\\pdf\\1.xlsx";
            var filePdfname = "D:\\Projects\\CSharp\\SpireDemo\\pdf\\1.pdf";
            //IWorkbook workbook1 = new XSSFWorkbook();
            Document document=new Document();
            FileStream fs = new FileStream(filePdfname, FileMode.Open, FileAccess.Read);
            PdfWriter.GetInstance(document, fs);

            document.OpenDocument();



            document.Open();

        }
    }
}
