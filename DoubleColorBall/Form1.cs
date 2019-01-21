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

namespace DoubleColorBall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string[] blueNums = { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Text = "开始。。";
            btnOver.Text = "结束";
            btnStart.Enabled = false;
            lblB1.Text = "00";
            lblB2.Text = "00";
            lblB3.Text = "00";
            lblB4.Text = "00";
            lblB5.Text = "00";
            lblR6.Text = "00";
            Thread.Sleep(555);
            TaskFactory taskFactory = new TaskFactory();
            //List<Task> tasks = new List<Task>();
            foreach (var contrl in this.groupBox1.Controls)
            {
                try
                {
                    if (contrl is Label)
                    {
                        Label lbl = (Label)contrl;
                        if (lbl.Name.Contains("R"))
                        {
                           Task task = taskFactory.StartNew(() => {
                               while (true)
                               {
                                   Thread.Sleep(300);
                                   Random random = new Random();
                                   var index = random.Next(0, blueNums.Length - 1);
                                   var txt = blueNums[index];
                                   Console.WriteLine(lbl.Name + " " + txt);
                                   Invoke(new Action(() => {
                                       lbl.Text = txt;
                                   }));
                               }
                            });
                         //   tasks.Add(task);
                        }
                        else if (lbl.Name.Contains("B"))
                        {
                            Task task = taskFactory.StartNew(() => {
                                while (true)
                                {
                                    Thread.Sleep(300);
                                    Random random = new Random();
                                    var index = random.Next(0, blueNums.Length - 1);
                                    var txt = blueNums[index];
                                    Console.WriteLine(lbl.Name + " " + txt);
                                    Invoke(new Action(() => {
                                        lbl.Text = txt;
                                    }));
                                }
                            });
                           // tasks.Add(task);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("异常：{0}", ex.Message);
                }
            }
           // Task.WaitAll(tasks.ToArray());
        }
    }
}
