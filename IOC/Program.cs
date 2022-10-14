
using BLL;
using Castle.DynamicProxy;
using Factory;
using IBLL;
using Microsoft.Extensions.DependencyInjection;
using MyIOC_Common;
using System;

namespace IOC
{
    class Program
    {
        static void Main(string[] args)
        {
            //IStudent student = SimpleFactory.CreateStudent();
            //student.Study();
            ////var p =new iPhone();
            ////student.PlayPhone(p);
            //Action<int> ac;
            //Console.WriteLine("Hello World!");
            //{
            //    IServiceCollection services = new ServiceCollection();
            //    services.AddTransient<IMicrophone, Microphone>();
            //    var provider = services.

            //}

            {
                //IMyServiceCollection myServiceCollection = new MyServiceCollection();
                //myServiceCollection.AddTransient<IHeadphone, Headphone>();
                //myServiceCollection.AddTransient<IMicrophone, Microphone>();
                //myServiceCollection.AddTransient<IServiceA, ServiceA>();
                //myServiceCollection.AddTransient<IServiceB, ServiceB>();
                //myServiceCollection.AddTransient<IServiceC, ServiceC>();

                ////var headphone = myServiceCollection.GetService<IHeadphone>();
                //Microphone microphone = (Microphone)myServiceCollection.GetService<IMicrophone>();
            }

            {
                //ProxyGenerator proxyGenerator = new ProxyGenerator();
                //InterceptorExtend interceptorExtend = new InterceptorExtend();

                //Student st = proxyGenerator.CreateClassProxy<Student>(interceptorExtend);
                //st.VirtualMethod();
                //st.Method();
            }

            {
                IMyServiceCollection myServiceCollection = new MyServiceCollection();
                myServiceCollection.AddTransient<IStudent, Student>();
                var st = myServiceCollection.GetService<IStudent>();
                st.VirtualMethod();
                st.Method();
            }
        }
    }
}
