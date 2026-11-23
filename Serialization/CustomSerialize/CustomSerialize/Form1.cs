using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace CustomSerialize
{
    public partial class Form1 : Form
    {
        string fn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = false;
            this.groupBox3.Enabled = false;
        }

        private void PathBtn_Click(object sender, EventArgs e)
        {
            fn = PathTxt.Text;
            PathLabel.Text = fn;
            this.groupBox1.Enabled = false;
            this.groupBox2.Enabled = true;
            this.groupBox3.Enabled = true;
        }

        private void SerBtn_Click(object sender, EventArgs e)
        {
            Details Dt = new Details();
            Dt.Name = nametxt.Text;
            Dt.NickName = nicknametxt.Text;
            IFormatter Fmt = new BinaryFormatter();
            Stream fs = new FileStream(fn, FileMode.Create, FileAccess.Write, FileShare.None);
            Fmt.Serialize(fs, Dt);
            fs.Close();
            MessageBox.Show("序列化完成");
        }

        private void DeserBtn_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(fn, FileMode.Open);
                IFormatter Fmt = new BinaryFormatter();
                Details Dt = (Details)Fmt.Deserialize(fs);
                nametxtnew.Text = Dt.Name;
                nicknametxtnew.Text = Dt.NickName;
            }
            catch (FileNotFoundException ex)
            {
                string str = String.Format("异常信息：{0}", ex.Message);
                MessageBox.Show(str);
            }
        }
    }

    [Serializable]
    public class Details : ISerializable
    {
        string _name;
        string _nickname;
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
        public string NickName
        {
            get
            {
                return _nickname;
            }
            set
            {
                _nickname = value;
            }
        }
        public Details() { }
        private Details(SerializationInfo inputinfo, StreamingContext sc)
        {
            int i;
            _name = inputinfo.GetString("Person Name");
            i = _name.IndexOf('>') + 1;
            _name = _name.Substring(i);
            _nickname = inputinfo.GetString("Person NickName");
            i = _nickname.IndexOf('>') + 1;
            _nickname = _nickname.Substring(i);
        }

        void ISerializable.GetObjectData(SerializationInfo outputinfo, StreamingContext sc)
        {
            outputinfo.AddValue("Person Name", "The boy's name is --> " + _name);
            outputinfo.AddValue("Person NickName", "The boy's nickname is --> " + _nickname);
        }
    }
}
