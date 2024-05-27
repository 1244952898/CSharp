namespace CSharpCore
{
    public class Program
    {
        static ManualResetEvent _starter = new(false);
        static void Main()
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
            using Mutex mutex = new(false, "oreilly.com OneAtATimeDemo");
            if (mutex.WaitOne(TimeSpan.FromSeconds(3), false))
            {
                Console.WriteLine("Another app instance is running. Bye!");
                return;
            }
            RunProgram();
            Console.ReadLine();
        }

        static void RunProgram()
        {
            Console.WriteLine("Running. Press Enter to exit");
            Console.ReadLine();
        }

    }
}