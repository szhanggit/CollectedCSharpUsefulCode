using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToListEx
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ParamDTO> pa = new List<ParamDTO> {
                new ParamDTO { Id = 1, Name = "asdf0", CreatedDateTime = DateTime.Now },
                new ParamDTO { Id = 2, Name = "asdf1", CreatedDateTime = DateTime.Now },
                new ParamDTO { Id = 3, Name = "asdf2", CreatedDateTime = DateTime.Now },
                new ParamDTO { Id = 4, Name = "asdf3", CreatedDateTime = DateTime.Now },
                new ParamDTO { Id = 5, Name = "asdf4", CreatedDateTime = DateTime.Now },
                new ParamDTO { Id = 6, Name = "asdf5", CreatedDateTime = DateTime.Now },
            };
            string xmlStr = Helper.ListToXml<ParamDTO>(pa);
            var list = Helper.XmlToList<ParamDTO>(xmlStr);
        }
    }
}
