using DesignModel.FactoryPatternModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FactoryPatternModelAndAbstractFactoryPatternModel
{
    internal interface IAbstractFactory
    {
        IColor GetColor(string name);
        IShape GetShape(string name);
    }
}
