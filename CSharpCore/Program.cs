namespace CSharpCore
{
    public class Program
    {

        static void Main()
        {
            Console.WriteLine("begin");
            Thread.MemoryBarrier();
            bool complete = false;
            var t = new Thread(() =>
            {
                bool toggle = false;
                while (!complete)
                {
                    Console.WriteLine("1");
                    toggle = !toggle;
                }
            });
            t.Start();
            Thread.Sleep(1000);
            complete = true;
            t.Join();        // Blocks indefinitely
            Console.WriteLine("end");
        }
    }
}