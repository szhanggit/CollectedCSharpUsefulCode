using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetPostOfficeNameByPinCode
{
    [Serializable]
    public class PostOfficeResult
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public List<PostOffice> PostOffice { get; set; }
    }
}