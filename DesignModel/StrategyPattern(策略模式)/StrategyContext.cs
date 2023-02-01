using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.PublishSubscribePattern_观察者模式_.StrategyPattern_策略模式_
{
    internal class StrategyContext
    {
        public IStrategy Strategy;
        public StrategyContext(string type)
        {

            switch (type)
            {
                case "A":
                    Strategy = new StrategyA();
                    break;
                case "B":
                    Strategy = new StrategyB();
                    break;
                case "C":
                    Strategy = new StrategyC();
                    break;
                default:
                    break;
            }
        }

        public void getPrice()
        {
            Strategy?.AlgrithomMethond();
        }
    }
}
