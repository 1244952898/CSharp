using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FactoryPattern_工厂模式_
{
    internal class Rectangle : IShape
    {
        public void Draw() => Console.WriteLine($"{this.GetType().Name}");
    }
}
