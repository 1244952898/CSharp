using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleTest
{
    delegate void StringAction(B q);
    class Program
    {
        static void Main(string[] args)
        {
            //new RegexTelphone().aa();

            string contentab = @"85998437469胜19810198386多负少<em>1009</em>东方发生大发198-1019-8386送到198 1019 8386发送地198<em>1009</em>8386方沙发1353456789111111111上是1111111113534567891的发送到多发15998437469";
            //var resultcontent =  Regex.Replace(contentab, "(1\\d{10})", "$1 ****$2");
            // var resultcontent1 = Regex.Replace("18710098386", "^1\\d{10}$", "$1 ****$2");

            string contentabc = "1009";
            string contentabc2 = "1a009";

            bool isNeedReplace = !string.IsNullOrWhiteSpace(contentabc) && Regex.IsMatch(contentabc, "^[0-9]{0,11}$");
            bool isNeedReplace2 = !string.IsNullOrWhiteSpace(contentabc2) && Regex.IsMatch(contentabc2, "^[1-9]\\d*|0$");

            contentab = contentab.Replace($"<em>{contentabc}</em>", contentabc);

            var resultcontent2 = Regex.Replace(contentab, "((?<!\\d)1\\d{2}[\\s|-]?)\\d{4}([\\s|-]?\\d{4}(?!\\d))", "$1****$2");

            contentab = resultcontent2.Replace(contentabc,$"<em>{contentabc}</em>");

            var aggg = Regex.Replace(contentab, "(1\\d{2})\\d{4}(\\d{4})", "$1****$2");

            Regex reMobile = new Regex("1\\d{10}");
            Regex reMobile2 = new Regex(@"\\d+");
            if (reMobile.IsMatch("18710098386"))
            {

            }

            MatchCollection matchCollection = reMobile.Matches(contentab);
            if (matchCollection != null && matchCollection.Count > 0)
            {
                for (int i = 0; i < matchCollection.Count; i++)
                {
                    var phone = matchCollection[i].Value;
                    var newphone =  Regex.Replace(contentab, @"(^1\\d{10}$)", "$1 ****$2");
                    contentab = contentab.Replace(phone, newphone);
                }
            }

#if DEBUG
            string ssd ="a";
#elif TEST
            string ssd="b";
#elif RELEASE
            string ssd = "c";
#else
             string ssd = "空";
#endif

            Console.WriteLine(ssd);
            Console.Read();
            var ds = new DateTime(1, 1, 1);
          
            var s = ds.ToString("yyyy-MM-dd");
            var ddd = DateTime.MinValue;
            var sss = ddd.ToString("yyyy-MM-dd");

            string str = "🌹1231啊啊🍀🍎💰📱🌙🍁🍂🍃";

            var st1 = str.SubStringStartIndexUnicode(7);
            var st11 = str.SubStringStartIndexUnicode(8);

            var st2 = str.SubStringUnicode(7);
            var st22 = str.SubStringUnicode(8);

            var st3=str.SubStringUnicode(6,4);
            var st33=str.SubStringUnicode(1,6);
            var st333=str.SubStringUnicode(7,5);



            int a = 43;
            int bb = -a;
            string ccc = "1234567890123奥迪4567890";
            var index = ccc.IndexOf("奥迪");
            if (index > 10)
            {
                ccc = ccc.Substring(index - 7).Trim();
            }

            ccc = ccc.Length > 60 ? ccc.Substring(0, 60) : ccc;
                



            string content = @"#最新车源#125844778888\n\r88
东风风光干活哈哈风风光光干活啊好啊我在上班吗你不上班的？你怎奔驰 现车 19款奔驰C260L大标3508白⬇️1.7万裸店票 19款奔驰E300L小标4758黑棕⬇️2.1万裸店票 19款奔驰E300L小标5028黑棕⬇️2.1万裸店票 18款GLE320黑棕\黑74.98裸带环影⬇️6万 18款GLE320黑棕74.98裸不带环影⬇️7万 19款S450L 卓越黑棕122.8裸加1万店票";

            content = content.Replace("#最新车源#", "").Trim();
            string newContent = content.Length > 36 ? content.Substring(0, 36) : content;
            newContent = newContent.Replace("联系电话：", "").Replace("联系电话", "");
            Regex regexTelephone = new Regex(@"(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}");
            Regex regexMobile = new Regex(@"1[345678]\d{9}");
            if (regexMobile.IsMatch(newContent))
            {
                newContent = regexMobile.Replace(newContent, "");
            }
            else if (regexTelephone.IsMatch(newContent))
            {
                newContent = regexTelephone.Replace(newContent, "");
            }
            newContent = Regex.Replace(newContent, @"[\n\r]", "");
            newContent = newContent.Length > 10 ? newContent.Substring(0, 10) : newContent;
            var aaa =newContent.Trim().Replace("\n",""); 

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
