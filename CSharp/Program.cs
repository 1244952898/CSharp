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
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new B
            {
                Name = "1",
                Description = "1"
            };
            var bb=b.Clone() as B;


            //Abc abc = new Abc();
            //abc.test();
            #region MyRegion
            XmlDocument xmlDoc = new XmlDocument();
            string filepath = "D:\\ipc.xml";
            //xmlDoc.LoadXml(filepath);
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
   
            //XmlReader reader = XmlReader.Create(filepath, settings);
            using (XmlReader reader = XmlReader.Create(filepath, settings))
            {
              
                xmlDoc.Load(reader);

                XmlNamespaceManager nsMgr = new XmlNamespaceManager(xmlDoc.NameTable); 
                nsMgr.AddNamespace("ns", "https://webstds.ipc.org/175x/1752B/1752B");
                var pro_xml = xmlDoc.SelectSingleNode("/ns:MainDeclaration/ns:IPC-1752B/ns:Product", nsMgr);
               
            }


            #endregion
         
        }
    }

    public class Abc
    { 
        public List<string> names { get; set; }

        public void test()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<book ISBN=\"q\">" +
                        "<title>Pride And Prejudice</title>" +
                        "<price>19.95</price>" +
                        "</book>");

            XmlNode root = doc.FirstChild;

            var n = GetBook("q", doc);
        }

        public XmlNode GetBook(string uniqueAttribute, XmlDocument doc)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("bk", "http://www.contoso.com/books");
            string xPathString = "//book";
            XmlNode xmlNode = doc.DocumentElement.SelectSingleNode(xPathString, nsmgr);
            return xmlNode;
        }
    }
    public enum WeightEnum
    {
        /// <summary>
        /// 克
        /// </summary>
        g = 0,

        /// <summary>
        /// 毫克
        /// </summary>
        mg = 1,
    }

    public class B
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public object Clone()
        {
           return this.MemberwiseClone();
        }
    }

    public class C
    {
        public static void GetNumber(int n)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}  {n}");
        }
    }
}
