using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 天龙八部
{
    public class Protagonist
    {
        public string Name { get; set; }

        public delegate void DelegatEvent ();
        public event DelegatEvent PEvent;
    }
}
