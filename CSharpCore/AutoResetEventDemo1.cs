using System.Threading;
using wwm.LeetCodeHelper;

namespace CSharpCore
{
    public class AutoResetEventDemo1
    {
        static AutoResetEvent _ready = new(false);
        static AutoResetEvent _go = new(false);
        static object _locker = new object();
        static string _message;
        static void Main1()
        {
            new Thread(Waiter).Start();

            _ready.WaitOne();                  // First wait until worker is ready
            lock (_locker) _message = "ooo";
            _go.Set();                         // Tell worker to go

            _ready.WaitOne();
            lock (_locker) _message = "ahhh";  // Give the worker another message
            _go.Set();
            _ready.WaitOne();
            lock (_locker) _message = string.Empty;    // Signal the worker to exit
            _go.Set();

            Console.ReadLine();
        }
        static void Waiter()
        {
            while (true)
            {
                _ready.Set();
                _go.WaitOne();
                lock (_locker)
                {
                    if (_message == null) return;        // Gracefully exit
                    Console.WriteLine(_message);
                }
            }
        }
    }
}