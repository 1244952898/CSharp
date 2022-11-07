using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateAndEvent
{
    public class AwaitAsyncDemo
    {
        public void Show()
        {
            Console.WriteLine($"Show start 1: {Thread.CurrentThread.ManagedThreadId:00}");
            AsyncMethod();
            Console.WriteLine($"Show end 1: {Thread.CurrentThread.ManagedThreadId:00}");
        }

        public async Task AsyncMethod()
        {
            Console.WriteLine($"AsyncMethod start 1: {Thread.CurrentThread.ManagedThreadId:00}");
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"AsyncMethod Task in 1: {Thread.CurrentThread.ManagedThreadId:00}");
            });
            Console.WriteLine($"AsyncMethod end 1: {Thread.CurrentThread.ManagedThreadId:00}");
        }
    }
}
