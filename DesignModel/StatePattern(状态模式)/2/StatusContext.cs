using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.StatePattern_状态模式_._2
{
    internal class StatusContext
    {
        public IStatus Status { get; set; }

        public StatusContext()
        {
            Status=new AStatus();
        }

        public void SetStatus(IStatus status)
        {
            Status=status;
        }
    }
}
