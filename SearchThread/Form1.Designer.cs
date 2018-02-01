namespace SearchThread
{
    partial class ThreadSearchForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSthread = new System.Windows.Forms.Button();
            this.buttonMthread = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 0;
            // 
            // buttonSthread
            // 
            this.buttonSthread.Location = new System.Drawing.Point(147, 13);
            this.buttonSthread.Name = "buttonSthread";
            this.buttonSthread.Size = new System.Drawing.Size(150, 43);
            this.buttonSthread.TabIndex = 1;
            this.buttonSthread.Text = "single thread search";
            this.buttonSthread.UseVisualStyleBackColor = true;
            this.buttonSthread.Click += new System.EventHandler(this.ButtonSthread_Click);
            // 
            // buttonMthread
            // 
            this.buttonMthread.Location = new System.Drawing.Point(320, 13);
            this.buttonMthread.Name = "buttonMthread";
            this.buttonMthread.Size = new System.Drawing.Size(131, 43);
            this.buttonMthread.TabIndex = 2;
            this.buttonMthread.Text = "Multi thread search";
            this.buttonMthread.UseVisualStyleBackColor = true;
            this.buttonMthread.Click += new System.EventHandler(this.ButtonMthread_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(23, 78);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(415, 304);
            this.listBox1.TabIndex = 3;
            // 
            // ThreadSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 415);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonMthread);
            this.Controls.Add(this.buttonSthread);
            this.Controls.Add(this.textBox1);
            this.Name = "ThreadSearchForm";
            this.Text = "Search For Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonSthread;
        private System.Windows.Forms.Button buttonMthread;
        private System.Windows.Forms.ListBox listBox1;
    }
}

