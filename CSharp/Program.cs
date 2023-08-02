using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Class1> cls1 = new List<Class1>();
            cls1.Add(new Class1
            {
                Name1 = "1",
                Name2 = "2",
                Name3 = "3",
                Name4 = "4",
                Name5 = "5",
            });
            cls1.Add(new Class1
            {
                Name1 = "11",
                Name2 = "22",
                Name3 = "33",
                Name4 = "44",
                Name5 = "55",
            });
            cls1.Add(new Class1
            {
                Name1 = "111",
                Name2 = "222",
                Name3 = "333",
                Name4 = "444",
                Name5 = "5",
            });
            var cls2 = cls1.GroupBy(cls =>
            {
                return cls.Name5;
            });
            var ll = cls2.ToList();
            
            //var discs=new Dictionary<string, string>();
            //var ids=new List<string>() { "a","b","c","d"};
            ////var ids1=ids.GroupBy()
            //var sdafd =ids.OrderBy(x=>x.Contains("a")).ToList();
            //Console.WriteLine(sdafd.Count);
            //var idsEx = ids.GetEnumerator();
            //while (idsEx.MoveNext())
            //{
            //    //ids.Remove(id);
            //}
            //foreach (var id in ids)
            //{
            //    ids.Remove(id);
            //    Console.WriteLine(id);
            //}
            //var ids1=new List<string>();
            //ids.Add("a");
            //ids1.Add("b");

            //ids.Union(ids1);
            //ids.Except(ids1);
            //ids.Intersect(ids1);
        }
    }

    public class Abc
    { 
        public List<string> names { get; set; }
    }
}
