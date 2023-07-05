using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.StatePattern_状态模式_._2
{
    internal class Demo
    {
        public static void Main1()
        {
            StatusContext context= new StatusContext();
            
            BStatus bStatus= new BStatus();
            context.SetStatus(bStatus);

        }
    }
}
