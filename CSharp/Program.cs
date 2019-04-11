using CSharp.字符串回文;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = "123qwertyuuytrewq321";
            string a = s.Substring(0, 3);
            Console.WriteLine(a);
            bool result = StringCycle.IsCycleMethod(s);
            Console.WriteLine("{0}是否是：{1}", s, result);

            string s1 = "fedca123qwertyuuytrewq321abcdef__123321++qwertyytrewq";
            string result1 = StringCycle.GetCycleString1(s1);
            Console.WriteLine("result1最长是：{0}", result1);

            string result2 = StringCycle.GetCycleString2(s1);
            Console.WriteLine("result2最长是：{0}", result2);

            string result3 = StringCycle.GetCycleString3("fedca123qwertyu1uytrewq321abcdef__123321++qwertyytrewq");
            string result4 = StringCycle.GetCycleString3(s1);
            Console.WriteLine("result3最长是：{0}", result3);
            Console.WriteLine("result4最长是：{0}", result4);
            //#[^#]+#
            Parent p =new Parent();
            int? d = p.Childrens?.Count;
            Console.ReadKey();
        }
    }
}
