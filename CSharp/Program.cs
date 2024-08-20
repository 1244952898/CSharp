using Aliyun.OSS;
using CSharp.Emit;
using CSharpCore.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Document = QuestPDF.Fluent.Document;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            NPOIDemo demo = new NPOIDemo();
            demo.Test();


            //RestProxyCreator.BuildAssembly();
            var c = TestEnum.a | TestEnum.b | TestEnum.c;
            EmitDemo.Create(c);
            //var lst=new List<string>();
            //lst.Where(x => x.Equals("a")).Select(x=>x=="");
            //lst.RemoveRange(0, lst.Count);
            //var stack= new Stack<int>();
            //stack.Push(lst.Count);
            //stack.Pop();

            //var q=new Queue<int>();
            //q.Enqueue(lst.Count);
            //q.Dequeue();

            //var ints1=new int[lst.Count];
            //var ints2=new int[lst.Count];
            ////Array.Copy(ints1,1, ints2, 2);
            OssClient client = null;
            var result = client.UploadPart(null);
        }
    }
}
