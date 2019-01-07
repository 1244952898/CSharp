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

            int i = 1;
            int l = 3;
            int k = i + 1;
            doSomeMethodDelegate doSomeMethod = new doSomeMethodDelegate(DoSomeThing);

            AsyncCallback asyncCallback = new AsyncCallback(x => Console.WriteLine("回调函数！"));

            doSomeMethod.BeginInvoke("btn_Async_Click", asyncCallback, null);

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++btn_Async_Click {0} 结束", Thread.CurrentThread.ManagedThreadId);

        }

        private void DoSomeThing(string name) {

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++DoSomeThing {0} 开始", Thread.CurrentThread.ManagedThreadId);

            long result = 0;
            for (int i = 0; i < 10000000; i++)
            {
                result += i;
            }
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++DoSomeThing {0} 结束", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
