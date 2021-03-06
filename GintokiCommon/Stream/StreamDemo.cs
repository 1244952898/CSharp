﻿using GintokiCommon.Stream;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GintokiCommon.ImageUtils
{
    public class StreamDemo
    {
        #region Stream
        /// <summary>
        /// Stream
        /// </summary>
        /// <param name="str"></param>
        public static void StreamDemo1()
        {
            string str = "1234 56789";
            var bytes = Encoding.Default.GetBytes(str);
            using (var stream = new MemoryStream())
            {
                if (stream.CanWrite)
                {
                    stream.Write(bytes, 0, 4);
                    if (stream.CanSeek)
                    {
                        long newPostion = stream.Seek(6, SeekOrigin.Begin);
                        newPostion = newPostion <= 0 ? 0 : newPostion;
                        if (newPostion < bytes.Length)
                        {
                            stream.Write(bytes, (int)newPostion, bytes.Length - (int)newPostion);
                        }
                        stream.Position = 0;

                        var readbytes = new byte[(int)stream.Length];
                        if (stream.CanRead)
                        {
                            stream.Read(readbytes, 0, readbytes.Length);
                        }
                        var outStr = Encoding.Default.GetString(readbytes);
                        Console.WriteLine(outStr);
                    }
                }
                stream.Close();
            }
        }

        public static void StreamDemo()
        {
            byte[] buffer = null;

            string testString = "Stream!Hello world";
            char[] readCharArray = null;
            byte[] readBuffer = null;
            string readString = string.Empty;
            //关于MemoryStream 我会在后续章节详细阐述
            using (MemoryStream stream = new MemoryStream())
            {
                Console.WriteLine("初始字符串为：{0}", testString);
                //如果该流可写
                if (stream.CanWrite)
                {
                    //首先我们尝试将testString写入流中
                    //关于Encoding我会在另一篇文章中详细说明，暂且通过它实现string->byte[]的转换
                    buffer = Encoding.Default.GetBytes(testString);
                    //我们从该数组的第一个位置开始写，长度为3，写完之后 stream中便有了数据
                    //对于新手来说很难理解的就是数据是什么时候写入到流中，在冗长的项目代码面前，我碰见过很
                    //多新手都会有这种经历，我希望能够用如此简单的代码让新手或者老手们在温故下基础
                    stream.Write(buffer, 0, 3);

                    Console.WriteLine("现在Stream.Postion在第{0}位置", stream.Position + 1);

                    //从刚才结束的位置（当前位置）往后移3位，到第7位
                    long newPositionInStream = stream.CanSeek ? stream.Seek(3, SeekOrigin.Current) : 0;

                    Console.WriteLine("重新定位后Stream.Postion在第{0}位置", newPositionInStream + 1);
                    if (newPositionInStream < buffer.Length)
                    {
                        //将从新位置（第7位）一直写到buffer的末尾，注意下stream已经写入了3个数据“Str”
                        stream.Write(buffer, (int)newPositionInStream, buffer.Length - (int)newPositionInStream);
                    }


                    //写完后将stream的Position属性设置成0，开始读流中的数据
                    stream.Position = 0;

                    // 设置一个空的盒子来接收流中的数据，长度根据stream的长度来决定
                    readBuffer = new byte[stream.Length];


                    //设置stream总的读取数量 ，
                    //注意！这时候流已经把数据读到了readBuffer中
                    int count = stream.CanRead ? stream.Read(readBuffer, 0, readBuffer.Length) : 0;


                    //由于刚开始时我们使用加密Encoding的方式,所以我们必须解密将readBuffer转化成Char数组，这样才能重新拼接成string

                    //首先通过流读出的readBuffer的数据求出从相应Char的数量
                    int charCount = Encoding.Default.GetCharCount(readBuffer, 0, count);
                    //通过该Char的数量 设定一个新的readCharArray数组
                    readCharArray = new char[charCount];
                    //Encoding 类的强悍之处就是不仅包含加密的方法，甚至将解密者都能创建出来（GetDecoder()），
                    //解密者便会将readCharArray填充（通过GetChars方法，把readBuffer 逐个转化将byte转化成char，并且按一致顺序填充到readCharArray中）
                    Encoding.Default.GetDecoder().GetChars(readBuffer, 0, count, readCharArray, 0);
                    for (int i = 0; i < readCharArray.Length; i++)
                    {
                        readString += readCharArray[i];
                    }
                    Console.WriteLine("读取的字符串为：{0}", readString);
                }

                stream.Close();
            }
        }
        #endregion

        #region TextStream
        public static void TextStreamDemo(string str="abc\ndef")
        {
            using (TextReader reader = new StringReader(str))
            {
                while (reader.Peek()!=-1)
                {
                    Console.WriteLine("Peek = {0}", (char)reader.Peek());
                    Console.WriteLine("Read会 = {0}（读取下一个）", (char)reader.Read());
                }
                reader.Close();
            }
   

            using (TextReader reader = new StringReader(str))
            {
                var charBuffer = new char[2];
                reader.ReadBlock(charBuffer, 0, 2);
                for (int i = 0; i < charBuffer.Length; i++)
                {
                    Console.WriteLine("通过readBlock读出的数据：{0}", charBuffer[i]);
                }
                reader.Close();
            }

            using (TextReader reader = new StringReader(str))
            {
                var lineData = reader.ReadLine();
                Console.WriteLine("第一行的数据为:{0}", lineData);
                reader.Close();
            }

            using (TextReader reader = new StringReader(str))
            {
                string allData = reader.ReadToEnd();
                Console.WriteLine("全部的数据为:{0}", allData);
                reader.Close();
            }

        }
        #endregion

        private static object lockObj = new object();
        /// <summary>
        /// 添加文件方法
        /// </summary>
        /// <param name="config"> 创建文件配置类</param>
        public void Create(IFileConfig config)
        {
          
            lock (lockObj)
            {
                //得到创建文件配置类对象
                var createFileConfig = config as CreateFileConfig;
                //检查创建文件配置类是否为空
                if (this.CheckConfigIsError(config)) return;
                //假设创建完文件后写入一段话，实际项目中无需这么做，这里只是一个演示
                char[] insertContent = "HellowWorld".ToCharArray();
                //转化成 byte[]
                byte[] byteArrayContent = Encoding.Default.GetBytes(insertContent, 0, insertContent.Length);
                //根据传入的配置文件中来决定是否同步或异步实例化stream对象
                FileStream stream = createFileConfig.IsAsync ?
                    new FileStream(createFileConfig.CreateUrl, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 4096, true)
                    : new FileStream(createFileConfig.CreateUrl, FileMode.Create);
                using (stream)
                {
                    // 如果不注释下面代码会抛出异常，google上提示是WriteTimeout只支持网络流
                    // stream.WriteTimeout = READ_OR_WRITE_TIMEOUT;
                    //如果该流是同步流并且可写
                    if (!stream.IsAsync && stream.CanWrite)
                        stream.Write(byteArrayContent, 0, byteArrayContent.Length);
                    else if (stream.CanWrite)//异步流并且可写
                        stream.BeginWrite(byteArrayContent, 0, byteArrayContent.Length, this.End_CreateFileCallBack, stream);

                    stream.Close();
                }
            }

        }

        private void End_CreateFileCallBack(IAsyncResult ar)
        {
            //从IAsyncResult对象中得到原来的FileStream
            var stream = ar.AsyncState as FileStream;
            //结束异步写

            Console.WriteLine("异步创建文件地址：{0}", stream.Name);
            stream.EndWrite(ar);
            Console.ReadLine();
        }
    }
}
