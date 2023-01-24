using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.AdapterPattern_适配器模式_
{
    internal class Mp4Player : IAdvancedMediaPlayer
    {
        public void playMp4(string fileName)
        {
            Console.WriteLine("Playing mp4 file. Name: " + fileName);
        }

        public void playVlc(string fileName)
        {
           
        }
    }
}
