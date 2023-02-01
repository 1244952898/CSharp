using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.InterpreterPattern_解释器_
{
    internal class ScaleExpression : Expression
    {
        public override void Execute(string playKey, double playValue)
        {
            string scale = "";
            switch (Convert.ToInt32(playValue))
            {
                case 1:
                    scale = "低音";
                    break;
                case 2:
                    scale = "中音";
                    break;
                case 3:
                    scale = "高音";
                    break;
            }
            Console.WriteLine($"{scale} " );
        }
    }
}
