namespace EFCoreDemo.Classes
{
    public class A1 : IA
    {
        public void Test()
        {
            Console.WriteLine($"{this.GetType().Name} is run");
        }
    }
}
