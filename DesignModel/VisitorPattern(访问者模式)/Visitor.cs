using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.VisitorPattern_访问者模式_
{
    internal abstract class Visitor
    {
        public abstract void VisitorConcreteElementA(ConcreteElementA concreteElementA);
        public abstract void VisitorConcreteElementB(ConcreteElementB concreteElementB);
    }
}
