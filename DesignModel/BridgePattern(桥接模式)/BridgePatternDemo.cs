using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BridgePattern_桥接模式_
{
    internal class BridgePatternDemo
    {
        public static void main()
        {
            Shape redCircle = new Circle(100, 100, 10, new RedCircle());
            Shape greenCircle = new Circle(100, 100, 10, new GreenCircle());

            redCircle.draw();
            greenCircle.draw();
        }
    }
}
