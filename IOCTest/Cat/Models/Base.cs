namespace IOCTest.Cat.Models
{
    public class Base : IDisposable
    {
        public Base() => Console.WriteLine($"{GetType().Name} is Create");
        public void Dispose() => Console.WriteLine($"{GetType().Name} is Dispose");
    }
}
