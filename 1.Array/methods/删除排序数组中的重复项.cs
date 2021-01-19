using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Array.methods
{
    public class RemoveDuplicates
    {
        public static int RemoveDuplicates0(int[] nums)
        {
            if (nums==null||nums.Length<=0)
                return 0;
            int i = 0;
            int j = 1;
            for (; j < nums.Length; j++)
            {
                if (nums[i]!=nums[j])
                {
                    i++;
                    if (i!=j)
                    {
                        nums[i] = nums[j];
                    }
                }
            }
            return i+1;
        }

        public static int RemoveDuplicates1(int[] nums)
        {
            if (null==nums||nums.Length<=0)
            {
                return 0;
            }
            int i = 0, j = 1;
            while (j<nums.Length)
            {
                if (nums[i]!=nums[j]&&j-i>1)
                {
                    i++;
                    nums[i] = nums[j];
                }
                j++;
            }
            return i++;
        }
    }
}
