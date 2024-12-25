// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration.Xml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
#region 1
//static void Print(int i, string message) => Console.WriteLine($"{new string(' ', i * 4)}{message}");


//var fm = new ServiceCollection()
//    .AddSingleton<IFileProvider>(new PhysicalFileProvider(@"c:\test"))
//    .AddSingleton<IFileManager, FileManager>()
//    .BuildServiceProvider()
//    .GetRequiredService<IFileManager>();
////.ShowStructure(Print)
//var txt = await fm.ReadAllTextAsync("data.txt");
//Debug.Assert(txt == File.ReadAllText(@"c:\test\data.txt"));
#endregion

#region 2
//var assemble = Assembly.GetEntryAssembly();
//var fm = new ServiceCollection()
//    .AddSingleton<IFileProvider>(new EmbeddedFileProvider(assemble))
//    .AddSingleton<IFileManager, FileManager>()
//    .BuildServiceProvider()
//    .GetRequiredService<IFileManager>();
//var txt = await fm.ReadAllTextAsync("data.txt");

//var stream = assemble.GetManifestResourceStream($"{assemble.GetName().Name}.data.txt");
//var bf = new byte[stream.Length];
//stream.Read(bf, 0, bf.Length);
//var txt2 = Encoding.Default.GetString(bf);

//Console.WriteLine(txt2 == txt);
#endregion

#region 3

//var fileProvdier = new PhysicalFileProvider(@"c:\test");
//string original=null;
//ChangeToken.OnChange(() => fileProvdier.Watch("data.txt"), Callback);

//while (true)
//{
//    File.WriteAllText(@"c:\test\data.txt", DateTime.Now.ToString());
//    await Task.Delay(1000);
//}

//async void Callback()
//{
//    using var stream = fileProvdier.GetFileInfo("data.txt").CreateReadStream();
//    var bf=new byte[stream.Length];
//    stream.Read(bf, 0, bf.Length);
//    string content=Encoding.Default.GetString(bf);
//    if (content!=original)
//    {
//        Console.WriteLine(content);
//    }
//}
#endregion

#region 4
//var source = new Dictionary<string, string>
//{
//    ["LongDatePattern"] = "dddd, MMMM, d yyyy",
//    ["LongTimePattern"] = "h:mm:ss tt",
//    ["ShortDatePattern"] = "M/d/yyyy",
//    ["ShortTimePattern"] = "h:mm:tt"
//};

var asdfsdfsf = new XmlConfigurationSource();
//var confg = new ConfigurationBuilder()
//    //.AddJsonFile(@"Models\HttpFiles\appsettings.json", true, true)
//    .Add(new MemoryConfigurationSource { InitialData = source })
//    .Build();
//var option = new DateTimeFormatOptions(confg);
//Console.WriteLine(option.LongTimePattern);
//Console.WriteLine(option.LongDatePattern);
//Console.WriteLine(option.ShortDatePattern);
//Console.WriteLine(option.ShortTimePattern);
//Environment.SetEnvironmentVariable("a", "b");
//var vars = Environment.GetEnvironmentVariables();

//foreach (var v in vars)
//{
//    Console.WriteLine(v.ToString());
//}
#endregion

#region 5
//TraceSource traceSources=new("Foobar",SourceLevels.Warning);
////traceSources.Listeners
//TraceEventType[] traceEventTypes=(TraceEventType[])Enum.GetValues(typeof(TraceEventType));
//var eventId = 1;
//foreach (var eventType in traceEventTypes)
//{
//    traceSources.TraceEvent(eventType, eventId++,$"this is a {eventType} message");
//}
#endregion

#region 8.2
//if (!Debugger.IsAttached)
//{
//    Debugger.Launch();
//}

//MyEnumMethod myEnum = new();
//myEnum.Test(MyEnumExtend.Sqlserver);
//myEnum.Test(MyEnum.Default);
#endregion

#region MyRegion
//var listener =new PerformanceCounterListener();
//RuntimeEventSource
//listener.EnableEvents()
#endregion

#region 9.1
var logger = new ServiceCollection()
    .AddLogging(builder =>
    {
        builder.AddConsole();
        builder.AddDebug();
        builder.AddFilter((str, str2) =>
        {
            return true;
        });
    })
    .BuildServiceProvider()
    //.GetRequiredService<ILoggerFactory>()
    //.CreateLogger("_5_文件系统.Program");
    .GetRequiredService<ILogger<Program>>();

var levels = (LogLevel[])Enum.GetValues(typeof(LogLevel));
levels = levels.Where(it => it != LogLevel.None).ToArray();
var evenId = -1;
foreach (var level in levels)
{
    logger.Log(level, evenId++, $"This is a/an {level} log message.",level);
    //Console.Read();
}
#endregion