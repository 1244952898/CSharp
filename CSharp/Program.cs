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
using CSharp.NodeTest;
using System.Globalization;
using CSharp.ISTest;
using System.Collections;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var discs=new Dictionary<string, string>();



            discs["a"] = "1";
            discs["a"] = "111";
            discs["b"] = "2";

            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
                Console.WriteLine("  {0} = {1}", de.Key, de.Value);

            A aa = new A();
            if (aa is IIsA abc)
            {
                abc.M0();
            }
            string.Format(CultureInfo.InvariantCulture, "");
            var nm= GCD_Algorithm.Gcd(24, 24);
            var l0 = new List<int>() { 1, 2, 3, 4, 5 };
            var l1 = new List<int>() { 3, 4, 5, 6, 7 };
            var l3 = l0.Union(l1);
            var l4 = l0.Except(l1);
            var l5 = l0.Intersect(l1);
            Action<int> getTes = (x) =>
            {
                Console.WriteLine(x);
            };
            getTes += (y) =>
            {
                Console.WriteLine(y);
            };
            getTes.Invoke(2);

            var na = new Node<string>("a");
            var nb = new Node<string>("a",na);
            //var nc = new Node<int>(1,na);
            var n1 = new NodeTest.Node1<int>(1);
            var n2 = new NodeTest.Node1<string>("2",n1);
            var a = string.Equals("a", "b",StringComparison.InvariantCultureIgnoreCase);

            Func<AggregateException, object> fn1 = null;
            Func<Exception, string> fn2 = null;
            fn1 = fn2;
            //fn2 = fn1;
            IEnumerable<object> list = new List<string>();
            Class4 class4= new Class4();
            class4.T(delegate (int i)
            {
                Console.WriteLine(i);
            });

            var ints = new int[] { 1, 2, };
            ints.ToArray();
            Task.Delay(1000).Wait();
            //Task.Factory.StartNew(() => { }).

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
