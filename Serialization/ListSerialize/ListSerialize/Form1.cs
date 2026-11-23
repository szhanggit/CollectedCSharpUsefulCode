using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace ListSerialize
{
    public partial class Form1 : Form
    {
        List<PersonDetail> list = new List<PersonDetail>();
        List<PersonDetail> readlist;
        string fn;
        public Form1()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            PersonDetail Pd = new PersonDetail();
            Pd.Name = nametxt.Text;
            Pd.Password = passwordtxt.Text;
            list.Add(Pd);
            MessageBox.Show("添加成功");
        }

        private void OutputBtn_Click(object sender, EventArgs e)
        {
            fn = FileName.Text;
            XmlSerializer Xs = new XmlSerializer(typeof(List<PersonDetail>));
            Stream fs = new FileStream(fn, FileMode.Create, FileAccess.Write, FileShare.None);
            Xs.Serialize(fs, list);
            fs.Close();
            MessageBox.Show("XML 序列化成功");
            nametxt.Text = "";
            passwordtxt.Text = "";
            FileName.Text = "";
        }

        private void InputBtn_Click(object sender, EventArgs e)
        {
            string str;
            fn = ReadFileName.Text;
            try
            {
                FileStream fs = new FileStream(fn, FileMode.Open);
                XmlSerializer Xs = new XmlSerializer(typeof(List<PersonDetail>));
                readlist = (List<PersonDetail>)Xs.Deserialize(fs);
                foreach (PersonDetail Pd in readlist)
                {
                    str = String.Format("姓名：[{0}]，密码：[{1}]", Pd.Name, Pd.Password);
                    XmlList.Items.Add(str);
                }
            }
            catch (FileNotFoundException ex)
            {
                string msg = String.Format("异常信息：{0}", ex.Message);
                MessageBox.Show(msg);
            }
            ReadFileName.Text = "";
        }
    }

    public class PersonDetail
    {
        string _name;
        string _password;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
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
        public PersonDetail() { }
    }
}
