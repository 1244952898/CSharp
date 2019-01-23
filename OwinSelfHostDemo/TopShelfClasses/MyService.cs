using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Runtime;

namespace OwinSelfHostDemo.TopShelfClasses
{
    public class MyService : ServiceControl
    {
        public MyService()
        {
        }
        public MyService(HostSettings settings)
        {
        }

        public bool Start(HostControl hostControl)
        {
            Console.WriteLine("Start");
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            throw new NotImplementedException();
        }

        public void MyStart() {
            Console.WriteLine("MyStart");
        }

        public void MyStop()
        {
            Console.WriteLine("MyStop");
        }

        public void WhenPaused()
        {
            Console.WriteLine("WhenPaused");
        }

        public void WhenContinued()
        {
            Console.WriteLine("WhenContinued");
        }

        public void WhenShutdown()
        {
            Console.WriteLine("WhenShutdown");
        }
    }
}
