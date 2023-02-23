using CSharp.字符串回文;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Queens;
using CSharp.ElsaticSearch;
using System.Text.RegularExpressions;
using System.Threading;
using Nest;
using Newtonsoft.Json;
using CSharp.TestInterface2;
using CSharp.copyTest;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1= new Class1();
            class1.T(199);
            var cp = new Copy1();
            cp.Num = 10;
            cp.C0 = new Copy0 { Age = 1, Name = "zy" };
            var cp0=cp;
            cp0.Num = 110;
            Console.WriteLine(cp.Num);

            var cp1= Clone


            ThreadDemo.Run2();
            Console.WriteLine("Over");
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

    public class Abc
    { 
        public List<string> names { get; set; }
    }
}
