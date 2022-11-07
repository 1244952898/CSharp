using System;

using IOC_Version2.IService;

namespace IOC_Version2.Service
{
    public class TestServiceB : ITestServiceB
    {
        public TestServiceB()
        {
            Console.WriteLine($"{this.GetType().Name}被构造。。。");
        }

        public void Show()
        {
            Console.WriteLine($"This is {this.GetType().Name} Show");
        }
    }
}
