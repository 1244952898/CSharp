﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDemo
{
    /// <summary>
    /// 远程接口
    /// </summary>
    public class RemoteHelper
    {
        public static List<T> Query<T>()
        {
            Console.WriteLine("This is 18311{0} Query", typeof(RemoteHelper));
            long lResult = 0;
            for (int i = 0; i < 462799; i++)
            {
                lResult += i;
            }

            return new List<T>()
            {
                default(T),default(T),default(T),default(T)
            };
        }

    }
}
