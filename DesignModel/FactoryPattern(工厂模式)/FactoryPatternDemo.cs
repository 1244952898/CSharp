using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FactoryPattern_工厂模式_
{
    internal class FactoryPatternDemo
    {
        public static void A()
        {
            var circleShape = ShapeFatory.GetShape(0);
            var squareShape = ShapeFatory.GetShape(1);
            var rectangleShape = ShapeFatory.GetShape(2);
            circleShape.Draw();
            squareShape.Draw();
            rectangleShape.Draw();
        }
    }
}
