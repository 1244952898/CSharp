using DesignModel.FactoryPatternModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FactoryPatternModelAndAbstractFactoryPatternModel
{
    internal class FactoryProducer
    {
        public IAbstractFactory GetFactory(Type t)
        {
            if (t==typeof(ShapeFactory))
            {
                return new ShapeFactory();
            }
            else if (t==typeof(ColorFactory))
            {
                return new ColorFactory();
            }
            return null;
        }
    }
}
