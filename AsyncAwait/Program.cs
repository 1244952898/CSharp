namespace AsyncAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static Task TestAsync()
        {
            return Task.Run(() =>
            {
                Console.Write("Hello");
            });
        }

    }
}
