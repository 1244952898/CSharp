using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
   public class blockingCollectionClass
    {
        BlockingCollection<string> blockingCollection = new BlockingCollection<string>();
        FileStream f = new FileStream("D://1.txt", FileMode.Create, FileAccess.Write, FileShare.None);
        StreamWriter writer;
        public void Add(string Item)
        {
            blockingCollection.Add(Item);
        }
        public blockingCollectionClass()
        {
            writer = new StreamWriter(f);
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string value in blockingCollection.GetConsumingEnumerable())
            {
                Console.WriteLine(value);
                writer.WriteLine(value);
            }
        }
    }
}
