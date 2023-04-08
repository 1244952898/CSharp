namespace WebApplicationCore
{
    public interface IHelloWorld
    {
        string GetStr();
    }

    public class HelloWorld : IHelloWorld
    {
        public string GetStr()
        {
            return "Welcom";
        }
    }

}