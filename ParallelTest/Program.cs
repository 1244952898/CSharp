using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //ParallelAggregateException.Test();
            ParallelAggregateException.ParallelForPara();
            Console.ReadKey();
        }
    }
}
