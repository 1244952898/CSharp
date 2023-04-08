using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    internal class Test
    {
        public int[] GetNums(int k, int[] nums)
        {

             var result = new List<int>();
            var lst = nums.ToList();
            lst.Sort();
            var start = 0;
            while (start < lst.Count)
            {
                var end = start + 1;
                while (lst[start] == lst[end])
                {
                    end++;
                }
                if (end - start == k)
                {
                    result.Add(lst[start]);
                }
                start = end;
            }

            return result.ToArray();
        }
    }
}
