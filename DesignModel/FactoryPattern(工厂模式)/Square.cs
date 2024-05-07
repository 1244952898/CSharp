using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FactoryPattern_工厂模式_
{
    internal class Square : IShape
    {
        public void Draw() => Console.WriteLine($"{this.GetType().Name}");
    }
}
