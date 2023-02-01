using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.CommandPattern_命令模式_
{
    internal abstract class Command
    {
        public Reciever Reciever { get; set; }
        public Command(Reciever reciever)
        {
            Reciever=reciever;
        }

        public abstract void ExcuteCommand();
    }
}
