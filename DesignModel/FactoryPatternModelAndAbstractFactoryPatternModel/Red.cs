using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FactoryPatternModelAndAbstractFactoryPatternModel
{
    internal class Red : IColor
    {
        public void Fill()
        {
            Console.WriteLine(this.GetType().FullName);
        }
    }
}
