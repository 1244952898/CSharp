using CSharpCore.Models;
using CSharpCore.Models.Logger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CSharpCore
{
    public class Program
    {
        public delegate int GetNumber(int x);

        static void Main(string[] args)
        {
            for (var dateTime = new DateTime(2024, 7, 15); dateTime <= DateTime.Now; dateTime = dateTime.AddDays(1))
            {
                dateTime.AddDays(-1);
            }
            MyPermission myPermission = MyPermission.Select | MyPermission.Delete | MyPermission.Edit;
            var mpInt = (int)myPermission;
            var mpStr = myPermission.ToString();
            var asdS = myPermission.HasFlag(MyPermission.Delete);
            var asdS1 = myPermission.HasFlag(MyPermission.Add);
            var asdS2 = myPermission & MyPermission.Add;
            Console.WriteLine((int)MySourceLevels.Error);
            var sql = MyTags.MSSql;

            MainLogger2(args);

            //MainConfig(args);

            #region 1

            //Host
            //    .CreateDefaultBuilder()
            //    .ConfigureWebHostDefaults(builder => builder
            //    .Configure(app => app.UsePathBase("/files")
            //    .UseMiddleware<FileProviderMiddleware>(@"c:\test")))
            //    .Build()
            //    .Run();


            //RestProxyCreator.BuildAssembly();
            //var dllName = "MyDynamic";
            //var title = "This is a dynamic title.";
            //AssemblyName assemblyName = new AssemblyName(dllName)
            //{
            //    Version = new Version("3.0.0.0")
            //};
            //var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            //ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DefineDynamicModule");
            //moduleBuilder.DefineEnum("DefineEnum", TypeAttributes.Public, typeof(int));

            //static void Print(int layer, string name) => Console.WriteLine($"{new string(' ', layer * 4)}{name}");
            //var fileManager = new ServiceCollection()
            //    .AddSingleton<IFileProvider>(new PhysicalFileProvider(@"c:\test"))
            //    .AddSingleton<IFileManager, FileManager>()
            //    .BuildServiceProvider()
            //    .GetService<IFileManager>();

            //fileManager.ShowStructor(Print);
            //var txt = fileManager.ReadAllTextAsync("data.txt").GetAwaiter().GetResult();

            //var assemble = Assembly.GetEntryAssembly();
            //var fileManager1 = new ServiceCollection()
            //    .AddSingleton<IFileProvider>(new EmbeddedFileProvider(assemble))
            //    .AddSingleton<IFileManager, FileManager>()
            //    .BuildServiceProvider()
            //    .GetService<IFileManager>();
            //var txt = fileManager1.ReadAllTextAsync("data.txt").GetAwaiter().GetResult();

            //using PhysicalFileProvider fileProvider = new(@"C:\test");
            //string original = string.Empty;
            //ChangeToken.OnChange(() => fileProvider.Watch("data.txt"), Callback);
            //while (true)
            //{
            //    File.WriteAllText(@"C:\test\data.txt", DateTime.Now.ToString());
            //    await Task.Delay(5000);
            //}
            //async void Callback()
            //{
            //    using var stream = fileProvider.GetFileInfo("data.txt").CreateReadStream();
            //    var buffer = new byte[stream.Length];
            //    await stream.ReadAsync(buffer);
            //    var content = Encoding.Default.GetString(buffer);
            //    if (content != original)
            //    {
            //        Console.WriteLine($"content:{content} {original == content}");
            //    }
            //}

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
    }
}