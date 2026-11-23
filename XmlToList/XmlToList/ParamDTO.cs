using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToList
{
    public class ParamDTO
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public ParamDTO() { }
        public ParamDTO(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
