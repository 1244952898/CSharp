using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    public class GenericList<T>
    {
        private class Node
        {
            public Node(T t)
            {
                Data = t;
            }
            public Node Next { get; set; }
            public T Data { get; set; }
        }

        private Node head;

        public GenericList()
        {
            head = null;
        }

        public void AddItem(T data)
        {
            Node node = new Node(data) {Next = head};
            head = node;
        }

        //public IEnumerator<T> GetEnumerator()
        //{
        //    Node now = head;
        //    while (now != null)
        //    {
        //        yield return now.Data;
        //        now = now.Next;
        //    }
        //}

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }


    }
}
