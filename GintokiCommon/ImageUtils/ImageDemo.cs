using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GintokiCommon.ImageUtils
{
    public class ImageDemo
    {
        public static void StreamDemo1(string str="1234 56789")
        {
            var bytes = Encoding.Default.GetBytes(str);
            using (var stream=new MemoryStream(bytes))
            {
                if (stream.CanRead)
                {
                    stream.Read(bytes, 0, 4);
                    if (stream.CanSeek)
                    {
                       long newPostion = stream.Seek(1, SeekOrigin.Begin);
                        newPostion = newPostion <= 0 ? 0 : newPostion;
                       stream.Write(bytes, (int)newPostion, bytes.Length - (int)stream.Length);


                    }
                }
            }
        }
    }
}
