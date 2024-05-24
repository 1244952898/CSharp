using wwm.LeetCodeHelper;

namespace CSharpCore
{
    public class Program
    {
        static void Main()
        {
            var lst = new List<string>() { "1", "2", "3", "4", "5", "6" };
            (lst[1], lst[4]) = (lst[3], lst[1]);
            lst.RemoveAt(0);

            ThreadPool.GetMaxThreads(out var maxWorkerThreads, out var maxConcurrentActiveRequests);
            Func<string, int> method = Work;
            IAsyncResult cookie = method.BeginInvoke("test", null, null);
            //
            // ... here's where we can do other work in parallel...
            //
            int result = method.EndInvoke(cookie);
            Console.WriteLine("String length is: " + result);
        }

        static int Work(string s)
        {
            return s.Length;
        }
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var results = new List<IList<int>>();
            var nodeList = new List<TreeNode>
            {
                root
            };
            while (nodeList.Count > 0)
            {
                var cnt = nodeList.Count;
                var rs = new List<int>();
                for (var i = 0; i < cnt; i++)
                {
                    rs.Add(nodeList[0].val);
                    nodeList.RemoveAt(0);
                }
                results.Add(rs);
            }
            return results;
        }
    }
}