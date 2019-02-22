using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleagetAndEvent
{
    public class IPhone11
    {
        public event EventHandler<ClickEventArgs> ClickEventHandler;

        protected virtual void OnClickEventHandler(ClickEventArgs e)
        {
            if (ClickEventHandler==null)
            {
                return;
            }
            ClickEventHandler(this, e);
        }



    }
}
