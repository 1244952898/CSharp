using Nest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
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

                var pro_xml1 = xmlDoc.SelectSingleNode("/ns:MainDeclaration/ns:IPC-1752B/ns:Product");

                XmlNamespaceManager nsMgr = new XmlNamespaceManager(xmlDoc.NameTable); 
                nsMgr.AddNamespace("ns", "https://webstds.ipc.org/175x/1752B/1752B");
                var pro_xml = xmlDoc.SelectSingleNode("/ns:MainDeclaration/ns:IPC-1752B/ns:Product", nsMgr);
                XmlNode errorNode = xmlDoc.SelectSingleNode("/ns:MainDeclaration", nsMgr);

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                nsmgr.AddNamespace("ns", "https://webstds.ipc.org/175x/1752B/1752B");
                xmlDoc.SelectSingleNode("//ns:error", nsmgr);

                var pro_xml0 = xmlDoc.DocumentElement.SelectNodes("//MainDeclaration");
                //pro_xml0.Item(0).Value = "1";
                var xs = xmlDoc.DocumentElement.OuterXml;
                // 
                //var productNodes = xmlDoc.GetElementsByTagName("Product");
                //var node = xmlDoc.ChildNodes[1].SelectNodes("xml");
                //xmlDoc.SelectSingleNode("MainDeclaration\\IPC-1752B\\Product");
                XmlNode root = xmlDoc.DocumentElement;
               
            }



            
            //reader.Close();

           
           // XmlNode xmlNode = doc.DocumentElement.SelectSingleNode(xPathString, nsmgr);
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
}
