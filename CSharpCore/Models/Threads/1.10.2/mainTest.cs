namespace CSharpCore.Models.Threads._1._10._2
{
    public class MainTest
    {
        public static void Test(CounterBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Increment();
                c.Decrement();
            }
        }
    }
}
