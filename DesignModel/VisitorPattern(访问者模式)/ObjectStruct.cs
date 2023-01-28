using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.VisitorPattern_访问者模式_
{
    internal class ObjectStruct
    {
        public List<Element> Elements { get; set; }
        public ObjectStruct()
        {
            Elements=new List<Element>();
        }

        public void Accept(Visitor visitor)
        {
            foreach (var e in Elements)
            {
                e.Accept(visitor);
            }
        }
    }
}
