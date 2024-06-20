using System;
using System.Reflection;
using System.Reflection.Emit;

namespace CSharp.Emit
{
    public class EmitDemo
    {
        public static void Create(TestEnum testEnum)
        {
            var dllName = "MyDynamic";
            var title = "This is a dynamic title.";
            AssemblyName assemblyName = new AssemblyName(dllName)
            {
                Version = new Version("3.0.0.0")
            };

            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("DefineDynamicModule", $"{dllName}.dll");

            var enumBuilder = moduleBuilder.DefineEnum("MyNameSpace.MyDefineEnum", TypeAttributes.Public, typeof(int));
            enumBuilder.DefineLiteral("a", 0);
            enumBuilder.DefineLiteral("b", 1);
            enumBuilder.DefineLiteral("c", 3);
            Type enumType = enumBuilder.CreateType();

            var typeBuilder = moduleBuilder.DefineType("MyNameSpace.IFace", TypeAttributes.Public | TypeAttributes.Abstract | TypeAttributes.Interface);
            // 定义属性 "Name"，类型为 int
            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty("Name", PropertyAttributes.None, typeof(int), null);
            // 定义属性的 getter 方法
            MethodBuilder getterMethodBuilder = typeBuilder.DefineMethod("get_Name", MethodAttributes.Public | MethodAttributes.Abstract | MethodAttributes.Virtual, typeof(int), Type.EmptyTypes);
            propertyBuilder.SetGetMethod(getterMethodBuilder);

            // 定义属性的 setter 方法
            MethodBuilder setterMethodBuilder = typeBuilder.DefineMethod("set_Name", MethodAttributes.Public | MethodAttributes.Abstract | MethodAttributes.Virtual, null, new Type[] { typeof(int) });
            propertyBuilder.SetSetMethod(setterMethodBuilder);

            //定义方法 GetMyName
            MethodBuilder getMyName = typeBuilder.DefineMethod("GetMyName", MethodAttributes.Public | MethodAttributes.Abstract | MethodAttributes.Virtual, typeof(string), new Type[] { typeof(int) });

            typeBuilder.CreateType();


            var assemblyTitleType = typeof(AssemblyTitleAttribute).GetConstructor(new Type[] { typeof(string) });
            var titleAttr = new CustomAttributeBuilder(assemblyTitleType, new object[] { title });
            assemblyBuilder.SetCustomAttribute(titleAttr);
            assemblyBuilder.DefineVersionInfoResource();
            assemblyBuilder.Save($"{dllName}.dll");
            Console.WriteLine("已生成静态程序集");
        }
    }
    [Flags]
    public enum TestEnum
    {
        a,
        b, 
        c, 
        d, 
        e, 
        f,
    }
}
