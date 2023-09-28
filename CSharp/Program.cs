using Apache.NMS.ActiveMQ.Commands;
using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.OpenRead("D:\\Projects\\CSharp\\CSharp\\files\\aaa.xml");
            byte[] bytes=new byte[file.Length];
            var fileStream = file.Read(bytes, 0, bytes.Length);

            using (var fs = new FileStream("D:\\Projects\\CSharp\\CSharp\\files\\bbb.xml", FileMode.OpenOrCreate))
            {
                using (BinaryWriter bw = new BinaryWriter(fs)) 
                {
                    bw.Write(bytes);
                }
            }
            new BinaryFormatter();
            return;
            string xmlString = "<AML>1111111</AML>";
            var xbytes = Encoding.Default.GetBytes(xmlString);
            var xmlString1 = Encoding.Default.GetString(xbytes);
            var dic=new Dictionary<string, B>();
            dic.Add("1", new B { Name = "1", Description = "1" });
            dic.Add("2", new B { Name = "2", Description = "2" });
            dic.Add("3", new B { Name = "3", Description = "3" });

            var b4 = new B { Name = "4", Description = "4" };
            var liB = new List<B>();
            liB.Add(b4);
            dic.Add("4", b4);

            var b5=dic["4"]; 
            b5.Name = "5";
            b5.Description = "5";
            liB.Add(b5);
            

            var list = new List<string>();
            var tus = (1, 2, 3, 4, 5,"6",1,2,2,2,2,2,2,3);
            var tuple2=ValueTuple.Create(1, 2, 3, 4, 5, "6");
            Console.WriteLine(tus.GetType());
            
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

    public class B
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
