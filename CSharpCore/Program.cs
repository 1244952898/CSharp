using CSharpCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace CSharpCore
{
    public class Program
    {
        public delegate int GetNumber(int x);

        static void Main()
        {
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

            var assemble = Assembly.GetEntryAssembly();
            var fileManager1 = new ServiceCollection()
                .AddSingleton<IFileProvider>(new EmbeddedFileProvider(assemble))
                .AddSingleton<IFileManager, FileManager>()
                .BuildServiceProvider()
                .GetService<IFileManager>();
            var txt = fileManager1.ReadAllTextAsync("data.txt").GetAwaiter().GetResult();
        }

    }
}