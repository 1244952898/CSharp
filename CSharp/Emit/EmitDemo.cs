using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Emit
{
    public class EmitDemo
    {
        public static void Create()
        {
            var dllName = "MyDynamic";
            var title = "This is a dynamic title.";
            AssemblyName assemblyName = new AssemblyName(dllName)
            {
                Version = new Version("3.0.0.0")
            };

            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);

            var assemblyTitleType = typeof(AssemblyTitleAttribute).GetConstructor(new Type[] { typeof(string) });
            var titleAttr = new CustomAttributeBuilder(assemblyTitleType, new object[] { title });
            assemblyBuilder.SetCustomAttribute(titleAttr);
            assemblyBuilder.DefineVersionInfoResource();
            assemblyBuilder.Save($"{dllName}.dll");
            Console.WriteLine("已生成静态程序集");
        }
    }
}
