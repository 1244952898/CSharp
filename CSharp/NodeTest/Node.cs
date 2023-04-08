using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.NodeTest
{
    internal sealed class Node<T>
    {
        public T m_data { get; set; }
        public Node<T> m_next { get; set; }
        public Node(T data):this(data,null)
        {

        }
        public Node(T data, Node<T> next)
        {
            m_data = data;
            m_next = next;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
