using Apache.NMS.ActiveMQ.Commands;
using Elasticsearch.Net;
using Nest;
using Newtonsoft.Json;
using Spire.Doc;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.ComponentModel;
using System.Net.Http;
using CSharp.classes;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            DatetimeNull datetimeNull = new DatetimeNull();
            datetimeNull.DTime = null;
            //bool siss = true;
            //Console.WriteLine(siss.ToString());
            //var fileLines = File.ReadAllText("D:\\项目\\英飞特\\IMDS\\Batch Client 14.0\\DataDownload_test.bat");
            //foreach (var line in fileLines)
            //{
            //    Console.WriteLine(line);
            //    //var strs = line.Split(new string[] { "\t" }, StringSplitOptions.None);
            //}


            var sList = new List<string> { "1", "2", "1", "2", "3", "1", "2","1" };
            var sdsds=sList.ToString();
            var sdd=sList.Where(x=>x.Equals("1111")).ToList();
            var itemIndexTuple = new List<(int, int)>();
            var startIndex = sList.FindIndex(x => x.Equals("1"));
            for (int i = startIndex + 1; i < sList.Count; i++)
            {
                if ("1" == sList[i])
                {
                    itemIndexTuple.Add((startIndex, i- startIndex));
                    startIndex=i;
                }
            }
            itemIndexTuple.Add((startIndex, sList.Count - startIndex));

            foreach (var item in itemIndexTuple)
            {
                var l = sList.GetRange(item.Item1, item.Item2);
            }

        }
    }
}
