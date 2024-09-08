namespace CSharpCore.Models
{
    public class PatternGame
    {
        private static string[] patternNames;
        static PatternGame()
        {
            patternNames =
            [
                  "工厂模式(Factory)",
                  "原型模式(Prototype)",
                  "单例模式(Singleton)",
                  "建造者模式(Builder)",
                  "抽象工厂(Abstract Factory)",
                  "享元模式(flyweight)",
                  "外观模式(Facade)",
                  "组合模式(Composite)",
                  "适配器模式(Adapter)",
                  "代理模式(Proxy)",
                  "装饰器模式(Decorator)",
                  "桥接模式(Bridge)",
                  "状态模式(State)",
                  "责任链模式(Chain of Responsibility)",
                  "中介者模式(Mediator)",
                  "备忘录模式(Momento)",
            ];
        }

        public static void Run()
        {
            var random = new Random();
            while (true)
            {
                Console.ReadKey();
                var i = random.Next(0, patternNames.Length);
                Console.WriteLine(patternNames[i]);
            }
        }
    }
}
