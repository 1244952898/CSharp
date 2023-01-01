using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FactoryPatternModel
{
    internal class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Circle-Draw");
        }
    }
}
