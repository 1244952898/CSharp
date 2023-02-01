using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.PrototypePattern
{
    internal class Shape: ICloneable
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
