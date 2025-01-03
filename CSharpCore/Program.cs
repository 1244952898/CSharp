﻿using CSharpCore.Models;
using CSharpCore.Models.Endpoints;
using CSharpCore.Models.Threads._1._10._2;
using CSharpCore.Models.Threads._2._2._2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace CSharpCore
{
    public class Program
    {
        public delegate int GetNumber(int x);

        static async Task Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            CountdownEventThread(args);
            List<string> lst = ["a","b"];
            var l1=lst.Where(lst=>lst.Contains("a")).ToList().Max();
            SynchronizationContext context = SynchronizationContext.Current;
            try
            {
                var b = 2323;
                if (b > 0)
                {
                    return;
                }
            }
            finally
            {
                int a = 11;
            }
            var res= await Task.FromResult(1);
            using (var httpClient =new HttpClient())
            {
                Task<string> task = httpClient.GetStringAsync("https://devblogs.microsoft.com/dotnet/");
            }
            ConcurrentQueue<string> cq = new();
            cq.Enqueue("a");
            cq.Enqueue("b");

            ThreadPool.QueueUserWorkItem(x =>
            {
                Console.WriteLine(x);
            });
            //string a = "aaa";
            //Person p = a;
            //Person p2=new("aaa",3);
            //double a2 = p2;
            PatternGame.Run();
            #region 1

            AutoResetEventThread(args);
            //Person p3 = (Person)a2;
            //string a3 = (string)p2;

            //var ens = Environment.GetEnvironmentVariables();
            //var l1 = new List<string> { "a", "b" };
            //var l2 = new List<string> { "c", "b" };
            //l1.AddRange(l2);
            //l1.Sort(ConfigurationKeyComparer.Instance);
            //MainConfig(args);

            // "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MyApp;Trusted_Connection=True;"
            #endregion
        }

        static void MainConfig(string[] args)
        {
            #region 1

            //var source = new Dictionary<string, string>
            //{
            //    ["LongDatePattern"] = "dddd, MMMM, d yyyy",
            //    ["LongTimePattern"] = "h:mm:ss tt",
            //    ["ShortDatePattern"] = "M/d/yyyy",
            //    ["ShortTimePattern"] = "h:mm:tt"
            //};

            //var confg=new ConfigurationBuilder()
            //    .Add(new MemoryConfigurationSource { InitialData= source })
            //    .Build();
            //var option = new DateTimeFormatOptions(confg);
            //Console.WriteLine(option.LongTimePattern);
            //Console.WriteLine(option.LongDatePattern);
            //Console.WriteLine(option.ShortDatePattern);
            //Console.WriteLine(option.ShortTimePattern);
            #endregion

            #region 2

            //var source = new Dictionary<string, string>
            //{
            //    ["format:dateTime:longDatePattern"] = "dddd, MMMM, d yyyy",
            //    ["format:dateTime:longTimePattern"] = "h:mm:ss tt",
            //    ["format:dateTime:shortDatePattern"] = "M/d/yyyy",
            //    ["format:dateTime:shortTimePattern"] = "h:mm:tt",
            //    ["format:currentDecimal:digits"] = "2",
            //    ["format:currentDecimal:symbol"] = "$"
            //};

            //var options = new ConfigurationBuilder()
            //    .Add(new MemoryConfigurationSource() { InitialData = source })
            //    .Build()
            //    .GetSection("Format")
            //    .Get<FormatOptions>();
            ////var options = new FormatOptions(cfg.GetSection("format"));
            //var dt=options.DateTime;
            //var cd=options.CurrentDecimal;
            //Console.WriteLine(dt.LongTimePattern);
            //Console.WriteLine(dt.LongDatePattern);
            //Console.WriteLine(dt.ShortDatePattern);
            //Console.WriteLine(dt.ShortTimePattern);
            //Console.WriteLine(cd.Digits);
            //Console.WriteLine(cd.Symbol);
            #endregion

            #region 3

            //            var index = Array.IndexOf(args, "/env");
            //            var environment = index > -1 ? args[index+1] : "Development";

            //#if DEBUG_TEST
            //            environment = "Debug_test";
            //#endif

            //var options = new ConfigurationBuilder()
            //    .AddJsonFile($"Models/HttpFiles/appsettings.json")
            //    .AddJsonFile($"Models/HttpFiles/appsettings.{environment}.json")
            //    .Build().GetSection("Format")
            //    .Get<FormatOptions>();
            //var dt = options.DateTime;
            //var cd = options.CurrentDecimal;
            //Console.WriteLine(dt.LongTimePattern);
            //Console.WriteLine(dt.LongDatePattern);
            //Console.WriteLine(dt.ShortDatePattern);
            //Console.WriteLine(dt.ShortTimePattern);
            //Console.WriteLine(cd.Digits);
            //Console.WriteLine(cd.Symbol);
            #endregion

            #region 4
            var config = new ConfigurationBuilder()
               .AddJsonFile(@"Models\HttpFiles\appsettings.json", true, true)
               .Build();

            //ChangeToken.OnChange(() => config.GetReloadToken(), () =>
            //{
            //    var options = config.GetSection("format").Get<FormatOptions>();
            //    var dt = options.DateTime;
            //    var cd = options.CurrentDecimal;
            //    Console.WriteLine(dt.LongTimePattern);
            //    Console.WriteLine(dt.LongDatePattern);
            //    Console.WriteLine(dt.ShortDatePattern);
            //    Console.WriteLine(dt.ShortTimePattern);
            //    Console.WriteLine(cd.Digits);
            //    Console.WriteLine(cd.Symbol);
            //});
            //Console.Read();
            #endregion

            #region 5

            var configSource = new Dictionary<string, string>
            {
                ["point"] = "(134,432)"
            };
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(configSource)
                .Build();
            var point = config.GetValue<Point>("point");
            Console.WriteLine(point);

            #endregion
        }

        static void MainLogger(string[] args)
        {
            #region 1
            //Debugger.Log(1, "test", "ttttttttt");
            //Debug.WriteLine("dddd");

            //var source = new TraceSource("Foo", SourceLevels.All);
            //var eventTypes = Enum.GetValues(typeof(TraceEventType));
            ////var eventTypes = (TraceEventType[])Enum.GetValues(typeof(TraceEventType));
            //int i = 0;
            //foreach (var eventType in eventTypes)
            //{
            //    var eventTypeEnum = (TraceEventType)eventType;
            //    source.TraceEvent(eventTypeEnum, i++, $"This is a {eventTypeEnum} message.");
            //}
            #endregion

            #region 2
            //var source = new TraceSource("Foo", SourceLevels.All);
            //source.Listeners.Add(new ConsoleTraceListener());
            //var eventType = (TraceEventType[])Enum.GetValues(typeof(TraceEventType));
            //int i = 0;
            //foreach (var et in eventType)
            //{
            //    source.TraceEvent(et, i++, $"This is a {et} message.");
            //}
            #endregion

            #region 3
            //var ls = new DatabaseSourceEventListener();
            //DataSource.Instance.OnEventCommand(CommandType.Text, " SELECT * FROM T_USER ");
            #endregion

            #region 4
            //DiagnosticListener.AllListeners.Subscribe(new Observer<DiagnosticListener>(listener =>
            //{
            //    if (listener.Name == "Arrach-Data-SqlClient")
            //    {
            //        listener.Subscribe(new Observer<KeyValuePair<string, object>>(eventData =>
            //        {
            //            Console.WriteLine($"Event Name: {eventData.Key}");
            //            dynamic payload = eventData.Value;
            //            Console.WriteLine($"Command Type:{payload.CommandType}");
            //            Console.WriteLine($"Command Text:{payload.CommandText}");
            //        }));
            //    }
            //}));
            //var source = new DiagnosticListener("Arrach-Data-SqlClient");
            //if (source.IsEnabled("CommandExecution"))
            //{
            //    source.Write($"CommandExecution", new
            //    {
            //        CommandType = CommandType.Text,
            //        CommandText = "SELECT * FROM T_USER"
            //    });
            //}
            #endregion

            #region 5

            //DiagnosticListener.AllListeners.Subscribe(new Observer<DiagnosticListener>(listener =>
            //{
            //    if (listener.Name == "Arrach-Data-SqlClient")
            //    {
            //        listener.SubscribeWithAdapter(new DatabaseSourceConllector());
            //    }
            //}));
            //var source = new DiagnosticListener("Arrach-Data-SqlClient");
            //if (source.IsEnabled("CommandExecution"))
            //{
            //    source.Write($"CommandExecution", new
            //    {
            //        CommandType = CommandType.Text,
            //        CommandText = "SELECT * FROM T_USER"
            //    });
            //}

            #endregion

            #region 6

            //Debugger.Break();
            //if (!Debugger.IsAttached)
            //{
            //    Debugger.Launch();
            //}
            //Debug.Assert(Debugger.IsAttached);

            #endregion
        }

        static void MainLogger2(string[] args)
        {
            #region 0

            var logger = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConsole();
                    builder.AddDebug();
                })
                .BuildServiceProvider()
                //.GetRequiredService<ILoggerFactory>()
                //.CreateLogger("app.main");
                .GetRequiredService<ILogger<Program>>();
            var loglevels0 = ((LogLevel[])Enum.GetValues(typeof(LogLevel))).Where(x => x != LogLevel.None).ToArray();
            var loglevels = Enum.GetValues<LogLevel>().Where(x => x != LogLevel.None).ToArray();
            var eventId = 1;
            Array.ForEach(loglevels, level =>
            {
                logger.Log(level, eventId++, "This is a/an {0} message.", level);
            });

            #endregion
        }

        #region Endpoints

        public static Dictionary<string, string> _cities = new()
        {
            ["010"] = "北京",
            ["028"] = "成都",
            ["0512"] = "苏州",
        };

        static void MainEndpoint(string[] args)
        {
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .ConfigureServices(svcs =>
                    {
                        svcs.AddRouting();
                    })
                    .Configure(app =>
                    {
                        app
                        .UseRouting()
                        .UseEndpoints(endpoints =>
                        {
                            endpoints.MapGet("weather/{city=010}/{days=4}", WeatherForcast);
                        });
                    });
                })
                .Build()
                .Run();
        }

        static async Task WeatherForcast(HttpContext httpContext)
        {
            var routes = httpContext.GetRouteData().Values;
            var city = routes.TryGetValue("city", out var ct) ? (string)ct : "0512";
            city = _cities[city];
            var days = routes.TryGetValue("days", out var dy) ? int.Parse(dy.ToString()) : 4;
            var report = new WeatherReport(city, days);
            await RendWeatherAsync(httpContext, report);
        }

        private static async Task RendWeatherAsync(HttpContext context, WeatherReport weatherReport)
        {
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync($"<html><head><title>Weather</title></head><body>");
            await context.Response.WriteAsync($"<h3>{weatherReport.City}</h3>");
            foreach (var weatherInfo in weatherReport.WeatherInfos)
            {
                await context.Response.WriteAsync(weatherInfo.Key.ToString("yyyy-MM-dd HH:mm:ss"));
                await context.Response.WriteAsync($"{weatherInfo.Value.Condition}({weatherInfo.Value.LowTemperature}℃ ~ {weatherInfo.Value.HighTemperature}℃)<br/><br/>");
            }
            await context.Response.WriteAsync($"</body></html>");
        }

        static void MainThread(string[] args)
        {
            Console.WriteLine("Corrent Count");
            var c = new Counter();

            var t1 = new Thread(() => { MainTest.Test(c); });
            var t2 = new Thread(() => { MainTest.Test(c); });
            var t3 = new Thread(() => { MainTest.Test(c); });

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine($"Total Count: {c.Count}");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Incorrent Count");
            var c1 = new CounteWithLocks();

            t1 = new Thread(() => { MainTest.Test(c1); });
            t2 = new Thread(() => { MainTest.Test(c1); });
            t3 = new Thread(() => { MainTest.Test(c1); });

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine($"Total Count: {c1.Count}");
        }

        static void MainThread1(string[] args)
        {
            object lock1 = new object();
            object lock2 = new object();

            new Thread(() => LockTooMuch(lock1, lock2)).Start();

            lock (lock2)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Monitir.TryEnter allow ");
                if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(5)))
                {
                    Console.WriteLine($"Acquired a protected resource successfully");
                }
                else
                {
                    Console.WriteLine($"Timeout acquiring a resource");
                }
            }

            new Thread(() => LockTooMuch(lock1, lock2)).Start();
            Console.WriteLine($"----------------------------------");
            lock (lock2)
            {
                Console.WriteLine($"This is will deadlock ");
                Thread.Sleep(1000);
                lock (lock1)
                {
                    Console.WriteLine($"Acquired a protected resource successfully");
                }
            }
        }

        static void LockTooMuch(object lock1, object lock2)
        {
            lock (lock1)
            {
                Thread.Sleep(1000);
                lock (lock2) { }
            }
        }

        static void MainThread2(string[] args)
        {
            var t = new Thread(FaultyThread);
            t.Start();
            t.Join();

            try
            {
                t = new Thread(BadFaultyThread);
                t.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("We won`t get here!");
            }
            t.Join();
        }

        static void BadFaultyThread()
        {
            Console.WriteLine("Start a faulty thread...");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            throw new Exception("Boom!");
        }

        static void FaultyThread()
        {
            try
            {
                Console.WriteLine("Start a faulty thread1...");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                throw new Exception("Boom1!");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception handled1: {ex.Message}");
            }
        }

        static void MainThread3(string[] args)
        {
            Console.WriteLine("MainThread3");

            var c = new Counter();
            var t1 = new Thread(() => TestCounter.Test(c));
            var t2 = new Thread(() => TestCounter.Test(c));
            var t3 = new Thread(() => TestCounter.Test(c));

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine($"MainThread3 total0: {c.Count}");

            var c1 = new CounterInterLocker();
            t1 = new Thread(() => TestCounter.Test(c1));
            t2 = new Thread(() => TestCounter.Test(c1));
            t3 = new Thread(() => TestCounter.Test(c1));

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine($"MainThread3 total1: {c1.Count}");
        }

        const string MutexName = "CSharpThreadingCookbook";
        static void MutexThread(string[] args)
        {
            using var m = new Mutex(false, MutexName);
            Thread.Sleep(10100);
            if (!m.WaitOne(TimeSpan.FromSeconds(5), false))
            {
                Console.WriteLine("Second instance is running.");
            }
            else
            {
                Console.WriteLine("Running.");
                Console.ReadLine();
                m.ReleaseMutex();
            }
        }


        static SemaphoreSlim semaphoreSlim = new(1);
        static void AccessDatabase(string name, int seconds, bool isRelease = false)
        {
            Console.WriteLine($"{name} waits to access a database");
            if (isRelease)
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
                semaphoreSlim.Release();
            }
            semaphoreSlim.Wait();
            Console.WriteLine($"{name} was running");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine($"{name} was complete");
            semaphoreSlim.Release();
        }
        static void SemaphoreSlimThread(string[] args)
        {
            var t = new Thread(() =>
            {
                AccessDatabase("threadName", 100);
            });
            var t1 = new Thread(() =>
            {
                AccessDatabase("threadName1", 100);
            });
            var t2 = new Thread(() =>
            {
                AccessDatabase("threadName2", 100, true);
            });
            t.Start();
            t1.Start();
            t2.Start();
            //for (int i = 0; i < 7; i++)
            //{
            //    var threadName = $"thread {i}";
            //    int secondWaits = 2 + 2 * i;
            //    var t = new Thread(() =>
            //    {
            //        AccessDatabase(threadName, secondWaits);
            //    });
            //    t.Start();
            //}
        }

        private static AutoResetEvent _workEvent = new(false);
        private static AutoResetEvent _mainEvent = new(false);
        static void Process(int seconds)
        {
            Console.WriteLine($"Start a long running work");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine("Working is done");
            _workEvent.Set();
            Console.WriteLine($"Waiting for a main thread to complete its work");
            _mainEvent.WaitOne();
            Console.WriteLine($"Starting second operation...");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine($"Work is done.");
            _workEvent.Set();
        }
        static void AutoResetEventThread(string[] args)
        {
            var t = new Thread(() =>
            {
                Process(10);
            });
            t.Start();
            Console.WriteLine($"Waiting for another thread to complete work");
            _workEvent.WaitOne();
            Console.WriteLine($"First operation is completed");
            Console.WriteLine($"Performing an operation on a main thread");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            _mainEvent.Set();
            Console.WriteLine($"Now running the second operation on a second thread");
            _workEvent.WaitOne();
            Console.WriteLine($"Second operation is completed");
        }

        static CountdownEvent _countdown = new CountdownEvent(3);
        static void CountdownEventThread(string[] args)
        {
            new Thread(SaySomething).Start("I am thread 1");
            new Thread(SaySomething).Start("I am thread 2");
            new Thread(SaySomething1).Start("I am thread 3");

            _countdown.Wait();   // Blocks until Signal has been called 3 times
            Console.WriteLine("All threads have finished speaking!");
        }

        static void SaySomething(object thing)
        {
            Thread.Sleep(1000);
            Console.WriteLine(thing);
            _countdown.Signal();
        }
        static void SaySomething1(object thing)
        {
            Thread.Sleep(11000);
            Console.WriteLine(thing);
            _countdown.Signal();
        }
        #endregion

    }
}