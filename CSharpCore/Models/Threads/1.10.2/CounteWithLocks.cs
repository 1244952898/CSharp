using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.Threads._1._10._2
{
    public class CounteWithLocks : CounterBase
    {
        private object _lock = new object();
        public int Count {  get; set; }

        public override void Decrement()
        {
            lock (_lock)
            {
                Count++;
            }
        }

        public override void Increment()
        {
            lock (_lock)
            {
                Count--;
            }
          
        }
    }
}
