using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.AdapterPattern_适配器模式_
{
    internal class AudioPlayer : IMediaPlayer
    {
        MediaAdapter mediaAdapter;
        public void play(string audioType, string fileName)
        {
            //播放 mp3 音乐文件的内置支持
            if (audioType.Equals("mp3"))
            {
                Console.WriteLine("Playing mp3 file. Name: " + fileName);
            }
            //mediaAdapter 提供了播放其他文件格式的支持
            else if (audioType.Equals("vlc") || audioType.Equals("mp4"))
            {
                mediaAdapter = new MediaAdapter(audioType);
                mediaAdapter.play(audioType, fileName);
            }
            else
            {
                Console.WriteLine("Invalid media. " + audioType + " format not supported");
            }
        }
    }
}
