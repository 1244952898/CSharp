using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CSharp.classes
{
    internal class Abc
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
