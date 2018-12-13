using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    public class NodeItem<T> where T : System.IComparable<T>
    {
        public NodeItem()
        {
            Console.WriteLine("NodeItem");
        }
    }
}
