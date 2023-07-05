using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.AdapterPattern_适配器模式_
{
    /*
     * 适配器模式（Adapter Pattern）是作为两个不兼容的接口之间的桥梁。
     * 1、美国电器 110V，中国 220V，就要有一个适配器将 110V 转化为 220V。 
     * 2、JAVA JDK 1.1 提供了 Enumeration 接口，而在 1.2 中提供了 Iterator 接口，想要使用 1.2 的 JDK，则要将以前系统的 Enumeration 接口转化为 Iterator 接口，这时就需要适配器模式。 
     * 3、在 LINUX 上运行 WINDOWS 程序。 4、JAVA 中的 jdbc。
     */
    internal class AdapterPatternDemo
    {
        public static void main1()
        {
            AudioPlayer audioPlayer = new AudioPlayer();

            audioPlayer.play("mp3", "beyond the horizon.mp3");
            audioPlayer.play("mp4", "alone.mp4");
            audioPlayer.play("vlc", "far far away.vlc");
            audioPlayer.play("avi", "mind me.avi");
        }
    }
}
