using OwinSelfHostDemo.TopSelfclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.HostConfigurators;

namespace OwinSelfHostDemo.TopShelfClasses
{
    public class TopShelfConfigure
    {
        public static void Config1() {
            #region TopShelf
            Action<HostConfigurator> configureCallback = x => {
                x.Service<TownCrier>(s => {
                    s.ConstructUsing(name => new TownCrier());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                
                x.SetDescription("Sample Topshelf Host");                   //7
                x.SetDisplayName("OwinSelfHostDemo-SetDisplayName");                                  //8
                x.SetServiceName("OwinSelfHostDemo-SetServiceName");                                  //9

            };
            var rc = HostFactory.Run(configureCallback);
            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
            #endregion
        }

        public static void Config2() {
            HostFactory.New(x =>
            {
                //x.Service<MyService>(hostSettings=>new MyService(hostSettings));
                //x.Service<MyService>(() => ObjectFactory.GetInstance<MyService>());
                x.Service<MyService>(sc=> {
                    sc.ConstructUsing(hostSettings => new MyService(hostSettings));
                    sc.WhenStarted(myService => { myService.MyStart(); });
                    sc.WhenStopped(myService => { myService.MyStop(); });
                    sc.WhenPaused(myService => { myService.WhenPaused(); });
                    sc.WhenContinued(myService => { myService.WhenContinued(); });
                    sc.WhenShutdown(myService => { myService.WhenShutdown(); });

                    sc.WhenStarted((s, hostControl) => s.Start(hostControl));
                    
                });

                x.StartAutomatically(); // Start the service automatically
                x.StartAutomaticallyDelayed(); // Automatic (Delayed) -- only available on .NET 4.0 or later
                x.StartManually(); // Start the service manually
                x.Disabled(); // install the service as disabled

                x.EnableServiceRecovery(serviceRecoveryConfigurator=> {
                    //you can have up to three of these
                    serviceRecoveryConfigurator.RestartComputer(5, "message");
                    serviceRecoveryConfigurator.RestartService(0);
                    //the last one will act for all subsequent failures
                    serviceRecoveryConfigurator.RunProgram(7, "ping google.com");

                    //should this be true for crashed or non-zero exits
                    serviceRecoveryConfigurator.OnCrashOnly();

                    //number of days until the error count resets
                    serviceRecoveryConfigurator.SetResetPeriod(1);
                });

                x.RunAs("username", "password");
                x.RunAsPrompt();
                x.RunAsNetworkService();
                x.RunAsLocalSystem();
                x.RunAsLocalService();

                x.BeforeInstall(() => {
                    Console.WriteLine("BeforeInstall");
                });
                x.AfterInstall(() => {
                    Console.WriteLine("AfterInstall");
                });
                x.AfterUninstall(() => {
                    Console.WriteLine("AfterUninstall");
                });

                x.DependsOn("SomeOtherService");
                x.DependsOnMsmq(); // Microsoft Message Queueing
                x.DependsOnMsSql(); // Microsoft SQL Server
                x.DependsOnEventLog(); // Windows Event Log
                x.DependsOnIis(); // Internet Information Server

                x.EnablePauseAndContinue();
                x.EnableShutdown();
                x.OnException(ex =>
                {
                    // Do something with the exception
                });

                x.EnableServiceRecovery(rc =>
                {
                    rc.RestartService(1); // restart the service after 1 minute
                    //rc.RestartSystem(1, "System is restarting!"); // restart the system after 1 minute
                    rc.RunProgram(1, "notepad.exe"); // run a program
                    rc.SetResetPeriod(1); // set the reset interval to one day
                });

            });
        }
    }
}
