namespace CSharpCore.Models
{
    public class ManualResetEventDemo
    {
        static ManualResetEvent _starter = new(false);
        static void Main1()
        {
            RegisteredWaitHandle reg = ThreadPool.RegisterWaitForSingleObject(_starter, Go, "Some Data", -1, true);
            Thread.Sleep(1000);
            Console.WriteLine("Signaling worker...");
            _starter.Set();
            int i = 10;
            reg.Unregister(_starter);    // Clean up when we’re done.
        }

        public static void Go(object data, bool timedOut)
        {
            Console.WriteLine("Started - " + data);
        }

    }
}