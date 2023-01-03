using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FacadePattern
{
    internal class Square : IShape
    {
        public void draw()
        {
            Console.WriteLine($"{this.GetType().Name}");
        }
    }
}
