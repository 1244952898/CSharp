using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBusCore.MyEventBus
{
    public class MyPublisher
    {
        public void PublishTeatAEvent(string value)
        {
            MyEventBus.Default.GetEvent<TestAEvent>().Publish(this, new TestAEventArgs() { Value = value });
        }

        public void PublishTeatBEvent(int value)
        {
            MyEventBus.Default.GetEvent<TestBEvent>().Publish(this, new TestBEventArgs() { Value = value });
        }
    }
}
