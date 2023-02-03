using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.StatePattern_状态模式_
{
    internal class StatePatternDemo
    {
        /*
         * 一个对象状态改变时允许改变其行为，这个对象看起来像是改变其类
         */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
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
