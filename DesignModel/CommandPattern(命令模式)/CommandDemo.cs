using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.CommandPattern_命令模式_
{
    internal class CommandDemo
    {
        public static void main()
        {
            Waitor waitor= new Waitor();
            Reciever reciever= new Reciever();

            CommandA commandA = new CommandA(reciever);
            CommandB commandB = new CommandB(reciever);

            waitor.SetCommand(commandA);
            waitor.ExcuteCommand();

            waitor.SetCommand(commandB);
            waitor.ExcuteCommand();
        }
    }
}
