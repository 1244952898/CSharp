using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPoolDemo
{
    internal class ThreadDemo
    {
        private delegate void AddDelegeate(int a,int b);

        public void main()
        {
            AddDelegeate addDelegeate = new AddDelegeate(Add);
            var ar= addDelegeate.BeginInvoke(1, 3, asyncResult =>
            {
                Console.WriteLine($"Over{asyncResult.AsyncState}");

            }, "OBJ");

            addDelegeate.EndInvoke(ar);
         
        }

        public void Add(int a,int b)
        {
            Console.WriteLine(a + ", " + b);
        }
    }
}
