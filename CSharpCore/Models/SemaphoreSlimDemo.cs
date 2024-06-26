﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models
{
    internal class SemaphoreSlimDemo
    {
        static SemaphoreSlim _sem = new SemaphoreSlim(3);    // Capacity of 3

        static void Main1()
        {
            for (int i = 1; i <= 5; i++)
                new Thread(start: Enter).Start(i);
        }

        static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            _sem.Wait();
            Console.WriteLine(id + " is in!");           // Only three threads
            Thread.Sleep(1000 * (int)id);               // can be here at
            Console.WriteLine(id + " is leaving");       // a time.
            _sem.Release();
        }
    }
}
