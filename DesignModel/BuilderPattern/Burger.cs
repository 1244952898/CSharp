using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BuilderPattern
{
    internal abstract class Burger:IItem
    {
        public abstract string Name();

        public IPacking Packing()
        {
            return new Wrapper();
        }


        public abstract float Price();

    }
}
