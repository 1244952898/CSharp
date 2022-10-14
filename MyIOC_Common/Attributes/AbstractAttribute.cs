using System;
using System.Collections.Generic;
using System.Text;

namespace MyIOC_Common.Attributes
{
    public abstract class AbstractAttribute:Attribute
    {
       public abstract Action Do(Action action);
    }
}
