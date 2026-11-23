using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompressEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string localPath = ConfigureHelper.ZipFilePath;
            FileCompressService fileCompressService = new FileCompressService();
            string zipFile = localPath + "file.zip";
            List<string> filePathList = new List<string> {
                localPath + "f0.txt",
                localPath + "f1.txt"
            };
            fileCompressService.CompressMulti(filePathList, zipFile, ZipData.MB, 100);
        }
    }
}
