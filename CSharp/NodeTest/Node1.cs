using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.NodeTest
{
    internal class Node1<T> : Nod
    {
        public T m_data { get; set; }
        public Node1(T data) : this(data, null)
        {
        }
        public Node1(T data, Nod next) : base(next)
        {
            m_data = data;
        }
    }
}
