using CSharpCore.Models.Threads._1._10._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.Threads._2._2._2
{
    internal class CounterInterLocker : CounterBase
    {
        private int _counter;

        public int Count => _counter;

        public override void Decrement()
        {
            Interlocked.Decrement(ref _counter);
        }

        public override void Increment()
        {
            Interlocked.Increment(ref _counter);
        }
    }
}
