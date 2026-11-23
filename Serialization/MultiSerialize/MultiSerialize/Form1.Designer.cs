namespace MultiSerialize
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Msg = new System.Windows.Forms.TextBox();
            this.Pwd = new System.Windows.Forms.TextBox();
            this.NNm = new System.Windows.Forms.TextBox();
            this.Nm = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.XmlBtn = new System.Windows.Forms.Button();
            this.SoapBtn = new System.Windows.Forms.Button();
            this.BinBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Msg);
            this.groupBox1.Controls.Add(this.Pwd);
            this.groupBox1.Controls.Add(this.NNm);
            this.groupBox1.Controls.Add(this.Nm);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "资料填写";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "昵称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "姓名";
            // 
            // Msg
            // 
            this.Msg.Location = new System.Drawing.Point(95, 114);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(143, 20);
            this.Msg.TabIndex = 3;
            // 
            // Pwd
            // 
            this.Pwd.Location = new System.Drawing.Point(95, 88);
            this.Pwd.Name = "Pwd";
            this.Pwd.Size = new System.Drawing.Size(143, 20);
            this.Pwd.TabIndex = 2;
            // 
            // NNm
            // 
            this.NNm.Location = new System.Drawing.Point(95, 62);
            this.NNm.Name = "NNm";
            this.NNm.Size = new System.Drawing.Size(143, 20);
            this.NNm.TabIndex = 1;
            // 
            // Nm
            // 
            this.Nm.Location = new System.Drawing.Point(95, 34);
            this.Nm.Name = "Nm";
            this.Nm.Size = new System.Drawing.Size(143, 20);
            this.Nm.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.XmlBtn);
            this.groupBox2.Controls.Add(this.SoapBtn);
            this.groupBox2.Controls.Add(this.BinBtn);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.FileName);
            this.groupBox2.Location = new System.Drawing.Point(12, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 109);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出格式";
            // 
            // XmlBtn
            // 
            this.XmlBtn.Location = new System.Drawing.Point(172, 66);
            this.XmlBtn.Name = "XmlBtn";
            this.XmlBtn.Size = new System.Drawing.Size(75, 23);
            this.XmlBtn.TabIndex = 10;
            this.XmlBtn.Text = "XML格式";
            this.XmlBtn.UseVisualStyleBackColor = true;
            this.XmlBtn.Click += new System.EventHandler(this.XmlBtn_Click);
            // 
            // SoapBtn
            // 
            this.SoapBtn.Location = new System.Drawing.Point(91, 66);
            this.SoapBtn.Name = "SoapBtn";
            this.SoapBtn.Size = new System.Drawing.Size(75, 23);
            this.SoapBtn.TabIndex = 9;
            this.SoapBtn.Text = "Soap格式";
            this.SoapBtn.UseVisualStyleBackColor = true;
            this.SoapBtn.Click += new System.EventHandler(this.SoapBtn_Click);
            // 
            // BinBtn
            // 
            this.BinBtn.Location = new System.Drawing.Point(10, 66);
            this.BinBtn.Name = "BinBtn";
            this.BinBtn.Size = new System.Drawing.Size(75, 23);
            this.BinBtn.TabIndex = 2;
            this.BinBtn.Text = "二进制格式";
            this.BinBtn.UseVisualStyleBackColor = true;
            this.BinBtn.Click += new System.EventHandler(this.BinBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "输出文件名";
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(95, 28);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(143, 20);
            this.FileName.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 306);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "对象不同格式序列化";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Msg;
        private System.Windows.Forms.TextBox Pwd;
        private System.Windows.Forms.TextBox NNm;
        private System.Windows.Forms.TextBox Nm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button XmlBtn;
        private System.Windows.Forms.Button SoapBtn;
        private System.Windows.Forms.Button BinBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FileName;
    }
}

