using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.StatePattern_状态模式_._2
{
    internal class BStatus:IStatus
    {
        public void ChangeStatus()
        {
            Console.WriteLine($"现在是{this.GetType().Name}状态");
        }
    }
}
