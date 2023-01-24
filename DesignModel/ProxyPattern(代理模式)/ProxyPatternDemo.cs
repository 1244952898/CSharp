using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DesignModel.ProxyPattern_代理模式_
{
    /*
     * 为其他对象提供一种代理以控制对这个对象的访问。
     * 
     * AOP
     */
    internal class ProxyPatternDemo
    {
        public static void main()
        {
            IImage image = new ProxyImage("test_10mb.jpg");

            // 图像将从磁盘加载
            image.display();
            Console.WriteLine("");
            // 图像不需要从磁盘加载
            image.display();
        }
    }
}
