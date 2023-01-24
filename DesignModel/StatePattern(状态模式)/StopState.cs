using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.StatePattern_状态模式_
{
    internal class StopState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in stop state");
            context.State = this;
        }

        public override string ToString()
        {
            return "Stop State";
        }
    }
}
