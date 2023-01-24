using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BridgePattern_桥接模式_
{
    internal class Circle : Shape
    {
        private int x, y, radius;
        public Circle(int x, int y, int radius, IDrawAPI drawAPI) : base(drawAPI)
        {
            this.drawAPI = drawAPI;
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override void draw()
        {
            drawAPI.drawCircle(radius, x, y);
        }
    }
}
