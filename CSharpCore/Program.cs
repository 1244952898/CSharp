using CSharpCore.Models.HttpFiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace CSharpCore
{
    public class Program
    {
        public delegate int GetNumber(int x);

        static async Task Main()
        {
            Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(builder => builder
                .Configure(app => app.UsePathBase("/files")
                .UseMiddleware<FileProviderMiddleware>(@"c:\test")))
                .Build()
                .Run();


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

            using PhysicalFileProvider fileProvider = new(@"C:\test");
            string original = string.Empty;
            ChangeToken.OnChange(() => fileProvider.Watch("data.txt"), Callback);
            while (true)
            {
                File.WriteAllText(@"C:\test\data.txt", DateTime.Now.ToString());
                await Task.Delay(5000);
            }
            async void Callback()
            {
                using var stream = fileProvider.GetFileInfo("data.txt").CreateReadStream();
                var buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer);
                var content = Encoding.Default.GetString(buffer);
                if (content != original)
                {
                    Console.WriteLine($"content:{content} {original == content}");
                }
            }
        }

    }
}