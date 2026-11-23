using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPropertyValue
{
    public interface ICommonService {
        object GetPropValue(object src, string propName);
    }
    public class CommonService : ICommonService
    {
        public CommonService()
        {

        }

        public object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
