﻿using wwm.LeetCodeHelper;
using Microsoft.Extensions.Configuration;

namespace CSharpCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using Mutex mutex = new(false, "oreilly.com OneAtATimeDemo");
            if (mutex.WaitOne(TimeSpan.FromSeconds(3), false))
            {
                Console.WriteLine("Another app instance is running. Bye!");
                return;
            }
            RunProgram();
            Console.ReadLine();
        }

        static void RunProgram()
        {
            Console.WriteLine("Running. Press Enter to exit");
            Console.ReadLine();
        }

    }
}