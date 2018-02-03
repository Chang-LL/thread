namespace FactorThread
{
    partial class FrmCalculate
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
            this.buttonFactors = new System.Windows.Forms.Button();
            this.buttonFactorials = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // buttonFactors
            // 
            this.buttonFactors.Location = new System.Drawing.Point(29, 23);
            this.buttonFactors.Name = "buttonFactors";
            this.buttonFactors.Size = new System.Drawing.Size(106, 45);
            this.buttonFactors.TabIndex = 0;
            this.buttonFactors.Text = "Calcuate Factors";
            this.buttonFactors.UseVisualStyleBackColor = true;
            this.buttonFactors.Click += new System.EventHandler(this.ButtonFactors_Click);
            // 
            // buttonFactorials
            // 
            this.buttonFactorials.Location = new System.Drawing.Point(199, 23);
            this.buttonFactorials.Name = "buttonFactorials";
            this.buttonFactorials.Size = new System.Drawing.Size(124, 45);
            this.buttonFactorials.TabIndex = 1;
            this.buttonFactorials.Text = "Calculate Factorials";
            this.buttonFactorials.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(21, 96);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(319, 221);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // FrmCalculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 346);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonFactorials);
            this.Controls.Add(this.buttonFactors);
            this.Name = "FrmCalculate";
            this.Text = "Main/Worker Thread Example";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFactors;
        private System.Windows.Forms.Button buttonFactorials;
        private System.Windows.Forms.ListView listView1;
    }
}

