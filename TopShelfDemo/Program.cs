using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;

namespace TopShelfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region demo1
            //var rc = HostFactory.Run(x =>
            //{
            //    x.Service<TownCrier>(s =>
            //    {
            //        s.ConstructUsing(name => new TownCrier());
            //        s.WhenStarted(tc => tc.Start());
            //        s.WhenStopped(tc => tc.Stop());
            //    });

            //    x.RunAsLocalSystem();
            //    x.SetDescription("SetDescription:Sample Topshelf Host");
            //    x.SetDisplayName("DisplayName:Stuff");                                  //8
            //    x.SetServiceName("ServiceName:Stuff");                                  //9

            //    x.EnableServiceRecovery(r =>
            //    {
            //        r.OnCrashOnly();
            //        r.RestartService(1);
            //    });
            //});
            //var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  //11
            //Environment.ExitCode = exitCode;
            #endregion
            #region demo2
            var rc = HostFactory.New(x=> {
                //使用appdomain获取当前应用程序集的执行目录
                //C:\\Users\\zhuangyu\\source\\repos\\CSharp\\TopShelfDemo\\bin\\Debug\\config\\Log4net.xml
                //C: \Users\zhuangyu\source\repos\CSharp\TopShelfDemo\bin\Debug
               // string dir = AppDomain.CurrentDomain.BaseDirectory;
               var dir = Path.GetFullPath("../..") + "\\config\\Log4net.xml";
                x.UseLog4Net(dir);

                x.SetDescription("AAAAAAAAAAAAAAAAAAAAAA--Description");
                x.SetDisplayName("AAAAAAAAAAAAAAAAAAAAAA--DisplayName");                                  //8
                x.SetServiceName("AAAAAAAAAAAAAAAAAAAAAA--ServiceName");                                  //9

                x.BeforeInstall(settings => { Console.WriteLine($"====BeforeInstall:{settings.DisplayName}==="); });
                x.AfterInstall(settings => { Console.WriteLine($"====AfterInstall:{settings.DisplayName}==="); });
                x.BeforeUninstall(() => { Console.WriteLine($"====BeforeUninstall==="); });
                x.AfterUninstall(() => { Console.WriteLine($"====AfterUninstall==="); });

                x.Service<MyService>(sc => {
                sc.ConstructUsing(c => { return new MyService(new DependDemo()); });
                sc.WhenStarted((myservice, hostControl) => { return myservice.Start(hostControl); });
                sc.WhenStopped((myservice, hostControl) => { return myservice.Stop(hostControl); });
                sc.WhenPaused(wp => wp.Paused());
                sc.WhenContinued(s => s.Continue());
                sc.WhenShutdown(s => s.Shutdown());
                });

                //x.StartAutomaticallyDelayed();

                x.EnableServiceRecovery(r =>
                {
                    ////you can have up to three of these
                    //r.RestartComputer(5, "message");
                    r.RestartService(0);
                    ////the last one will act for all subsequent failures
                    //r.RunProgram(7, "ping google.com");

                    //should this be true for crashed or non-zero exits
                    r.OnCrashOnly();
                    //number of days until the error count resets
                    r.SetResetPeriod(1);
                });

                x.RunAsLocalSystem();
            });
            try
            {
                rc.Run();
            }
            catch (Exception ex)
            {

                throw;
            }
         
            #endregion
        }
    }

    class MyService : ServiceControl
    {
        LogWriter _log;
        public MyService(DependDemo dependDemo)
        {
            _log = HostLogger.Get<MyService>();
        }

        public bool Start(HostControl hostControl)
        {
            int i = 0;
            Console.WriteLine($"=====================Start:{hostControl.ToString()}=====================");
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"=====================while{++i}=====================");
            }
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Console.WriteLine($"=====================Stop:{hostControl.ToString()}=====================");
            return true;
        }
        public void Paused()
        {
            Console.WriteLine($"=====================Paused=====================");
        }
        public void Continue()
        {
            Console.WriteLine($"=====================Continue=====================");
        }
        public void Shutdown()
        {
            Console.WriteLine($"=====================Shutdown=====================");
        }
    }
    

    class DependDemo
    {
        public DependDemo()
        {
            Console.WriteLine("=====================DependDemo=====================");
        }
    }
}
