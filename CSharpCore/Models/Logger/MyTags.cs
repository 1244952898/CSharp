using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.Logger
{
    public class MyTags
    {
        public const MyEventTags MSSql = (MyEventTags)1;
        public const MyEventTags Orcal = (MyEventTags)2;
        public const MyEventTags Redis = (MyEventTags)3;
        public const MyEventTags MongoDB = (MyEventTags)4;
    }
}
