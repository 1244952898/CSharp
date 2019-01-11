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
            this.btnFor.Location = new System.Drawing.Point(49, 118);
            this.btnFor.Name = "btnFor";
            this.btnFor.Size = new System.Drawing.Size(75, 23);
            this.btnFor.TabIndex = 1;
            this.btnFor.Text = "多线程循环";
            this.btnFor.UseVisualStyleBackColor = true;
            this.btnFor.Click += new System.EventHandler(this.btnFor_Click);
            // 
            // btnAsyc
            // 
            this.btnAsyc.Location = new System.Drawing.Point(49, 167);
            this.btnAsyc.Name = "btnAsyc";
            this.btnAsyc.Size = new System.Drawing.Size(75, 23);
            this.btnAsyc.TabIndex = 2;
            this.btnAsyc.Text = "Async";
            this.btnAsyc.UseVisualStyleBackColor = true;
            this.btnAsyc.Click += new System.EventHandler(this.btnAsyc_Click);
            // 
            // btnThread
            // 
            this.btnThread.Location = new System.Drawing.Point(49, 79);
            this.btnThread.Name = "btnThread";
            this.btnThread.Size = new System.Drawing.Size(75, 23);
            this.btnThread.TabIndex = 3;
            this.btnThread.Text = "Thread";
            this.btnThread.UseVisualStyleBackColor = true;
            this.btnThread.Click += new System.EventHandler(this.btnThread_Click);
            // 
            // btnCalBack
            // 
            this.btnCalBack.Location = new System.Drawing.Point(151, 79);
            this.btnCalBack.Name = "btnCalBack";
            this.btnCalBack.Size = new System.Drawing.Size(111, 23);
            this.btnCalBack.TabIndex = 4;
            this.btnCalBack.Text = "Thread自定义返回";
            this.btnCalBack.UseVisualStyleBackColor = true;
            this.btnCalBack.Click += new System.EventHandler(this.btnCalBack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 683);
            this.Controls.Add(this.btnCalBack);
            this.Controls.Add(this.btnThread);
            this.Controls.Add(this.btnAsyc);
            this.Controls.Add(this.btnFor);
            this.Controls.Add(this.btn_Async);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Async;
        private System.Windows.Forms.Button btnFor;
        private System.Windows.Forms.Button btnAsyc;
        private System.Windows.Forms.Button btnThread;
        private System.Windows.Forms.Button btnCalBack;
    }
}

