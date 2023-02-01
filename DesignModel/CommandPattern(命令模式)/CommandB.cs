using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.CommandPattern_命令模式_
{
    internal class CommandB : Command
    {
        public CommandB(Reciever reciever) : base(reciever)
        {
        }

        public override void ExcuteCommand()
        {
            Reciever.RunCommandB();
        }
    }
}
