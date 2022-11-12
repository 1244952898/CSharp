using System;
using System.Threading;

namespace EventBus
{
    class Program
    {
        static void Main(string[] args)
        {
            //1、初始化鱼竿
            var fishingRod = new FishingRod();

            //2、声明垂钓者
            var fishingMan = new FishingMan("ZY");

            //3.分配鱼竿
            fishingMan.FishingRod = fishingRod;

            //4、注册观察者
            fishingRod.FishingEvent += fishingMan.Update;

            //5、循环钓鱼
            while (fishingMan.FishCount < 5)
            {
                fishingMan.Fishing();
                Console.WriteLine("-------------------");    //睡眠2s
                Thread.Sleep(2000);
            }

            ThreadPool.QueueUserWorkItem(x => { });
        }
    }
}
