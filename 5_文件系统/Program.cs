// See https://aka.ms/new-console-template for more information

using _5_文件系统;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
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
var source = new Dictionary<string, string>
{
    ["LongDatePattern"] = "dddd, MMMM, d yyyy",
    ["LongTimePattern"] = "h:mm:ss tt",
    ["ShortDatePattern"] = "M/d/yyyy",
    ["ShortTimePattern"] = "h:mm:tt"
};


var confg = new ConfigurationBuilder()
    //.AddJsonFile(@"Models\HttpFiles\appsettings.json", true, true)
    .Add(new MemoryConfigurationSource { InitialData = source })
    .Build();
var option = new DateTimeFormatOptions(confg);
Console.WriteLine(option.LongTimePattern);
Console.WriteLine(option.LongDatePattern);
Console.WriteLine(option.ShortDatePattern);
Console.WriteLine(option.ShortTimePattern);

#endregion