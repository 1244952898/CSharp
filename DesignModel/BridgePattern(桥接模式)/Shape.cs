using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BridgePattern_桥接模式_
{
    internal abstract class Shape
    {
        protected IDrawAPI drawAPI;
        protected Shape(IDrawAPI drawAPI)
        {
            this.drawAPI = drawAPI;
        }
        public abstract void draw();
    }
}
