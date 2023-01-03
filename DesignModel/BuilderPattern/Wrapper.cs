using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BuilderPattern
{
    internal class Wrapper : IPacking
    {
        public string Packing()
        {
            return this.GetType().Name;
        }
    }
}
