using CSharpCore.Models;
using System.Reflection;
using System.Reflection.Emit;

namespace CSharpCore
{
    public class Program
    {
        public delegate int GetNumber(int x);

        static void Main()
        {
            //RestProxyCreator.BuildAssembly();
            var dllName = "MyDynamic";
            var title = "This is a dynamic title.";
            AssemblyName assemblyName = new AssemblyName(dllName)
            {
                Version = new Version("3.0.0.0")
            };
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DefineDynamicModule");
            moduleBuilder.DefineEnum("DefineEnum", TypeAttributes.Public, typeof(int));
        }

    }
}