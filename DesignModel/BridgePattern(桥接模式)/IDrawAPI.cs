using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BridgePattern_桥接模式_
{
    internal interface IDrawAPI
    {
        public void drawCircle(int radius, int x, int y);
    }
}
