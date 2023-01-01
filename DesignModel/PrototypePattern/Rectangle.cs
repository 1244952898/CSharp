using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.PrototypePattern
{
    internal class Rectangle: Shape
    {
        public Rectangle()
        {
            Type = "Rectangle";
        }

        public void Draw()
        {
            Console.WriteLine($"Draw{this.GetType().Name}");
        }
    }
}
