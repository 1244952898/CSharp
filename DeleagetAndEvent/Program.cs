using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleagetAndEvent
{
    class Program
    {

        static void Main(string[] args)
        {
            IPhone6 iphone6 = new IPhone6() { Price = 5288M };
            // 订阅事件         
            iphone6.priceChange += iphone6_PriceChanged;
            // 调整价格（事件发生）        
            iphone6.Price = 3999;

            IPhone11 phone11 = new IPhone11();
            phone11.ClickEventHandler += Click11;

            Console.ReadKey(); 
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
