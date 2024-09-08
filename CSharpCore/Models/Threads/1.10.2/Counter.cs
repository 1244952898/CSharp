using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.Threads._1._10._2
{
    public class Counter:CounterBase
    {
        public string Name {  get; set; }
        public string Name2 {  get; set; }
        public int Count {  get; set; }

        public override void Decrement()
        {
            Count++;
        }

        public override void Increment()
        {
            Count--;
        }
    }
}
