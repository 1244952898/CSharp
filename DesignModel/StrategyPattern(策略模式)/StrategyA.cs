using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.PublishSubscribePattern_观察者模式_.StrategyPattern_策略模式_
{
    internal class StrategyA : IStrategy
    {
        public void AlgrithomMethond()
        {
            Console.WriteLine($"使用{this.GetType().Name}算法实现");
        }
    }
}
