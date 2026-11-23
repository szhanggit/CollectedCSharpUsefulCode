using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemConfigEx
{
    public static class Helper
    {
        /// <summary>
        /// Gets a value indicating whether [enable certificate check].
        /// </summary>
        /// <value>
        /// <c>true</c> if [enable certificate check]; otherwise, <c>false</c>.
        /// </value>
        public static bool EnableCertificateCheck
        {
            get
            {
                var config = ConfigurationManager.AppSettings["EnableCertificateCheck"];
                if (config == null)
                    return true;

                return config.ToLower() != "false";
            }
        }

        public static bool PartialPublish
        {
            get
            {
                int _partialPublish = 0;
                int.TryParse(ConfigurationManager.AppSettings["PartialPublish"], out _partialPublish);
                return _partialPublish > 0;
            }
        }

        public static string QuotationNumber
        {
            get
            {
                string quotationNumber = string.Empty;

                if (ConfigurationManager.AppSettings["ClientPortalQuotationNumber"] != null)
                    quotationNumber = ConfigurationManager.AppSettings["ClientPortalQuotationNumber"].ToString();

                return quotationNumber;
            }
        }

        public static int BillingBoxFTPHostPort
        {
            get
            {
                int port;
                if (!int.TryParse(ConfigurationManager.AppSettings["BillingBoxFTPHostPort"].ToString(), out port))
                {
                    port = 21;
                }
                return port;
            }
        }

        public static string SecurityKey
        {
            get
            {
                string key = "FA273A02-3DBB-4FBB-9FA8-EBDB7DB2102C";
                if (ConfigurationManager.AppSettings["CSSAPISecurityKey"] != null)
                {
                    key = ConfigurationManager.AppSettings["CSSAPISecurityKey"].ToString();
                }
                return key;
            }
        }


    }
}
