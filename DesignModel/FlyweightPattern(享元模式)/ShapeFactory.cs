using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DesignModel.FlyweightPattern
{
    internal class ShapeFactory
    {
        private static Dictionary<string,IShape> circleMap = new Dictionary<string,IShape>();
        public static IShape getCircle(string color)
        {
            Circle circle;
            if (circleMap.ContainsKey(color))
            {
                circle = (Circle)circleMap[color];
            }
            else
            {
                circle = new Circle(color);
                circleMap.Add(color, null);
                Console.WriteLine("Creating circle of color : " + color);
            }
            return circle;

        }
    }
}
