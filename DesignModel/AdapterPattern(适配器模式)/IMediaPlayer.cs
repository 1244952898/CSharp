using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.AdapterPattern_适配器模式_
{
    internal interface IMediaPlayer
    {
        public void play(string audioType, string fileName);
    }
}
