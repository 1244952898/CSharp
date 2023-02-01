using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BuilderPattern
{
    internal interface IItem
    {
        string Name();
        IPacking Packing();
        float Price();
    }
}
