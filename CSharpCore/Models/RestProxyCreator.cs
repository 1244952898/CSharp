using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace CSharpCore.Models
{
    public class RestProxyCreator
    {
        public static bool BuildAssembly()
        {
            var assName = "RpcProxy";
            var savePath = AppDomain.CurrentDomain.BaseDirectory + assName + ".dll";
            string version;
            var title = assName + " for Taurus MicroService, build on .netcore " + Environment.Version.ToString();

            SyntaxTree syntaxVersionTree = CSharpSyntaxTree.ParseText("versionCode");
            SyntaxTree syntaxCodeTree = CSharpSyntaxTree.ParseText("code");

            // 定义编译选项
            CSharpCompilationOptions compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithOptimizationLevel(OptimizationLevel.Release); // 设置优化级别

            // 创建 Compilation
            CSharpCompilation compilation = CSharpCompilation.Create(assName, new[] { syntaxVersionTree, syntaxCodeTree }, options: compilationOptions);

            using MemoryStream ms = new();
            using Stream win32resStream = compilation.CreateDefaultWin32Resources(true, false, null, null);
            EmitResult result = compilation.Emit(ms, win32Resources: win32resStream);
            if (!result.Success)
            {
                return false;
            }
            else
            {
                // 保存程序集到文件
                using FileStream file = new(savePath, FileMode.Create);
                ms.Seek(0, SeekOrigin.Begin);
                ms.CopyTo(file);
            }
            return false;
        }
    }
}
