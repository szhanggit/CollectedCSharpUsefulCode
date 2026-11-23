using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class AppSettingsHandler
    {
        private string _filename;
        private AppSettings _config;

        public AppSettingsHandler(string filename)
        {
            _filename = filename;
            _config = GetAppSettings();
        }

        public AppSettings GetAppSettings()
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile(_filename, false, true)
               .Build();

            return config.GetSection("App").Get<AppSettings>();
        }
    }
}
