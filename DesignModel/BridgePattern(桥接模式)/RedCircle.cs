using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BridgePattern_桥接模式_
{
    internal class RedCircle : IDrawAPI
    {
        public void drawCircle(int radius, int x, int y)
        {
            Console.WriteLine("Drawing Circle[ color: red, radius: "
         + radius + ", x: " + x + ", " + y + "]");
        }
    }
}
