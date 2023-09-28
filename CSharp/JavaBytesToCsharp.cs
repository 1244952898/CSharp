using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    internal class JavaBytesToCsharp
    {
        public static byte ConvertByte()
        {
            byte javabit = 0;
            int bit = Convert.ToInt32(javabit);
            byte bt;
            if (bit < 0)
            {
                var st = (bit + 256).ToString();
                bt = byte.Parse(st);
            }
            else
            {
                bt = byte.Parse(bit.ToString());
            }
            return bt;
        }
    }
}
