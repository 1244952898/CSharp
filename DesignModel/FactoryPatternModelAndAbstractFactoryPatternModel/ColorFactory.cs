using DesignModel.FactoryPatternModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FactoryPatternModelAndAbstractFactoryPatternModel
{
    internal class ColorFactory : IAbstractFactory
    {
        public IColor GetColor(string name)
        {
            if (name.Equals(typeof(Red).Name))
            {
                return new Red();
            }
            else if (name.Equals(typeof(Green).Name))
            {
                return new Green();
            }
            return null;
        }

        public static IColor GetInstance<T>(Type t) where T : class,IColor
        {
            if (t == typeof(Red))
            {
                return new Red();
            }
            else if (t == typeof(Green))
            {
                return new Green();
            }
            return null;
        }

        public IShape GetShape(string name)
        {
            return null;
        }
    }
}
