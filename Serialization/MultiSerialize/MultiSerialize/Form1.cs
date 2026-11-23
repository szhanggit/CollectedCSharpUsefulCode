using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;
using System.IO;

namespace MultiSerialize
{
    public partial class Form1 : Form
    {
        string n, nn, p, m, fn, Success;
        public Form1()
        {
            InitializeComponent();
        }

        private void XmlBtn_Click(object sender, EventArgs e)
        {
            n = this.Nm.Text;
            nn = this.NNm.Text;
            p = this.Pwd.Text;
            m = this.Msg.Text;
            fn = this.FileName.Text;
            Success = "XML 输出成功";
            PersonName Pn = new PersonName(n, nn, p, m);
            XmlSerializer Xs = new XmlSerializer(typeof(PersonName), new Type[] { typeof(PersonOther) });
            Stream fs = new FileStream(fn, FileMode.Create, FileAccess.Write, FileShare.None);
            Xs.Serialize(fs, Pn);
            fs.Close();
            MessageBox.Show(Success);
        }

        private void BinBtn_Click(object sender, EventArgs e)
        {
            IFormatter Fmt = new BinaryFormatter();
            Success = "二进制输出成功";
            UseIFormatter(Fmt, Success);
        }

        private void SoapBtn_Click(object sender, EventArgs e)
        {
            IFormatter Fmt = new SoapFormatter();
            Success = "Soap 输出成功";
            UseIFormatter(Fmt, Success);
        }

        private void UseIFormatter(IFormatter Fmt, string Success)
		{
			n = this.Nm.Text;
			nn = this.NNm.Text;
			p = this.Pwd.Text;
			m = this.Msg.Text;
			fn = this.FileName.Text;
			PersonName Pn = new PersonName(n ,nn, p, m);
			Stream fs = new FileStream(fn, FileMode.Create, FileAccess.Write, FileShare.None);
			Fmt.Serialize(fs, Pn);
			fs.Close();
			MessageBox.Show(Success);
		}		
    }

	[Serializable]
	public class PersonName
	{
		public string _name;
			
		[NonSerialized]
		public string _nickname;
		public PersonOther Po = new PersonOther();
		public PersonName(){}
		public PersonName(string n, string nn, string p, string m)
		{
			this._name = n;
			this._nickname = nn;
			this.Po.Password = p;
			this.Po.Message = m;
		}
	}
		
	[Serializable]
	public class PersonOther
	{
		string _password;
		string _message;
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
			}
		}
		public string Message
		{
			get
			{
				return _message;
			}
			set
			{
				_message = value;
			}
		}
		public PersonOther(){}
	}
}
