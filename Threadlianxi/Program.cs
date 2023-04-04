using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threadlianxi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine($"MainThreadcId is :{Thread.CurrentThread.ManagedThreadId}");

            ITest test=new Test();
            test.Add();
            //#region AwaitDemo0
            //new AwaitDemo0().M();
            //#endregion

            //#region BarrierDemo
            //new BarrierDemo().M();
            //#endregion
            
            //#region CountdownEventDemo
            //new CountdownEventDemo().M();
            //#endregion

            //#region SemaphoreSlimDemo
            //new SemaphoreSlimDemo().M();
            //#endregion

            //#region ExceptionDemo
            //new ExceptionDemo().M();
            //#endregion

            //#region LockerDemo
            //LockerDemo.M();
            //#endregion
            Console.WriteLine("=======================================================================");
            ThreadPool.QueueUserWorkItem((state) =>
            {
                //Console.WriteLine(1);
            });
            #region 1
            //ThreadDemo.main();
            #endregion
        }
    }
}
