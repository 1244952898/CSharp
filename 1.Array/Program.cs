using _1.Array.methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Array
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            int[] nums = new int[] { 1, 1, 3, 4, 5, 5, 6 };
            int num0 = RemoveDuplicates.RemoveDuplicates0(nums);
            int num1 = RemoveDuplicates.RemoveDuplicates1(nums);
            Console.WriteLine(num0);
            Console.WriteLine("数组");
            for (int i = 0; i < num0; i++)
            {
                Console.Write(nums[i]+" ");
            }
            #endregion




            Console.ReadLine();
        }
    }
}
