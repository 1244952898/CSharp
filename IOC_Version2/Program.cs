using IOC_Version2.IService;
using IOC_Version2.Service;
using MyIOC_Common_Version2;
using MyIOCDI.Service;
using System;

namespace IOC_Version2
{
    class Program
    {
        static void Main(string[] args)
        {
           

            {
                IIOCContainer container = new IOCContainer();
                //注册
                container.Register<ITestServiceA, TestServiceA>(); //将ITestServiceA注册到TestServiceA
                container.Register<ITestServiceB, TestServiceB>();
                container.Register<ITestServiceB, TestServiceB>(shortName: "ServiceB");
                container.Register<ITestServiceC, TestServiceC>();
                container.Register<ITestServiceD, TestServiceD>(paraList: new object[] { "浪子天涯", 666 }, lifetimeType: LifetimeTypeEnum.Singleton);

                ITestServiceD d1 = container.Resolve<ITestServiceD>(); //创建对象交给IOC容器
                ITestServiceD d2 = container.Resolve<ITestServiceD>();
                d1.Show();
                Console.WriteLine($"object.ReferenceEquals(d1, d2) = {object.ReferenceEquals(d1, d2)}");
            }

            {

                IIOCContainer container = new IOCContainer();
                container.Register<ITestServiceB, TestServiceB>();
                container.Register<ITestServiceB, TestServiceB>(shortName: "ServiceB");
                container.Register<ITestServiceC, TestServiceC>();
                container.Register<ITestServiceD, TestServiceD>(paraList: new object[] { "浪子天涯", 666 }, lifetimeType: LifetimeTypeEnum.Singleton);

                /*
                生命周期：作用域
                就是Http请求时，一个请求处理过程中，创建都是同一个实例；不同的请求处理过程中，就是不同的实例；
                得区分请求，Http请求---Asp.NetCore内置Kestrel，初始化一个容器实例；然后每次来一个Http请求，就clone一个，
                或者叫创建子容器(包含注册关系)，然后一个请求就一个子容器实例，那么就可以做到请求单例了(其实就是子容器单例)
                主要可以去做DbContext  Repository
                 */
                container.Register<ITestServiceA, TestServiceA>(lifetimeType: LifetimeTypeEnum.Scope);
                ITestServiceA a1 = container.Resolve<ITestServiceA>();
                ITestServiceA a2 = container.Resolve<ITestServiceA>();
                Console.WriteLine(object.ReferenceEquals(a1, a2)); //T

                IIOCContainer container1 = container.CreateChildContainer();
                ITestServiceA a11 = container1.Resolve<ITestServiceA>();
                ITestServiceA a12 = container1.Resolve<ITestServiceA>();

                IIOCContainer container2 = container.CreateChildContainer();
                ITestServiceA a21 = container2.Resolve<ITestServiceA>();
                ITestServiceA a22 = container2.Resolve<ITestServiceA>();

                Console.WriteLine(object.ReferenceEquals(a11, a12)); //T
                Console.WriteLine(object.ReferenceEquals(a21, a22)); //T

                Console.WriteLine(object.ReferenceEquals(a11, a21)); //F
                Console.WriteLine(object.ReferenceEquals(a11, a22)); //F
                Console.WriteLine(object.ReferenceEquals(a12, a21)); //F
                Console.WriteLine(object.ReferenceEquals(a12, a22)); //F

                ITestServiceD d1 = container.Resolve<ITestServiceD>();
                ITestServiceD d11 = container1.Resolve<ITestServiceD>();
                Console.WriteLine(object.ReferenceEquals(d1, d11)); //T
            }

        }
    }
}
