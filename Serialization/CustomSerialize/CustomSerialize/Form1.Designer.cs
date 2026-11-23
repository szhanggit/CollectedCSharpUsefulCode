namespace CustomSerialize
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
            this.PathBtn = new System.Windows.Forms.Button();
            this.PathTxt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SerBtn = new System.Windows.Forms.Button();
            this.nicknametxt = new System.Windows.Forms.TextBox();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DeserBtn = new System.Windows.Forms.Button();
            this.nicknametxtnew = new System.Windows.Forms.TextBox();
            this.nametxtnew = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PathLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PathBtn);
            this.groupBox1.Controls.Add(this.PathTxt);
            this.groupBox1.Location = new System.Drawing.Point(12, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件路径";
            // 
            // PathBtn
            // 
            this.PathBtn.Location = new System.Drawing.Point(207, 18);
            this.PathBtn.Name = "PathBtn";
            this.PathBtn.Size = new System.Drawing.Size(124, 20);
            this.PathBtn.TabIndex = 1;
            this.PathBtn.Text = "确定路径";
            this.PathBtn.UseVisualStyleBackColor = true;
            this.PathBtn.Click += new System.EventHandler(this.PathBtn_Click);
            // 
            // PathTxt
            // 
            this.PathTxt.Location = new System.Drawing.Point(6, 19);
            this.PathTxt.Name = "PathTxt";
            this.PathTxt.Size = new System.Drawing.Size(173, 20);
            this.PathTxt.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SerBtn);
            this.groupBox2.Controls.Add(this.nicknametxt);
            this.groupBox2.Controls.Add(this.nametxt);
            this.groupBox2.Location = new System.Drawing.Point(12, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 50);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "原始对象数据";
            // 
            // SerBtn
            // 
            this.SerBtn.Location = new System.Drawing.Point(413, 18);
            this.SerBtn.Name = "SerBtn";
            this.SerBtn.Size = new System.Drawing.Size(124, 20);
            this.SerBtn.TabIndex = 2;
            this.SerBtn.Text = "序列化";
            this.SerBtn.UseVisualStyleBackColor = true;
            this.SerBtn.Click += new System.EventHandler(this.SerBtn_Click);
            // 
            // nicknametxt
            // 
            this.nicknametxt.Location = new System.Drawing.Point(207, 19);
            this.nicknametxt.Name = "nicknametxt";
            this.nicknametxt.Size = new System.Drawing.Size(173, 20);
            this.nicknametxt.TabIndex = 4;
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(6, 19);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(173, 20);
            this.nametxt.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DeserBtn);
            this.groupBox3.Controls.Add(this.nicknametxtnew);
            this.groupBox3.Controls.Add(this.nametxtnew);
            this.groupBox3.Location = new System.Drawing.Point(12, 200);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 50);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "新建对象数据";
            // 
            // DeserBtn
            // 
            this.DeserBtn.Location = new System.Drawing.Point(413, 18);
            this.DeserBtn.Name = "DeserBtn";
            this.DeserBtn.Size = new System.Drawing.Size(124, 20);
            this.DeserBtn.TabIndex = 5;
            this.DeserBtn.Text = "反序列化";
            this.DeserBtn.UseVisualStyleBackColor = true;
            this.DeserBtn.Click += new System.EventHandler(this.DeserBtn_Click);
            // 
            // nicknametxtnew
            // 
            this.nicknametxtnew.Location = new System.Drawing.Point(207, 19);
            this.nicknametxtnew.Name = "nicknametxtnew";
            this.nicknametxtnew.Size = new System.Drawing.Size(173, 20);
            this.nicknametxtnew.TabIndex = 5;
            // 
            // nametxtnew
            // 
            this.nametxtnew.Location = new System.Drawing.Point(6, 19);
            this.nametxtnew.Name = "nametxtnew";
            this.nametxtnew.Size = new System.Drawing.Size(173, 20);
            this.nametxtnew.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "序列化文件路径：";
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(216, 159);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(0, 13);
            this.PathLabel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 262);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "定制序列化";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button PathBtn;
        private System.Windows.Forms.TextBox PathTxt;
        private System.Windows.Forms.Button SerBtn;
        private System.Windows.Forms.TextBox nicknametxt;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Button DeserBtn;
        private System.Windows.Forms.TextBox nicknametxtnew;
        private System.Windows.Forms.TextBox nametxtnew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PathLabel;
    }
}

