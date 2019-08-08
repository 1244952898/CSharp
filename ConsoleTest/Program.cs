using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleTest
{
    delegate void StringAction(B q);
    class Program
    {
        static void Main(string[] args)
        {
            //StringAction sa = new StringAction(ActOnObject);
            ImageCircle d = new ImageCircle();
            //var imgPath = "http://t.image.bitauto.com/test/ypimg/das/carsource1/thumbnail/1c9f7f8f-ca87-432e-ac81-be4ee5bccc6a.jpg";//C:\\Users\\zhuangyu\\source\\repos\\CSharp\\ConsoleTest\\img\\1.jpg
            //Image image = Image.FromFile(imgPath);       //判断图片是否已经存在，若存在，删除
            //var imgSavePath = "E:\\2.jpg";
            //if (!File.Exists(imgSavePath))
            //{
            //    //File.Delete(Path.GetFullPath(imgSavePath));//删除存在
            //    //将图片裁剪成圆形，并保存到本地
            //    d.CutEllipse(image, new Rectangle(0, 0, 140, 140), new Size(140, 140), imgSavePath);
            //}
            d.ImgFont();

        }
        static void ActOnObject(A q)  
        {
        }
    }
}
