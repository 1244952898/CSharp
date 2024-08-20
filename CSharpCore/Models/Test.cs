using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models
{
    internal class Test
    {
        public string T { get; set; }

        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> results = [];
            IList<int> tempResult=[];

            void BackTracking(int index)
            {
                if (tempResult.Count == k)
                {
                    results.Add(new List<int>(tempResult));
                    tempResult.Clear();
                    return;
                }

                for (int i = index; i < n-(k-tempResult.Count); i++)
                {
                    tempResult.Add(i);
                    BackTracking(i+1);
                    tempResult.Remove(i);
                }
            }
            BackTracking(1);
            return results;
        }


    }
}
