using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BridgePattern_桥接模式_
{
    internal class GreenCircle : IDrawAPI
    {
        public void drawCircle(int radius, int x, int y)
        {
            Console.WriteLine("Drawing Circle[ color: green, radius: "
         + radius + ", x: " + x + ", " + y + "]");
        }
    }
}
