namespace _3._1
{
    public class CancellationTokenSourceTest
    {
        public void T0()
        {
            CancellationTokenSource cts = new();
            CancellationToken tk = cts.Token;
            //for (int i = 0; i < 10; i++)
            //{
                Task.Run(() =>
                {
                    T1(tk);
                });
            //}

            tk.Register(() =>
            {
                Console.WriteLine("Register");
            });

            Thread.Sleep(500);
            cts.Cancel();
            Console.WriteLine("Over");
            Thread.Sleep(1000*1000);
        }

        public void T1(CancellationToken tk) 
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"{i}");
                Thread.Sleep(100);
                if (tk.IsCancellationRequested)
                {
                    Console.WriteLine("Cancel");
                    tk.ThrowIfCancellationRequested();
                }
            }
        }
    }
}
