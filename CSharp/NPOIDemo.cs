using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace CSharpCore.Models
{
    public class NPOIDemo
    {
        public void Test()
        {
            // 创建新的Excel工作簿
            IWorkbook workbook = new XSSFWorkbook();

            // 创建一个工作表
            ISheet sheet1 = workbook.CreateSheet("Sheet1");

            //HSSFPatriarch patriarch = sheet1.CreateDrawingPatriarch();
            //HSSFClientAnchor a1 = new HSSFClientAnchor(255, 125, 1023, 150, 0, 0, 2, 2);
            //HSSFSimpleShape line1 = patriarch.CreateSimpleShape(a1);
            //line1.ShapeType = HSSFSimpleShape.OBJECT_TYPE_LINE;
            //line1.LineStyle = HSSFShape.LINESTYLE_SOLID; //在NPOI中线的宽度12700表示1pt,所以这里是0.5pt粗的线条。 line1.LineWidth = 6350;


            // 写入文件
            using (FileStream fileStream = new FileStream("output.xlsx", FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fileStream);
            }
        }
    }
}
