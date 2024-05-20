using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var l=new TreeNode(1,null,null);
            var r=new TreeNode(2,null,null);
            var root=new TreeNode(3,l,r);

            var lst = PreorderTraversal(root);
        }
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            var nodeList = new List<TreeNode>();
            nodeList.Add(root);
            var results = new List<int>();
            while (nodeList.Count > 0)
            {
                if (nodeList[0].left != null)
                {
                    nodeList.Add(nodeList[0].left);
                }
                if (nodeList[0].right != null)
                {
                    nodeList.Add(nodeList[0].right);
                }
                results.Add(nodeList[0].val);
                nodeList.RemoveAt(0);
            }
            return results;
        }

        public int EvalRPN(string[] tokens)
        {
            var numberStack = new Stack<string>();
            foreach (var s in tokens)
            {
                if (s == "+")
                {
                    var n0 = int.Parse(numberStack.Pop());
                    var n1 = int.Parse(numberStack.Pop());
                    numberStack.Push((n1 + n0).ToString());
                }
                else if (s == "-")
                {
                    var n0 = int.Parse(numberStack.Pop());
                    var n1 = int.Parse(numberStack.Pop());
                    numberStack.Push((n1 - n0).ToString());
                }
                else if (s == "*")
                {
                    var n0 = int.Parse(numberStack.Pop());
                    var n1 = int.Parse(numberStack.Pop());
                    numberStack.Push((n1 * n0).ToString());
                }
                else if (s == "/")
                {
                    var n0 = int.Parse(numberStack.Pop());
                    var n1 = int.Parse(numberStack.Pop());
                    numberStack.Push((n1 / n0).ToString());
                }
                else
                {
                    numberStack.Push(s);
                }
            }
            return int.Parse(numberStack.Pop());
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

        public static int[] GetNext(string s)
        {
            var next = new int[s.Length];
            var j = 0;
            next[0] = 0;
            for (int i = 1; i < s.Length; i++)
            {
                while (j > 0 && s[j] != s[i])
                {
                    j = next[j - 1];
                }

                if (s[j] == s[i])
                {
                    j++;
                }
                next[i] = j;
            }
            return next;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
