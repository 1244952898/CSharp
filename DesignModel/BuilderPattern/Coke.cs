using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BuilderPattern
{
    internal class Coke:ColdDrink
    {
        public override string Name()
        {
            return this.GetType().Name;
        }

        public override float Price()
        {
            return 3.99f;
        }
    }
}
