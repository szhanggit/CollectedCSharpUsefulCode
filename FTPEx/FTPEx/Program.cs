using Starksoft.Aspen.Ftps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string FTPHost = "61.57.231.103";
            int FTPHostPort = 990;
            FtpsSecurityProtocol sProtocal = FtpsSecurityProtocol.Tls1OrSsl3Implicit;
            string user = "egtc_ertw";
            string password = "LDAknger75";
            string fileWithPath = @"D:\MenuFormatConfig.xml";

            using (FtpsClient ftpsClient = new FtpsClient(FTPHost, FTPHostPort, sProtocal))
            {
                ftpsClient.NetworkProtocol = NetworkVersion.IPv6;
                ftpsClient.AlwaysAcceptServerCertificate = true;
                ftpsClient.Open(user, password);

                FileStream fileStream = new FileStream(fileWithPath, FileMode.Open);
                ftpsClient.PutFile(fileStream, @"\MenuFormatConfig.xml", FileAction.Create);

                fileStream.Close();
                ftpsClient.Close();
            }
        }
    }
}
