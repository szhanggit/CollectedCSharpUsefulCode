using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmailTemplateProcessing
{
    [DataContract]
    public class ParamDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Value { get; set; }

        public ParamDTO() { }
        public ParamDTO(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
