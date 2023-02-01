using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.CommandPattern_命令模式_
{
    internal class Waitor
    {
        private Command command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void ExcuteCommand()
        {
            this.command.ExcuteCommand();
        }
    }
}
