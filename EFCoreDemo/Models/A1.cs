namespace EFCoreDemo.Models
{
    public class A1 : IA
    {
        public void Test()
        {
            Console.WriteLine($"{GetType().Name} is run");
        }
    }
}
