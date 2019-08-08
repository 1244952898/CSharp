using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class ImageCircle
    {
        public Image CutEllipse(Image img, Rectangle rec, Size size, string imgSavePath)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Clamp, rec))
                {
                    br.ScaleTransform(bitmap.Width / (float)rec.Width, bitmap.Height / (float)rec.Height);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(br, new Rectangle(Point.Empty, size));
                }
            }
            bitmap.Save(imgSavePath, System.Drawing.Imaging.ImageFormat.Png);
            return null;
        }

        public void ImgFont()
        {
            //背景图片 判断图片是否索引像素格式,是否是引发异常的像素格式
            var filePath = @"C:\\Users\\zhuangyu\\source\\repos\\CSharp\\ConsoleTest\\img\\moment_bg_new.png";
            Bitmap backImg = new Bitmap(filePath);
            using (Graphics g = Graphics.FromImage(backImg))
            {
                //6.内容
                string newContent = "啊啊啊啊啊啊啊啊123啊啊啊啊123啊啊啊啊啊啊啊啊啊啊啊啊!234234asdf,,啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊123啊啊啊啊啊啊啊啊啊啊啊啊!234234asdf,,啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊123啊啊啊啊啊啊啊啊啊啊啊啊!234234asdf,,啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊 啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊!234234asdf,,啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊123456789";

                var ch = newContent.ToCharArray();
                Font useContentFont = new Font("PingFangSC-Regular", 46, FontStyle.Regular, GraphicsUnit.Pixel);
                Brush contentBush = new SolidBrush(Color.Black);//填充的颜色
                var pf = new PointF(49, 1259);
                RectangleF contentRect = new RectangleF(pf, new Size(984, 206));//
         

                //System.Drawing.SizeF size1 = g.MeasureString(newContent, useContentFont,new PointF(49, 1259), new StringFormat());

              
                //System.Drawing.SizeF size2 = g.MeasureString(newContent, useContentFont, new SizeF(984, 206), stringFormat);
                
                //RectangleF contentRect = new RectangleF(new PointF(49, 1259), size2);//
                //Region[] regions = g.MeasureCharacterRanges(newContent, useContentFont, contentRect, new StringFormat());

                var stringFormat = new StringFormat();
                stringFormat.Trimming = StringTrimming.EllipsisWord;
                foreach (var c in ch)
                {
                    //获取字符尺寸
                    var charSize = g.MeasureString(c.ToString(), useContentFont);
                   // g.DrawString(newContent, useContentFont, contentBush, contentRect, stringFormat);
                    var newX = pf.X + charSize.Width;
                    if (newX>(49+984))
                    {
                        newX = 49;
                        var newY = pf.Y + (charSize.Height + 80);
                        if (true)
                        {

                        }
                    }
                    //设置行高
                    if (pf.X > 1000)
                    {      g.DrawString(c.ToString(), useContentFont, contentBush, pf);
                        pf.X = 49;
                        pf.Y += (charSize.Height + 5);

                    }
                }
               // g.DrawString(newContent, useContentFont, contentBush, contentRect, stringFormat);  //绘制文本


                g.Save();
                MemoryStream ms = new MemoryStream();
                backImg.Save("E:\\b.png");
            }
        }
    }
}
