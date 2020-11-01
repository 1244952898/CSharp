using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleagetAndEvent.NewFolder1
{
    public class Heater
    {
        public string type = "RealFire 001"; // 添加型号作为演示
        public string area = "China Xian"; // 添加产地作为演示
        private int temperature;

        public delegate void BoilHandler(Object sender, BoiledEventArgs e);
        public event BoilHandler Boiled;
        // 定义 BoiledEventArgs 类，传递给 Observer 所感兴趣的信息
        public class BoiledEventArgs : EventArgs
        {
            public readonly int tempera;
            public BoiledEventArgs(int temperature)
            {
                this.tempera = temperature;
            }
        }
        // 可以供继承自 Heater 的类重写，以便继承类拒绝其他对象对它的监视
        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            if (Boiled != null)
            {
                Boiled(this, e); // 调用所有注册对象的方法
            }
        }

        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature>95)
                {
                    BoiledEventArgs boiledEventArgs = new BoiledEventArgs(temperature);
                    OnBoiled(boiledEventArgs);
                }
            }
        }
    }

    /// <summary>
    /// 警报器
    /// </summary>
    public class Alarm
    {
        public void MakeAlert(Object sender, Heater.BoiledEventArgs e)
        {
            Heater heater = (Heater)sender; // 这里是不是很熟悉呢？
                                            // 访问 sender 中的公共字段
            Console.WriteLine("Alarm：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Alarm: 嘀嘀嘀，水已经 {0} 度了：", e.tempera);
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 显示器
    /// </summary>
    public class Display
    {
        public static void ShowMsg(Object sender, Heater.BoiledEventArgs e) // 静态方法
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("Display：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", e.tempera);
            Console.WriteLine();
        }
    }
}
