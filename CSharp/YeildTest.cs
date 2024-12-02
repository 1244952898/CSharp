using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    public class YeildTest
    {
        public void MyTest()
        {
            foreach (var num in GetInts())
            {
                Console.WriteLine("外部遍历了:{0}", num);
            }
        }

        public IEnumerable<int> GetInts()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("内部遍历了:{0}", i);
                yield return i;
            }
        }

        public IEnumerable<int> YieldTest1()
        {
            int i = 0;
            Console.WriteLine("内部遍历了:{0}", i++);
            yield return i;

            Console.WriteLine("内部遍历了:{0}", i++);
            yield return i;

            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("内部遍历了:{0}", j);
                yield return j;
            }
            Console.WriteLine("内部遍历了:结束");
        }
    }
}
