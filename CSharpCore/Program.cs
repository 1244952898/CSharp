namespace CSharpCore
{
    public class Program
    {

        static void Main()
        {
            Thread t = new Thread(delegate ()
            {
                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadInterruptedException)
                {
                    Console.Write("Forcibly ");
                }
                Console.WriteLine("Woken!");
            });
            t.Start();
            t.Interrupt();
        }


    }
}