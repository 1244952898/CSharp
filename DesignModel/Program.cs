using DesignModel.ClainOfResponsibility_责任链模式_;
using System;
using System.Collections.Concurrent;

namespace DesignModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ClainOfResponsibilityDemo.main();
            Console.ReadLine();

            //ConcurrentDictionary<int,string> keyValuePairs= new ConcurrentDictionary<int,string>();
        }
    }
}
