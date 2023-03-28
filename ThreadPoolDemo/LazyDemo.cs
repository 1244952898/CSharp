using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPoolDemo
{
    internal class LD
    {
        private LazyDemo _lz;
        public LazyDemo LazyDemo
        {
            get {

                LazyInitializer.EnsureInitialized(ref _lz, () =>
                {
                    //var l = ;
                    //l.Name = "foo";
                    return new LazyDemo();
                });
                return _lz;
            }
            set { _lz = value; }
        }

        volatile LD _pld;
        public LD PLD {
            get
            { 
                if (_pld == null)
                {
                    var instance = new LD();
                    Interlocked.CompareExchange(ref _pld, instance, null);
                }
                return _pld;
            } 
        }

    }
    internal class LazyDemo
    {
        public string Name { get; set; }
        public LazyDemo()
        {
            Console.WriteLine("Initial");
            Name= "zy";

        }
    }
}
