using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FactoryPatternModelAndAbstractFactoryPatternModel
{
    internal class Green : IColor
    {
        public void Fill()
        {
            Console.WriteLine(this.GetType().FullName);
        }
    }
}
