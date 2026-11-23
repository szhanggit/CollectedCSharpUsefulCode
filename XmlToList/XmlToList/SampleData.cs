using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToList
{
    public class SampleData
    {
        public SampleData()
        {

        }

        public int MessageId { get; set; }
        public int MessageLocalId { get; set; }
        public DateTime CreateOn { get; set; }
        public string Parameters { get; set; }
        public string EmailTemplate { get; set; }
    }
}
