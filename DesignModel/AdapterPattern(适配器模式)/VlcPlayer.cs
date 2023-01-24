using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.AdapterPattern_适配器模式_
{
    internal class VlcPlayer : IAdvancedMediaPlayer
    {
        public void playMp4(string fileName)
        {
            
        }

        public void playVlc(string fileName)
        {
            Console.WriteLine("Playing vlc file. Name: " + fileName);
        }
    }
}
