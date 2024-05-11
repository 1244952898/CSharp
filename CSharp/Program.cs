using System;
using System.Collections.Generic;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = GenerateMatrix(4);
            var datas = new int[3, 3];

            //var a = new int[] { 2, 3, 1, 2, 4, 3};
            //var asd=MinSubArrayLen(7,a);
            var dic = new Dictionary<int, int>();
            var dicc = new Dictionary<char, int>();

            Console.WriteLine(dic[1]);

            dic[1]++;
            dic.Remove(1);

            YeildTest yeildTest = new YeildTest();
            yeildTest.MyTest();
            //a = a.OrderBy();
        }
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            ListNode preNode = null;
            while (head != null)
            {
                var next = head.next;
                head.next = preNode;
                preNode = head;
                head = next;
            }
            return head;
        }

        public static int[][] GenerateMatrix(int n)
        {
            var result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];





            }
            int left = 0,
            right = n - 1,
            top = 0,
            bottom = n - 1;
            var count = n * n;
            int number = 1;
            while (number < count)
            {
                for (int i = left; i <= right; i++)
                {
                    result[top][i] = number++;
                }
                top++;

                for (int i = top; i <= bottom; i++)
                {
                    result[i][right] = number++;
                }
                right--;

                for (int i = right; i >= left; i--)
                {
                    result[bottom][i] = number++;
                }
                bottom--;

                for (int i = bottom; i >= top; i--)
                {
                    result[i][left] = number++;
                }
                left++;
            }
            if (n % 2 == 1)
            {
                result[n / 2][n / 2] = number;
            }
            return result;
        }

        static IEnumerable<int> GetYeild()
        {
            Console.WriteLine("yeild 开始");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"yeild 开始执行{i}");
                yield return i;
                Console.WriteLine($"yeild 执行结束{i}");
            }
            Console.WriteLine("yeild 停止当前");
        }
    }
}
