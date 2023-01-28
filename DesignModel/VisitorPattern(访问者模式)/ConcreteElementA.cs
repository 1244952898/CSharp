using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.VisitorPattern_访问者模式_
{
    internal class ConcreteElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitorConcreteElementA(this);
        }
    }
}
