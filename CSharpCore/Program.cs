namespace CSharpCore
{
    public class Program
    {
        static void Main()
        {
            var ac = new Lazy<AutoLock>();
            var al = ac.Value;
        }
    }
}