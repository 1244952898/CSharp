using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 天龙八部
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Protagonist> protagonists = new List<Protagonist> {
                new Protagonist { Name = "a" },
                new Protagonist { Name = "b" },
                new Protagonist { Name = "c" }
            };

            TaskFactory taskFactory = new TaskFactory();
            //Task a=new Task(() => { },)
            for (int i = 0; i < protagonists.Count; i++)
            {
            }
        }

        private static void EventHander(List<string> events) {

        }
    }
}
