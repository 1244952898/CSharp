using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Linq;

namespace Threadlianxi
{
    internal class AwaitDemo0
    {
        public async void M()
        {
            var t0 = AsynchronyWithTPL();
            Console.WriteLine(t0.AsyncState);
            t0.Wait();

            var t1 = AsynchronyWithAwait();
            Console.WriteLine(t0.AsyncState);
            t1.Wait();

            Func<string, Task<string>> lambdas = async name =>
            {
                await Task.Delay(500);
                return string.Format("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
            };
            var t3 = await lambdas("async lambda");

        }

        static Task AsynchronyWithTPL()
        {
            var t = GetInfoAsync("Task 1");
            var t2=t.ContinueWith(task=>Console.WriteLine(task.Result),TaskContinuationOptions.NotOnFaulted);
            var t3= t.ContinueWith(task => Console.WriteLine(task.Result), TaskContinuationOptions.OnlyOnFaulted);
            return Task.WhenAny(t2,t3);
        }
        async static Task AsynchronyWithAwait()
        {
            try
            {
                string result = await GetInfoAsync("Task 2");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async static Task<string> GetInfoAsync(string name)
        {
           
            //Parallel.For()
            await Task.Delay(TimeSpan.FromSeconds(2));
            //throw new Exception("Boom!");
            return string.Format("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}
