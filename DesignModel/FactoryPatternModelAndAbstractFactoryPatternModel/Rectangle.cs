using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FactoryPatternModel
{
    internal class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Rectangle-Draw");
        }
    }
}
