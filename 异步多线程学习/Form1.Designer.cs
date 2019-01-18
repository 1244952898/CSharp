namespace 异步多线程学习
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Async = new System.Windows.Forms.Button();
            this.btnFor = new System.Windows.Forms.Button();
            this.btnAsyc = new System.Windows.Forms.Button();
            this.btnThread = new System.Windows.Forms.Button();
            this.btnCalBack = new System.Windows.Forms.Button();
            this.btnPara = new System.Windows.Forms.Button();
            this.btnpool = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnTask = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Async
            // 
            this.btn_Async.Location = new System.Drawing.Point(49, 12);
            this.btn_Async.Name = "btn_Async";
            this.btn_Async.Size = new System.Drawing.Size(75, 23);
            this.btn_Async.TabIndex = 0;
            this.btn_Async.Text = "异步";
            this.btn_Async.UseVisualStyleBackColor = true;
            this.btn_Async.Click += new System.EventHandler(this.btn_Async_Click);
            // 
            // btnFor
            // 
            this.btnFor.Location = new System.Drawing.Point(49, 70);
            this.btnFor.Name = "btnFor";
            this.btnFor.Size = new System.Drawing.Size(75, 23);
            this.btnFor.TabIndex = 1;
            this.btnFor.Text = "多线程循环";
            this.btnFor.UseVisualStyleBackColor = true;
            this.btnFor.Click += new System.EventHandler(this.btnFor_Click);
            // 
            // btnAsyc
            // 
            this.btnAsyc.Location = new System.Drawing.Point(49, 99);
            this.btnAsyc.Name = "btnAsyc";
            this.btnAsyc.Size = new System.Drawing.Size(75, 23);
            this.btnAsyc.TabIndex = 2;
            this.btnAsyc.Text = "Async";
            this.btnAsyc.UseVisualStyleBackColor = true;
            this.btnAsyc.Click += new System.EventHandler(this.btnAsyc_Click);
            // 
            // btnThread
            // 
            this.btnThread.Location = new System.Drawing.Point(49, 41);
            this.btnThread.Name = "btnThread";
            this.btnThread.Size = new System.Drawing.Size(75, 23);
            this.btnThread.TabIndex = 3;
            this.btnThread.Text = "Thread";
            this.btnThread.UseVisualStyleBackColor = true;
            this.btnThread.Click += new System.EventHandler(this.btnThread_Click);
            // 
            // btnCalBack
            // 
            this.btnCalBack.Location = new System.Drawing.Point(130, 41);
            this.btnCalBack.Name = "btnCalBack";
            this.btnCalBack.Size = new System.Drawing.Size(111, 23);
            this.btnCalBack.TabIndex = 4;
            this.btnCalBack.Text = "Thread自定义返回";
            this.btnCalBack.UseVisualStyleBackColor = true;
            this.btnCalBack.Click += new System.EventHandler(this.btnCalBack_Click);
            // 
            // btnPara
            // 
            this.btnPara.Location = new System.Drawing.Point(247, 41);
            this.btnPara.Name = "btnPara";
            this.btnPara.Size = new System.Drawing.Size(111, 23);
            this.btnPara.TabIndex = 5;
            this.btnPara.Text = "Thread自定义返回有参数";
            this.btnPara.UseVisualStyleBackColor = true;
            this.btnPara.Click += new System.EventHandler(this.btnPara_Click);
            // 
            // btnpool
            // 
            this.btnpool.Location = new System.Drawing.Point(49, 137);
            this.btnpool.Name = "btnpool";
            this.btnpool.Size = new System.Drawing.Size(75, 23);
            this.btnpool.TabIndex = 6;
            this.btnpool.Text = "Threadpool";
            this.btnpool.UseVisualStyleBackColor = true;
            this.btnpool.Click += new System.EventHandler(this.btnpool_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Threadpool子线程执行完1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Threadpool子线程执行完2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(204, 195);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Threadpool子线程执行完3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(204, 224);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(154, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Threadpool子线程执行完4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnTask
            // 
            this.btnTask.Location = new System.Drawing.Point(49, 263);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(75, 23);
            this.btnTask.TabIndex = 11;
            this.btnTask.Text = "Task";
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(141, 263);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Task1";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(222, 263);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(87, 23);
            this.button6.TabIndex = 13;
            this.button6.Text = "Task_WhenAny";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(49, 311);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(87, 23);
            this.button7.TabIndex = 14;
            this.button7.Text = "Parallel";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(141, 311);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(87, 23);
            this.button8.TabIndex = 15;
            this.button8.Text = "Parallel1";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(49, 360);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(87, 23);
            this.button9.TabIndex = 16;
            this.button9.Text = "异常";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(154, 360);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(87, 23);
            this.button10.TabIndex = 17;
            this.button10.Text = "异常1";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(234, 311);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(87, 23);
            this.button11.TabIndex = 18;
            this.button11.Text = "Parallel异常";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(49, 407);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(87, 23);
            this.button12.TabIndex = 19;
            this.button12.Text = "线程取消";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(389, 1);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(87, 23);
            this.button14.TabIndex = 21;
            this.button14.Text = "测试";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(49, 447);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(87, 23);
            this.button13.TabIndex = 22;
            this.button13.Text = "数据重复";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(49, 486);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(87, 23);
            this.button15.TabIndex = 23;
            this.button15.Text = "lock";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(49, 525);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(87, 23);
            this.button16.TabIndex = 24;
            this.button16.Text = "Async";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 632);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnTask);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnpool);
            this.Controls.Add(this.btnPara);
            this.Controls.Add(this.btnCalBack);
            this.Controls.Add(this.btnThread);
            this.Controls.Add(this.btnAsyc);
            this.Controls.Add(this.btnFor);
            this.Controls.Add(this.btn_Async);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Async;
        private System.Windows.Forms.Button btnFor;
        private System.Windows.Forms.Button btnAsyc;
        private System.Windows.Forms.Button btnThread;
        private System.Windows.Forms.Button btnCalBack;
        private System.Windows.Forms.Button btnPara;
        private System.Windows.Forms.Button btnpool;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnTask;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
    }
}

