using CSharpCore.Models.Threads._1._10._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.Threads._2._2._2
{
    public class TestCounter
    {
        public static void Test(CounterBase counter)
        {
            for (int i = 0; i < 1000000; i++)
            {
                counter.Increment();
                counter.Decrement();    
            }
        }
    }
}
