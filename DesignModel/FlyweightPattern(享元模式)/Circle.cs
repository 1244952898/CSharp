using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FlyweightPattern
{
    internal class Circle : IShape
    {
        public Circle(string color)
        {
            this.color = color;
        }
        public string color { get; set; }
        public int radius { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public void draw()
        {
            Console.WriteLine("Circle: Draw() [Color : " + color + ", x : " + x + ", y :" + y + ", radius :" + radius);
        }
    }
}
