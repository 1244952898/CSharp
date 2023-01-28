using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.VisitorPattern_访问者模式_
{
    internal abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }
}
