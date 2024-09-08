using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.Logger
{
    public class Tags
    {
        public const EventTags MSSql = (EventTags)1;
        public const EventTags Oracle = (EventTags)2;
        public const EventTags DB2 = (EventTags)3;
    }
}
