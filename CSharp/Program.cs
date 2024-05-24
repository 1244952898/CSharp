using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(Go);
        }
        static void Go()
        {
            var isPool = Thread.CurrentThread.IsThreadPoolThread;
            Console.WriteLine($"Hello from the thread pool!   {isPool}");
        }
    }
}
