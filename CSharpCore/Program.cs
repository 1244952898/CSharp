using CSharpCore.Models;
using CSharpCore.Models.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace CSharpCore
{
    public class Program
    {
        public delegate int GetNumber(int x);

        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                Console.WriteLine(1);
            });

            var t = ThreadPool.QueueUserWorkItem((x) =>{ });


            List<StandardProcedureClass> lst = [];
            lst.Add(new StandardProcedureClass { Value="1", Label="1", Label_zc="1"});
            lst.Add(new StandardProcedureClass { Value="2", Label="2", Label_zc="2"});
            lst.Add(new StandardProcedureClass { Value="2", Label="22", Label_zc="22"});
            lst.Add(new StandardProcedureClass { Value="3", Label="3", Label_zc="3"});

            var grpLst=lst.GroupBy(x => x.Value).ToList();
            foreach(var grp in grpLst)
            {
                var ct= grp.Count();
                for (int i = 0; i < ct; i++)
                {
                }
                foreach (var g in grp)
                {

                }
            }

            var taskList=new List<Task>();
            var dataList=new ConcurrentQueue<int>();
            for (int i = 0; i < 200; i++)
            {
                int k = i;
                taskList.Add(Task.Run(() =>
                {
                    dataList.Enqueue(k);
                }));
            }
           var dataList1= dataList.Order().ToArray();
            Task.WaitAll([.. taskList]);
            Console.WriteLine($"{dataList1.Length}");
            Console.WriteLine($"{string.Join(",", dataList1)}");

            #region 1

            MainEndpoint(args);

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
            //var config = new ConfigurationBuilder()
            //   .AddJsonFile(@"Models\HttpFiles\appsettings.json", true, true)
            //   .Build();

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
        #endregion
    }
}