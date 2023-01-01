using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FactoryPatternModel
{
   internal class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Square-Draw");
        }
    }
}
