using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBase
{
    [Serializable]
    public class SBase
    {
        public string AccountName { get; set; }
        public string AccountPwd { get; set; }
        public string url { get; set; }
    }
}
