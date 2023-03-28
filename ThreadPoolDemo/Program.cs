using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    class Program
    {
        static bool _go,_ready;
        private static readonly object _locker = new object();
        static void Main(string[] args)
        {
            new Thread(SaySomething).Start();

            for (int i = 0; i < 5; i++)
            {
                lock (_locker)
                {
                    while (!_ready)
                    {
                        Monitor.Wait(_locker);
                    }
                    _ready = false;

                    _go = true;
                    Monitor.PulseAll(_locker);
                }
            }

                
        }
        static void SaySomething()
        {
            for (int i = 0; i < 5; i++)
            {
                lock (_locker)
                {
                    _ready = true;
                    Monitor.PulseAll(_locker);

                    while (!_go) 
                        Monitor.Wait(_locker);
                    _go = false;

                    Console.WriteLine("Wassup?");
                }
            }
        }
    }

    
}
