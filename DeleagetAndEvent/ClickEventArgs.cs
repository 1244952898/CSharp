using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleagetAndEvent
{
    public class ClickEventArgs:EventArgs
    {
        private string Words;
        public ClickEventArgs(string words) {
            this.Words = words;
        }
    }
}
