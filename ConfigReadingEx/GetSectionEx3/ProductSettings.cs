using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetSectionEx3
{
    public class ProductSettings : ConfigurationSection
    {
        [ConfigurationProperty("DellSettings")]
        public DellFeatures DellFeatures
        {
            get
            {
                return (DellFeatures)this["DellSettings"];
            }
            set
            {
                value = (DellFeatures)this["DellSettings"];
            }
        }
    }
}
