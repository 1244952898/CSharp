using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.CommandPattern_命令模式_
{
    internal class CommandA : Command
    {
        public CommandA(Reciever reciever) : base(reciever)
        {
        }

        public override void ExcuteCommand()
        {
            Reciever.RunCommandA();
        }
    }
}
