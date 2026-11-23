using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompressEx
{
    public static class ConfigureHelper
    {
        public static string ZipFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["ZipFilePath"].ToString();
            }
        }
    }
}
