using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.VisitorPattern_访问者模式_
{
    /*
     * 
     */
    internal class VisitorPatternDemo
    {
        public static void A()
        {
            ObjectStruct objs = new ObjectStruct();
            objs.Elements.Add(new ConcreteElementA());
            objs.Elements.Add(new ConcreteElementB());

            ConcreteVisitor1 concreteVisitor1= new ConcreteVisitor1();
            ConcreteVisitor2 concreteVisitor2= new ConcreteVisitor2();
            objs.Accept(concreteVisitor1);
            objs.Accept(concreteVisitor2);
        }
       
    }
}
