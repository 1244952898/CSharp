using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.ProxyPattern_代理模式_
{
    internal class RealImage : IImage
    {
        private string fileName;

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            loadFromDisk(fileName);
        }

        public void display()
        {
            Console.WriteLine("Displaying " + fileName);
        }
        private void loadFromDisk(string fileName)
        {
            Console.WriteLine("Loading " + fileName);
        }
    }
}
