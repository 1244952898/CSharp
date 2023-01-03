using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BuilderPattern
{
    internal class Pepsi:ColdDrink
    {
        public override string Name()
        {
            return this.GetType().Name;
        }

        public override float Price()
        {
            return 3.59f;
        }
    }
}
