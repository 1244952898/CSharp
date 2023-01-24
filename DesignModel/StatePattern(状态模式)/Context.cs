using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.StatePattern_状态模式_
{
    internal class Context
    {
        public IState State { get; set; }

        public Context()
        {
            State = null;
        }
    }
}
