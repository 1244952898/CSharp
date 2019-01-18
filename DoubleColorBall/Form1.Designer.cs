namespace DoubleColorBall
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnOver = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblB1 = new System.Windows.Forms.Label();
            this.lblB2 = new System.Windows.Forms.Label();
            this.lblB3 = new System.Windows.Forms.Label();
            this.lblB4 = new System.Windows.Forms.Label();
            this.lblB5 = new System.Windows.Forms.Label();
            this.lblR6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(160, 214);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnOver
            // 
            this.btnOver.Location = new System.Drawing.Point(363, 214);
            this.btnOver.Name = "btnOver";
            this.btnOver.Size = new System.Drawing.Size(75, 23);
            this.btnOver.TabIndex = 1;
            this.btnOver.Text = "结束";
            this.btnOver.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblR6);
            this.groupBox1.Controls.Add(this.lblB5);
            this.groupBox1.Controls.Add(this.lblB4);
            this.groupBox1.Controls.Add(this.lblB3);
            this.groupBox1.Controls.Add(this.lblB2);
            this.groupBox1.Controls.Add(this.lblB1);
            this.groupBox1.Location = new System.Drawing.Point(113, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lblB1
            // 
            this.lblB1.AutoSize = true;
            this.lblB1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblB1.Location = new System.Drawing.Point(22, 48);
            this.lblB1.Name = "lblB1";
            this.lblB1.Size = new System.Drawing.Size(17, 12);
            this.lblB1.TabIndex = 0;
            this.lblB1.Text = "00";
            // 
            // lblB2
            // 
            this.lblB2.AutoSize = true;
            this.lblB2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblB2.Location = new System.Drawing.Point(82, 48);
            this.lblB2.Name = "lblB2";
            this.lblB2.Size = new System.Drawing.Size(17, 12);
            this.lblB2.TabIndex = 1;
            this.lblB2.Text = "00";
            // 
            // lblB3
            // 
            this.lblB3.AutoSize = true;
            this.lblB3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblB3.Location = new System.Drawing.Point(142, 48);
            this.lblB3.Name = "lblB3";
            this.lblB3.Size = new System.Drawing.Size(17, 12);
            this.lblB3.TabIndex = 2;
            this.lblB3.Text = "00";
            // 
            // lblB4
            // 
            this.lblB4.AutoSize = true;
            this.lblB4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblB4.Location = new System.Drawing.Point(202, 48);
            this.lblB4.Name = "lblB4";
            this.lblB4.Size = new System.Drawing.Size(17, 12);
            this.lblB4.TabIndex = 3;
            this.lblB4.Text = "00";
            // 
            // lblB5
            // 
            this.lblB5.AutoSize = true;
            this.lblB5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblB5.Location = new System.Drawing.Point(262, 48);
            this.lblB5.Name = "lblB5";
            this.lblB5.Size = new System.Drawing.Size(17, 12);
            this.lblB5.TabIndex = 4;
            this.lblB5.Text = "00";
            // 
            // lblR6
            // 
            this.lblR6.AutoSize = true;
            this.lblR6.ForeColor = System.Drawing.Color.Red;
            this.lblR6.Location = new System.Drawing.Point(322, 48);
            this.lblR6.Name = "lblR6";
            this.lblR6.Size = new System.Drawing.Size(17, 12);
            this.lblR6.TabIndex = 5;
            this.lblR6.Text = "00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 309);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOver);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnOver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblR6;
        private System.Windows.Forms.Label lblB5;
        private System.Windows.Forms.Label lblB4;
        private System.Windows.Forms.Label lblB3;
        private System.Windows.Forms.Label lblB2;
        private System.Windows.Forms.Label lblB1;
    }
}

