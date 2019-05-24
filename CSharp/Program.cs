using CSharp.字符串回文;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Queens;
using GintokiCommon.ImageUtils;
using CSharp.ElsaticSearch;
using System.Text.RegularExpressions;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strs = new []
            {
                "2018年05月30日至长期",
                "2011年03月23日至2031年03月22日",
                "2016年5月18日至2036年5月月17日",
                "2008年05月12日至2028年05月11日止日",
                "2018年09月03日至永久",
                "长期",
                "二0一五年三月五日至长期",
                "2016年6月24日至不约定期限",
                "二零零四年十月二十九日至长期",
            };
            foreach (var item in strs)
            {
                testRegex(item);
            }
          
            //ElasticLowLevelClientDemo.MainMethod();

            //ImgDemo.AAsync().GetAwaiter();

            //ImageDemo.StreamDemo();
            //ImageDemo.StreamDemo1();

            // SevenQueen.MainMethod(0);

            //Queen.FindQueen(0);


            //string s = "123qwertyuuytrewq321";
            //string a = s.Substring(0, 3);
            //Console.WriteLine(a);
            //bool result = StringCycle.IsCycleMethod(s);
            //Console.WriteLine("{0}是否是：{1}", s, result);

            //string s1 = "fedca123qwertyuuytrewq321abcdef__123321++qwertyytrewq";
            //string result1 = StringCycle.GetCycleString1(s1);
            //Console.WriteLine("result1最长是：{0}", result1);

            //string result2 = StringCycle.GetCycleString2(s1);
            //Console.WriteLine("result2最长是：{0}", result2);

            //string result3 = StringCycle.GetCycleString3("fedca123qwertyu1uytrewq321abcdef__123321++qwertyytrewq");
            //string result4 = StringCycle.GetCycleString3(s1);
            //Console.WriteLine("result3最长是：{0}", result3);
            //Console.WriteLine("result4最长是：{0}", result4);
            ////#[^#]+#
            //Parent p =new Parent();
            //int? d = p.Childrens?.Count;
            Console.ReadKey();
        }

        public static void testRegex(string ss = "2011年03月23日至2031年03月22日")
        {
            string begin=string.Empty, end = string.Empty;
            if (!string.IsNullOrWhiteSpace(ss))
            {
                if (ss.Contains("长期") || ss.Contains("永久") || ss.Contains("不约定期限"))
                {
                    end = "3099-12-31";
                }
                else if (ss.Contains("至"))
                {
                    var endTimeStr = ss.Substring(ss.IndexOf("至"));
                    if (!string.IsNullOrWhiteSpace(endTimeStr) || !endTimeStr.Equals("至"))
                    {
                        endTimeStr = endTimeStr.Trim('至');
                        end = GetMatchStr(endTimeStr);
                    }
                }
            }

            if (ss.Contains("至"))
            {
                var beginTimeStr = ss.Substring(0,ss.IndexOf("至"));
                if (!string.IsNullOrWhiteSpace(beginTimeStr) || !beginTimeStr.Equals("至"))
                {
                    begin = GetMatchStr(beginTimeStr);
                }
            }

            Console.WriteLine($"begin={begin} end={end}");

        }

        public static string GetMatchStr(string matchStr)
        {
            Regex regexNum = new Regex("^\\d{4}年(\\d{1,2}月(\\d{1,2}(日)?)?)?$");
            if (regexNum.IsMatch(matchStr))
            {
                return Regex.Replace(matchStr, "年|月", "-").Trim('日');
            }
            //Regex regexChar = new Regex("^(零|〇|一|二|三|四|五|六|七|八|九|十){2,4}年((正|一|二|三|四|五|六|七|八|九|十|十一|十二)月((一|二|三|四|五|六|七|八|九|十){1,3}(日)?)?)?$");
            //if (regexChar.IsMatch(matchStr))
            //{
            //    char[] matchChar = matchStr.Trim('日').ToArray();
            //    matchChar.Select(x =>
            //    {
            //        if (x.Equals('年')|| x.Equals('月'))
            //        {
            //            return '-';
            //        }
            //        else if (x.Equals('年') || x.Equals('月'))
            //        {
            //            return '0';
            //        }
            //        else if (x.Equals('一'))
            //        {
            //            return '1';
            //        }
            //        else if (x.Equals('二'))
            //        {
            //            return '2';
            //        }
            //        else if (x.Equals('三'))
            //        {
            //            return '3';
            //        }
            //        else if (x.Equals('四'))
            //        {
            //            return '4';
            //        }
            //        else if (x.Equals('五'))
            //        {
            //            return '5';
            //        }
            //        else if (x.Equals('六'))
            //        {
            //            return '6';
            //        }
            //        else if (x.Equals('七'))
            //        {
            //            return '7';
            //        }
            //        else if (x.Equals('八'))
            //        {
            //            return '8';
            //        }
            //        else if (x.Equals('九'))
            //        {
            //            return '9';
            //        }
            //        return ' ';
            //    });
            //}
            return string.Empty;
        }
    }
}
