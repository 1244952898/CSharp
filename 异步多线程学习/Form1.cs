using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 异步多线程学习
{
  
    public partial class Form1 : Form
    {
        public delegate void doSomeMethodDelegate(string name);
        //  public event doSomeDelegate event;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Async_Click(object sender, EventArgs e)
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++btn_Async_Click {0} 开始", Thread.CurrentThread.ManagedThreadId);

          
            doSomeMethodDelegate doSomeMethod = new doSomeMethodDelegate(DoSomeThing);

            IAsyncResult asyncResult = null;

            AsyncCallback asyncCallback = x => {
                Console.WriteLine(asyncResult.Equals(x));
                Console.WriteLine(x.AsyncState);
                Console.WriteLine("回调函数！");
            };
            
           //asyncResult = doSomeMethod.BeginInvoke("btn_Async_Click", asyncCallback, "abcdefg");
            //asyncResult = doSomeMethod.BeginInvoke("btn_Async_Click", x => {
            //    Console.WriteLine(x.AsyncState);
            //    Console.WriteLine("回调函数！");
            //}, "abcdefg");

            //int i = 1;
            //while (!asyncResult.IsCompleted)
            //{
            //    Console.WriteLine("+++++++++++正在计算中！++++++++++ + 已经完成 {0}", 10 * i++);
            //    Thread.Sleep(100);
            //}

            //asyncResult.AsyncWaitHandle.WaitOne();
            //asyncResult.AsyncWaitHandle.WaitOne(100);
            //asyncResult.AsyncWaitHandle.WaitOne(1000);

            //doSomeMethod.EndInvoke(asyncResult);

            Func<int, string> func = x => {
                DoSomeThing("btn_Async_Click");
                return "2017----";
            } ;
            asyncResult = func.BeginInvoke(DateTime.Now.Millisecond, x =>
            {
                Console.WriteLine(x.AsyncState);
                Console.WriteLine("这里是回调函数 {0}", Thread.CurrentThread.ManagedThreadId);
            }, "AlwaysOnline");

            string sresult = func.EndInvoke(asyncResult);

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++btn_Async_Click {0} 结束", Thread.CurrentThread.ManagedThreadId);

        }

        private void DoSomeThing(string name) {

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++DoSomeThing {0} 开始", Thread.CurrentThread.ManagedThreadId);

            long result = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                result += i;
            }
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++DoSomeThing {0} 结束", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
