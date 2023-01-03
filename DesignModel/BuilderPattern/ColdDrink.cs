using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BuilderPattern
{
    internal abstract class ColdDrink : IItem
    {
        public abstract string Name();

        public IPacking Packing()
        {
            return new Bottle();
        }

        public abstract float Price();
    }
}
