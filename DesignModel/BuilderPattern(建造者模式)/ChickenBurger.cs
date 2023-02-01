using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BuilderPattern
{
    internal class ChickenBurger: Burger
    {
        public override string Name()
        {
            return this.GetType().Name;
        }

        public override float Price()
        {
            return 30.0f;
        }
    }
}
