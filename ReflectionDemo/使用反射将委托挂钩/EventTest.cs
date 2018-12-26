using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.使用反射将委托挂钩
{
    public class EventTest
    {
        // 步骤1，定义delegate对象
        public delegate void MyEventHandler(object sender, System.EventArgs e);

        public class MyEventCls
        {
            // 步骤3，定义事件处理方法，它与delegate对象具有相同的参数和返回值类型
            public void MyEventFunc(object sender, System.EventArgs e)
            {
                Console.WriteLine("My event is ok!");
            }
        }

        public event MyEventHandler myevent;

        private MyEventCls myecls;

        public EventTest()
        {
            myecls = new MyEventCls();
            // 步骤5，用+=操作符将事件添加到队列中
            this.myevent += new MyEventHandler(myecls.MyEventFunc);
        }

        protected void OnMyEvent(System.EventArgs e)
        {
            myevent?.Invoke(this, e);
        }

        public void RaiseEvent()
        {
            EventArgs e = new EventArgs();
            // 步骤7，触发事件
            OnMyEvent(e);
        }

    }

  
}
