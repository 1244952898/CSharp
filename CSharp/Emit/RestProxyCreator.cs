using Elasticsearch.Net;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Emit
{
    public static class RestProxyCreator
    {
        /// <summary>
        /// 构建并保存程序集
        /// </summary>
        /// <param name="assName">程序集名称</param>
        /// <param name="savePath">保存路径</param>
        public static bool BuildAssembly()
        {
            var assName = "RpcProxy";
            var savePath = AppDomain.CurrentDomain.BaseDirectory + assName + ".dll";
            string version;
            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("System.dll");
            //cp.ReferencedAssemblies.Add("System.Web.dll");
            //cp.ReferencedAssemblies.Add("System.Xml.dll");
            //cp.ReferencedAssemblies.Add("System.Data.dll");
            //cp.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + "CYQ.Data.dll");
            //cp.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + "Taurus.Core.dll");
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = false;
            cp.OutputAssembly = savePath;
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, "");
            if (cr == null || cr.Errors.Count > 0) { return false; }
            return true;
        }
    }
}
