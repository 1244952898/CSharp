using Aspose.Cells;
using Aspose.Pdf;

namespace SpireDemo.NOPI
{
    public class NOPIDemo2
    {
        public static void demo()
        {
            var fileExcelname = "D:\\Projects\\CSharp\\SpireDemo\\pdf\\1.xlsx";
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(fileExcelname);

            var saveOptions = new Aspose.Cells.PdfSaveOptions();

            //设置字体嵌入选项
            //saveOptions.EmbeddedFonts = true;
            //saveOptions.Encoding = PdfTextEncoding.Unicode;

            //设置元数据
            //saveOptions.Title = "PDF生成自Excel";
            //saveOptions.Subject = "Aspose Excel转PDF演示";
            //saveOptions.Author = "Aspose";

            //设置PDF输出质量
            //saveOptions.Compliance = PdfCompliance.PdfA1b;
            //saveOptions.ImageCompression = PdfImageCompression.Jpeg;
            //saveOptions.TransparencyRenderingType = TransparencyRenderingType.Advanced;
            saveOptions.AllColumnsInOnePagePerSheet = true;
            //saveOptions.Watermark=new Aspose.Cells.Rendering.RenderingWatermark
            saveOptions.OnePagePerSheet=true;
            saveOptions.PageCount = 2;
            workbook.Save("D:\\Projects\\CSharp\\SpireDemo\\pdf\\output.pdf", saveOptions);

        }
    }
}
