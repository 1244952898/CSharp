using DeleagetAndEvent.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleagetAndEvent
{
    public delegate void GreetingDelegate(string name);
    class Program
    {

        static void Main(string[] args)
        {
            //Heater heater = new Heater();
            //Alarm alarm = new Alarm();
            //heater.Boiled += alarm.MakeAlert; //注册方法
            //heater.Boiled += (new Alarm()).MakeAlert; //给匿名对象注册方法
            //heater.Boiled += new Heater.BoilHandler(alarm.MakeAlert); //也可以这么注册
            //heater.Boiled += Display.ShowMsg; //注册静态方法
            //heater.BoilWater(); //烧水，会自动调用注册过对象的方法
            //heater.BoilWater();
            //var greetPeopleModel = new GreetPeopleModel();
            //greetPeopleModel.delegateEvent = EGreet;
            //greetPeopleModel.GreetPeople("abc");
            //GreetingDelegate greetPeopleDelegate = EGreet;
            //greetPeopleDelegate += CGreet;
            //Greet("aaa", greetPeopleDelegate);
            //Greet("bbb", greetPeopleDelegate);

            #region MyRegion
            //IPhone6 iphone6 = new IPhone6() { Price = 5288M };
            //// 订阅事件         
            //iphone6.priceChange += iphone6_PriceChanged;
            //// 调整价格（事件发生）        
            //iphone6.Price = 3999;

            //IPhone11 phone11 = new IPhone11();
            //phone11.ClickEventHandler += Click11;
            #endregion


            Console.ReadKey(); 
        }

        public static void EGreet(string nme)
        {
            Console.WriteLine($"{nme} EGreet");
        }
        public static void CGreet(string nme)
        {
            Console.WriteLine($"{nme} CGreet");
        }

        public static void Greet(string name , GreetingDelegate greetPeopleDelegate)
        {
            greetPeopleDelegate(name);
        }

        private static void Click11(object sender, ClickEventArgs e)
        {
            Console.WriteLine("点击了IPhone11");
        }

        static void iphone6_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            Console.WriteLine("年终大促销，iPhone 6 只卖 " + e.NewPrice + " 元， 原价 " + e.OldPrice + " 元，快来抢！");
        }
    }
}
