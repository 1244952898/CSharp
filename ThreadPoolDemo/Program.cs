using System;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int a = 100;
            Console.WriteLine("1:"+a);
            test(ref a);
            Console.WriteLine("2:" + a);
        }
        static void test(ref int a)
        {
            a += 100;
            Console.WriteLine("3:" + a);
        }
    }
}
