using CSharp.classes;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Document = QuestPDF.Fluent.Document;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            YeildTest yeildTest = new YeildTest();

            yeildTest.MyTest();
        }

        static IEnumerable<int> GetYeild()
        {
            Console.WriteLine("yeild 开始");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"yeild 开始执行{i}");
                yield return i;
                Console.WriteLine($"yeild 执行结束{i}");
            }
            Console.WriteLine("yeild 停止当前");
        }
    }
}
