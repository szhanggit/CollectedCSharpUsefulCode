using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompressEx
{
    public class FileCompressService
    {
        public void CompressMulti(List<string> fileNames, string zipPath, ZipData dataUnit, int segmentSize)
        {
            using (ZipFile zip = new ZipFile(Encoding.GetEncoding("utf-8")))
            {
                zip.MaxOutputSegmentSize = (int)dataUnit * segmentSize;
                foreach (var fileName in fileNames)
                {
                    zip.AddItem(fileName, string.Empty);
                }
                zip.Save(zipPath);
            }
        }
    }
}
