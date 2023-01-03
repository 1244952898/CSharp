using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace DesignModel
{
    /*注意Volatile
     * 保证一个类仅有一个实例，并提供一个访问它的全局访问点。
     * 单例模式分为：懒汉模式，饿汉模式，双检锁/双重校验锁等。。。
     * 用途：
     * 1、要求生产唯一序列号。
     * 2、WEB 中的计数器，不用每次刷新都在数据库里加一次，用单例先缓存起来。
     * 3、创建的一个对象需要消耗的资源过多，比如 I/O 与数据库的连接等。
     * 4、程序的日志应用
     */


    /// <summary>
    /// 饿汉模式
    /// </summary>
    internal class SingletonModel0
    {
        private static SingletonModel0 instance = new SingletonModel0();
        private SingletonModel0() { }

        public static SingletonModel0 GetInstance() { return instance; }
    }

    /// <summary>
    /// 懒汉模式
    /// </summary>
    internal class SingletonModel1
    {
        private static SingletonModel1 instance;
        private SingletonModel1() { }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static SingletonModel1 GetInstance()
        {
            if (instance == null)
            {
                var temp= new SingletonModel1();
                Volatile.Write(ref instance, temp);
            }
            return instance;
        }
    }

    /// <summary>
    /// 双检锁/双重校验锁
    /// </summary>
    internal class SingletonModel2
    {
        private static SingletonModel2 instance;
        private SingletonModel2() { }
        private static readonly object obj = new object();

        public static SingletonModel2 GetInstance()
        {
            // 判断对象是否以及实例化过，没有则进入加锁代码块，此处可能有多个线程同时进来，等待类对象锁
            if (instance == null)
            {
                lock (obj)
                {
                    // 获取类对象锁，其他线程在外等待，其他线程进来再次判断，如果对象实例化了，则不需要再实例化
                    var temp= new SingletonModel2();
                    Volatile.Write(ref instance, temp);
                }
            }
            return instance;
        }
    }
}
