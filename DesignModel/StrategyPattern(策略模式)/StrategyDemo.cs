using DesignModel.PublishSubscribePattern_观察者模式_.StrategyPattern_策略模式_;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.StrategyPattern_策略模式_
{
    internal class StrategyDemo
    {
        public static void main()
        {
            var strategyContextA = new StrategyContext("A");
            strategyContextA.getPrice();

            var strategyContextB = new StrategyContext("B");
            strategyContextB.getPrice();

            var strategyContextC = new StrategyContext("C");
            strategyContextC.getPrice();
        }
    }
}
