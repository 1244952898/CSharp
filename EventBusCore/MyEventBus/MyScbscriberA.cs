using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBusCore.MyEventBus
{
    public class MyScbscriberA
    {
        public string Name { get; set; }

        public MyScbscriberA(string name)
        {
            Name = name;
            MyEventBus.Default.GetEvent<TestAEvent>().Subscribe(TeatAEventHandler);
        }

        public void TeatAEventHandler(object sender, TestAEventArgs e)
        {
            Console.WriteLine(Name + ":" + e.Value);
        }
    }

    class MyScbscriberB
    {
        public string Name { get; set; }

        public MyScbscriberB(string name)
        {
            Name = name;
            MyEventBus.Default.GetEvent<TestBEvent>().Subscribe(TeatBEventHandler);
        }

        public void Unsubscribe_TeatBEvent()
        {
            MyEventBus.Default.GetEvent<TestBEvent>().unSubscribe(TeatBEventHandler);
        }

        public void TeatBEventHandler(object sender, TestBEventArgs e)
        {
            Console.WriteLine(Name + ":" + e.Value);
        }
    }
}
