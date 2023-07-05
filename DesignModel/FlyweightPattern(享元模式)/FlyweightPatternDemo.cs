using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FlyweightPattern
{
    /*
     * 主要用于减少创建对象的数量，以减少内存占用和提高性能
     * 1、JAVA 中的 String，如果有则返回，如果没有则创建一个字符串保存在字符串缓存池里面。
     * 2、数据库的数据池。
     */

    /// <summary>
    /// 运用共享技术大量的实现
    /// </summary>
    internal class FlyweightPatternDemo
    {
        private static string[] colors = new string[] { "Red", "Green", "Blue", "White", "Black" };
        public static void main1()
        {
            for (int i = 0; i < 20; ++i)
            {
                Circle circle =
                   (Circle)ShapeFactory.getCircle(getRandomColor());
                circle.x = getRandomX();
                circle.y = getRandomY();
                circle.radius = 100;
                circle.draw();
            }
        }
        private static string getRandomColor()
        {
            return colors[(int)(new Random().Next() * colors.Length)];
        }
        private static int getRandomX()
        {
            return (int)(new Random().Next() * 100);
        }
        private static int getRandomY()
        {
            return (int)(new Random().Next() * 100);
        }
    }
}
