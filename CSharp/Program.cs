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
using CSharp.多线程;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(() =>
            {
                try
                {
                    throw null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception!");
                }

            }).Start();

            try
            {
                new Thread(() =>
                {
                    throw null;
                }).Start();
            }
            catch (Exception ex)
            {
                // We'll never get here!
                Console.WriteLine("Exception!");
            }

            Console.Read();
            //for (int i = 0; i < 10; i++)
            //    new Thread(() => Console.Write(i)).Start();
            //var urls = new string[]
            //{
            //    "https://www.baidu.com/",
            //    "https://blog.csdn.net/"
            //};
            //var res= DownLoadPageDemo.DownLoadAsync(urls);
            //Console.WriteLine(res.Result);
        }


    }

    public class Abc
    { 
        public List<string> names { get; set; }
    }
}
