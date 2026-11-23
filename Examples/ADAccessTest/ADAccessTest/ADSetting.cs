using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADAccessTest
{
    public class ADSetting
    {
        private string name;
        private string adserver;
        private string aduser;
        private string adpassword;
        private string adfullpath;
        private bool isdefault;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ADServer
        {
            get { return adserver; }
            set { adserver = value; }
        }

        public string ADFullPath
        {
            get { return adfullpath; }
            set { adfullpath = value; }
        }

        public string ADUser
        {
            get { return aduser; }
            set { aduser = value; }
        }

        public string ADPassword
        {
            get { return adpassword; }
            set { adpassword = value; }
        }

        public bool IsDefault
        {
            get { return isdefault; }
            set { isdefault = value; }
        }


        public ADSetting(string name,
            string adserver,
            string aduser,
            string adpassword,
            string adfullpath,
            bool isdefault)
        {
            this.name = name;
            this.adserver = adserver;
            this.aduser = aduser;
            this.adpassword = adpassword;
            this.adfullpath = adfullpath;
            this.isdefault = isdefault;
        }

        public ADSetting() { }
    }
}
