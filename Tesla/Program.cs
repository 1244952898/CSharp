using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tesla.q2;

namespace Tesla
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //test0();

            //var lst=new List<string>();
            //lst.Add("codility");
            //lst.ForEach(x => so1(x));

            DocumentProcessor documentProcessor= new DocumentProcessor();
            documentProcessor.Analyze(", A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67%^&%&^%67457687643576438756438756$%$%$%%4343 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff");
            //documentProcessor.Analyze("I'm a very good programmer. Even though I am just 12 years old.");



        }

        #region 0
        static int test0()
        {
            Console.WriteLine("Hello World!");
            var dic = new Dictionary<string, int>();
            
            var A = new int[] { 4, 2, 3, 4 };
            var lst = new bool[A.Length];
            foreach (var l in A)
            {
                if (l >= 1 && l <= A.Length)
                {
                    lst[l - 1] = true;
                }
            }
            for (int i = 0; i < lst.Length; i++)
            {
                if (!lst[i])
                {
                    Console.WriteLine(i + 1);
                    return i + 1;
                }
            }
            Console.WriteLine(lst.Length + 1);
            Array.Sort(A);
            Console.WriteLine(A);
            return lst.Length + 1;
        }
        #endregion

        #region 1
        static string so1(string S)
        {
            var chars=S.ToCharArray();
            var len = chars.Length - 1;
            string result = "";
            var isContinue = true;
            for (int i = 0; i < len; i++)
            {
                if (chars[i] > chars[i+1]&& isContinue)
                {
                    isContinue=false;
                    continue;
                }
                result += chars[i];
            }
            if (S.Length-1!=result.Length)
            {
                result += chars[len];
            }
            return result;
        }
        #endregion
    }
}
