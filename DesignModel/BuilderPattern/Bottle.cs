using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BuilderPattern
{
    internal class Bottle : IPacking
    {
        public string Packing()
        {
            return this.GetType().Name;
        }
    }
}
