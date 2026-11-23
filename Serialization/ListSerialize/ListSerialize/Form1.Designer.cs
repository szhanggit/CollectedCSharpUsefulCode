namespace ListSerialize
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.InputBtn = new System.Windows.Forms.Button();
            this.ReadFileName = new System.Windows.Forms.TextBox();
            this.FileName = new System.Windows.Forms.TextBox();
            this.OutputBtn = new System.Windows.Forms.Button();
            this.XmlList = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddBtn);
            this.groupBox1.Controls.Add(this.passwordtxt);
            this.groupBox1.Controls.Add(this.nametxt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加数据";
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(312, 19);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(82, 20);
            this.AddBtn.TabIndex = 4;
            this.AddBtn.Text = "添加";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new System.Drawing.Point(165, 19);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(127, 20);
            this.passwordtxt.TabIndex = 3;
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(6, 19);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(127, 20);
            this.nametxt.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.XmlList);
            this.groupBox2.Controls.Add(this.InputBtn);
            this.groupBox2.Controls.Add(this.ReadFileName);
            this.groupBox2.Location = new System.Drawing.Point(12, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 301);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "加载数据";
            // 
            // InputBtn
            // 
            this.InputBtn.Location = new System.Drawing.Point(312, 30);
            this.InputBtn.Name = "InputBtn";
            this.InputBtn.Size = new System.Drawing.Size(82, 20);
            this.InputBtn.TabIndex = 6;
            this.InputBtn.Text = "XML反序列化";
            this.InputBtn.UseVisualStyleBackColor = true;
            this.InputBtn.Click += new System.EventHandler(this.InputBtn_Click);
            // 
            // ReadFileName
            // 
            this.ReadFileName.Location = new System.Drawing.Point(165, 31);
            this.ReadFileName.Name = "ReadFileName";
            this.ReadFileName.Size = new System.Drawing.Size(127, 20);
            this.ReadFileName.TabIndex = 6;
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(177, 90);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(127, 20);
            this.FileName.TabIndex = 5;
            // 
            // OutputBtn
            // 
            this.OutputBtn.Location = new System.Drawing.Point(324, 89);
            this.OutputBtn.Name = "OutputBtn";
            this.OutputBtn.Size = new System.Drawing.Size(82, 20);
            this.OutputBtn.TabIndex = 5;
            this.OutputBtn.Text = "输出XML";
            this.OutputBtn.UseVisualStyleBackColor = true;
            this.OutputBtn.Click += new System.EventHandler(this.OutputBtn_Click);
            // 
            // XmlList
            // 
            this.XmlList.FormattingEnabled = true;
            this.XmlList.Location = new System.Drawing.Point(13, 67);
            this.XmlList.Name = "XmlList";
            this.XmlList.Size = new System.Drawing.Size(381, 225);
            this.XmlList.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 429);
            this.Controls.Add(this.OutputBtn);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "序列化集合和反序列化";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.Button InputBtn;
        private System.Windows.Forms.TextBox ReadFileName;
        private System.Windows.Forms.Button OutputBtn;
        private System.Windows.Forms.ListBox XmlList;
    }
}

