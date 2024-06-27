using CSharpCore.Models.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace CSharpCore
{
    public class Program
    {
        public delegate int GetNumber(int x);

        static void Main(string[] args)
        {
            MainConfig(args);
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
               .AddJsonFile(@"D:\Projects\CSharp\CSharpCore\bin\Debug\net8.0\Models\HttpFiles\appsettings.json", true, true)
               .Build();

            ChangeToken.OnChange(() => config.GetReloadToken(), () =>
            {
                var options = config.GetSection("format").Get<FormatOptions>();
                var dt = options.DateTime;
                var cd = options.CurrentDecimal;
                Console.WriteLine(dt.LongTimePattern);
                Console.WriteLine(dt.LongDatePattern);
                Console.WriteLine(dt.ShortDatePattern);
                Console.WriteLine(dt.ShortTimePattern);
                Console.WriteLine(cd.Digits);
                Console.WriteLine(cd.Symbol);
            });
            Console.Read();
            #endregion
        }
    }
}