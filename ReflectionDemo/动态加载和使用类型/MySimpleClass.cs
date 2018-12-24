﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.动态加载和使用类型
{
    public class MySimpleClass
    {
        public void MyMethod(string str, int i)
        {
            Console.WriteLine("MyMethod parameters: {0}, {1}", str, i);
        }

        public void MyMethod(string str, string i)
        {
            Console.WriteLine("MyMethod parameters: {0}, {1}", str, i);
        }

        public void MyMethod(string str, int i, int j)
        {
            Console.WriteLine("MyMethod parameters: {0}, {1}, {2}",
                str, i, j);
        }
    }
}
