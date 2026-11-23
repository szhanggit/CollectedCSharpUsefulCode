using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSerialize
{
    public class PersonDetail
    {
        String _name; String _password;
        public String Name { get { return _name; } set { _name = value; } }
        public String Password { get { return _password; } set { _password = value; } }
        public PersonDetail() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String n, password;
            List<PersonDetail> list = new List<PersonDetail>{new PersonDetail{Name="Steven", Password="password"}, new PersonDetail{Name="Yiding", Password="password2"}};
            List<PersonDetail> readlist = new List<PersonDetail>();

            String fn = "FileName.txt";
            System.Xml.Serialization.XmlSerializer Xs = new System.Xml.Serialization.XmlSerializer(typeof(List<PersonDetail>));
            System.IO.Stream fs = new System.IO.FileStream(fn, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None);
            Xs.Serialize(fs, list);
            fs.Close();

            try {
                System.IO.FileStream fs2 = new System.IO.FileStream(fn, System.IO.FileMode.Open);
                readlist = (List<PersonDetail>)Xs.Deserialize(fs2);
                foreach (PersonDetail Pd in readlist)
                {
                    n = Pd.Name;
                    password = Pd.Password;
                }
            }catch(System.IO.FileNotFoundException){}
        }
    }
}
