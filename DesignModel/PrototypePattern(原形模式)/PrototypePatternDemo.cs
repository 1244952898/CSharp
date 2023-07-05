using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.PrototypePattern
{
    /*
     * 是用于创建重复的对象，同时又能保证性能。
     * 用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象。
     * 1、细胞分裂。 
     * 2、JAVA 中的 Object clone() 方法。
     * 
     */
    /// <summary>
    /// 原形实例指定创建对象的种类，通过拷贝这些原型创建新的对象
    /// </summary>
    internal class PrototypePatternDemo
    {
        public static void main1()
        {
            ShapeCache.LoadCache();

            var c = ShapeCache.GetShape(0);
            var r=ShapeCache.GetShape(1);
            var s=ShapeCache.GetShape(2);
            Console.WriteLine(c.ToString() + r.ToString()+s.ToString());
        }
    }
}
