using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace RxDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Observable.Range(1, 5).Subscribe(x =>
            {
                Console.WriteLine($"Observable：{x}");
            });

            foreach (var x in Enumerable.Range(1,5))
            {
                Console.WriteLine($"Enumerable：{x}");
            }
            Console.ReadKey();
        }
    }
}
