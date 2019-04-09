using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.字符串回文
{
    /// <summary>
    /// 字符串回文
    /// </summary>
    public class StringCycle
    {
        /// <summary>
        /// 判断是否是回声字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsCycleMethod(string s)
        {
            Queue<char> queues = new Queue<char>();
            Stack<char> stacks = new Stack<char>();
            char[] chars = s.ToCharArray();
            foreach (var c in chars)
            {
                queues.Enqueue(c);
                stacks.Push(c);
            }
            bool isTrue = true;
            while (queues.Count>0)
            {
                if (queues.Dequeue()!=stacks.Pop())
                {
                    isTrue = false;
                    break;
                }
            }
            return isTrue;
        }

        /// <summary>
        /// 暴力破解获取最长回声字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetCycleString1(string s) {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }
            int cycleIndex = 0;
            int cycleSize = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i+1; j < s.Length; j++)
                {
                    int tem1,tem2;
                    for (tem1 = i, tem2 = j; tem1 < tem2; tem1++, tem2--)
                    {
                        if (s[tem1] !=s[tem2])
                        {
                            break;
                        }
                    }
                    if (tem1 >= tem2&&j-i> cycleSize)
                    {
                        cycleSize = j - i+1;
                        cycleIndex = i;
                    }
                }
            }
            if (cycleSize>0)
            {
                return s.Substring(cycleIndex, cycleSize);
            }
            return string.Empty;
        }

        /// <summary>
        /// 动态规划最长回声字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetCycleString2(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }
            int sLenght = s.Length;
            int index = 0;//起始位置
            int lenght = 0;//最大长度
            bool[,] P = new bool[sLenght,sLenght]; //bool默认false
            for (int i = 0; i < sLenght; i++)
            {
                if (i < sLenght - 1&&s[i]==s[i+1])
                {
                    P[i, i + 1] = true;
                    index = i;
                    lenght = 2;
                }
            }
            for (int len = 3; len < sLenght; len++)
            {
                for (int i = 0; i <= sLenght-len; i++)
                {
                    int j = i + len - 1;
                    if (P[i+1, j-1] &&s[i]==s[j])
                    {
                        P[i, j] = true;
                        index = i;
                        lenght = len;
                    }
                }
            }
            if (lenght>=2)
            {
                return s.Substring(index, lenght);
            }
            return string.Empty;
        }

        /// <summary>
        /// 动态规划最长回声字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetCycleString3(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }
            int sLenght = s.Length;
            int index = 0;//起始位置
            int lenght = 0;//最大长度
            for (int i = 0; i < sLenght; i++)//长度为偶数
            {
                int a = i, b = i + 1;
                while (a >= 0 && b < sLenght && s[a] == s[b])
                {
                    if (b-a+1> lenght)
                    {
                        lenght = b - a + 1;
                        index = a;
                    }
                    a--;
                    b++;
                }
            }
            for (int i = 0; i < sLenght; i++) //长度为奇数
            {
                int a = i-1, b = i + 1;
                while (a>=0&&b<sLenght && s[a] == s[b])
                {
                    if (b - a + 1 > lenght)
                    {
                        lenght = b - a + 1;
                        index = a;
                    }
                    a--;
                    b++;
                }
            }
            if (lenght > 0)
                return s.Substring(index, lenght);
            
            return string.Empty;
        }
    }
}
