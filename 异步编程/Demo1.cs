using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 异步编程
{
    public class Demo1
    {
        public static readonly Stopwatch stopwatch = new Stopwatch();

        public static void Main1() {
            stopwatch.Start();
            const string url1 = "http://www.cnblogs.com/";
            const string url2 = "http://www.cnblogs.com/liqingwen/";

            // 两次调用 CountCharacters 方法（下载某网站内容，并统计字符的个数）
            var result1 = CountCharacters(1, url1);
            var result2 = CountCharacters(2, url2);

            //三次调用 ExtraOperation 方法（主要是通过拼接字符串达到耗时操作）
            for (var i = 0; i < 3; i++)
            {
                ExtraOperation(i + 1);
            }

            //控制台输出
            Console.WriteLine($"{url1} 的字符个数：{result1}");
            Console.WriteLine($"{url2} 的字符个数：{result2}");

            Console.Read();
        }

        private static int CountCharacters(int id, string url1)
        {
            var wc = new WebClient();

            Console.WriteLine(string.Format("开始调用 id = {0}: {1} ms",id,stopwatch.ElapsedMilliseconds));

            var result = wc.DownloadString(url1);
            Console.WriteLine(string.Format("调用完成 id = {0}: {1} ms", id, stopwatch.ElapsedMilliseconds));

            return result.Length;
        }

        /// <summary>
        /// 额外操作
        /// </summary>
        /// <param name="id"></param>
        private static void ExtraOperation(int id)
        {
            //这里是通过拼接字符串进行一些相对耗时的操作
            var s = "";

            for (var i = 0; i < 6000; i++)
            {
                s += i;
            }

            Console.WriteLine($"id = {id} 的 ExtraOperation 方法完成：{stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
