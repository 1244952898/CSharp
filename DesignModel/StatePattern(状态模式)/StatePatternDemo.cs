using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.StatePattern_状态模式_
{
    internal class StatePatternDemo
    {
        public static void main(String[] args)
        {
            Context context = new Context();

            StartState startState = new StartState();
            startState.doAction(context);

            Console.WriteLine(context.State);

            StopState stopState = new StopState();
            stopState.doAction(context);

            Console.WriteLine(context.State);
        }
    }
}
