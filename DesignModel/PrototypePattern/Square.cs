using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.PrototypePattern
{
    internal class Square : Shape
    {
        public Square()
        {
            Type = "Square";
        }

        public void Draw()
        {
            Console.WriteLine($"Draw{this.GetType().Name}");
        }
    }
}
