using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.NodeTest
{
    internal  class Nod
    {
        public Nod m_next { get; set; }

        public Nod(Nod node)
        {
            m_next = node;
        }
    }
}
