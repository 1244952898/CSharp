using DesignModel.FactoryPatternModelAndAbstractFactoryPatternModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace DesignModel.FactoryPatternModel
{
    /*
     * 定义一个创建对象的接口，让其子类自己决定实例化哪一个工厂类，工厂模式使其创建过程延迟到子类进行。
     * 
     */
    internal class ShapeFactory: IAbstractFactory
    {
        public IShape GetShape(string name)
        {
            if (name.Equals(typeof(Rectangle).Name))
            {
                return new Rectangle();
            }
            else if (name.Equals(typeof(Square).Name))
            {
                return new Square();
            }
            else if (name.Equals(typeof(Circle).Name))
            {
                return new Circle();
            }
            return null;
        }

        public static IShape GetInstance<T>(T t) where T : IShape
        {
            if (t.GetType() == typeof(Rectangle))
            {
                return new Rectangle();
            }
            else if (t.GetType() == typeof(Square))
            {
                return new Square();
            }
            else if (t.GetType() == typeof(Circle))
            {
                return new Circle();
            }
            return null;
        }

        public IColor GetColor(string name)
        {
            return null;
        }
    }
}
