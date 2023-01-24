using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.AdapterPattern_适配器模式_
{
    internal interface IAdvancedMediaPlayer
    {
        public void playVlc(String fileName);
        public void playMp4(String fileName);
    }
}
