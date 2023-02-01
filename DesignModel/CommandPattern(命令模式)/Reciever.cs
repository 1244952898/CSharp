using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.CommandPattern_命令模式_
{
    internal class Reciever
    {
        public void RunCommandA()
        {
            Console.WriteLine("执行命令A");
        }

        public void RunCommandB()
        {
            Console.WriteLine("执行命令B");
        }
    }
}
