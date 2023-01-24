using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.ProxyPattern_代理模式_
{
    internal class ProxyImage:IImage
    {
        private RealImage realImage;
        private String fileName;

        public ProxyImage(String fileName)
        {
            this.fileName = fileName;
        }

        public void display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }
            realImage.display();
        }
    }
}
