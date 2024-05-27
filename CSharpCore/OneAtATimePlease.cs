using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore
{
    internal class OneAtATimePlease
    {
        static void Main1()
        {
            using Mutex mutex = new(false, "oreilly.com OneAtATimeDemo");
            if (mutex.WaitOne(TimeSpan.FromSeconds(3), false))
            {
                Console.WriteLine("Another app instance is running. Bye!");
                return;
            }
            RunProgram();
        }

        static void RunProgram()
        {
            Console.WriteLine("Running. Press Enter to exit");
            Console.ReadLine();
        }
    }
}
