using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    public class SpecialNodeItem<T> : NodeItem<T> where T : System.IComparable<T>, new()
    {

    }
}
