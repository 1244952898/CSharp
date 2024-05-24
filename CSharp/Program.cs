using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp
{
    class Program
    {
        private object _lock = new object();
        static void Main(string[] args)
        {
        }
        void Go()
        {
            bool lockTaken = false;
            Monitor.Enter(_lock, ref lockTaken);
            try
            {

                var isPool = Thread.CurrentThread.IsThreadPoolThread;
                Console.WriteLine($"Hello from the thread pool!   {isPool}");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Monitor.Exit(_lock);

            }
        }
    }
}
