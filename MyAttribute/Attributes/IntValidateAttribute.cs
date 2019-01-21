using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Attributes
{
    public class IntValidateAttribute: Attribute
    {
        private int MinSize { get; set; }
        private int MaxSize { get; set; }

        public IntValidateAttribute(int _MinSize,int _MaxSize) {
            this.MinSize = _MinSize;
            MaxSize = _MaxSize;
        }

        public bool Validate (int num)
        {
            return num > this.MinSize && num < this.MaxSize;
        }
    }
}
