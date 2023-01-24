using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.StatePattern_状态模式_
{
    internal class StartState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in start state");
            context.State= this;
            //context.setState(this);
        }

        public override string ToString()
        {
            return "Start State";
        }
    }
}
