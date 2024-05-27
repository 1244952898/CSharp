﻿using System.Threading;
using wwm.LeetCodeHelper;

namespace CSharpCore
{
    public class Program
    {
        static AutoResetEvent _waitHandle = new(false);
        static void Main()
        {
            _waitHandle.Set();// Wake up the Waiter.
            //new Thread(Waiter).Start();
            Thread.Sleep(5000);                  // Pause for a second...
            new Thread(Waiter).Start();          



            Console.ReadLine();
        }
        static void Waiter()
        {
            Console.WriteLine($"{Environment.CurrentManagedThreadId}Waiting...");
            _waitHandle.WaitOne();                // Wait for notification
            Console.WriteLine($"{Environment.CurrentManagedThreadId}Notified");
        }
    }
}