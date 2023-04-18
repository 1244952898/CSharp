using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.NodeTest
{
    internal sealed class Node<T> where T : class
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

        public void Test<U>(U u)
        {
            int a=(int)(object)u;
            string b = u as string;
            //int c = u as int;
            if (2==2)
            {

            }

        }
    }
}
