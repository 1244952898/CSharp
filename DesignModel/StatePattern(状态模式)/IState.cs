using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.StatePattern_状态模式_
{
    internal interface IState
    {
        public void doAction(Context context);
    }
}
