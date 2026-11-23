using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = AppDomain.CurrentDomain.BaseDirectory;

            /*
                         string filePath = @"~/Download/EMV_Order_Template.csv";
            string Path = System.Web.HttpContext.Current.Server.MapPath(filePath); //Server.MapPath(filePath);
            /*D:\Study\MVCStudyNotes\Experiments\WebSessionEx\WebSessionEx\Download\EMV_Order_Template.csv*/

            /************************/
            //string path = HttpRuntime.BinDirectory;
            /*D:\Study\MVCStudyNotes\Experiments\WebSessionEx\WebSessionEx\bin\*/

            /************************/
            //string appPath = Request.PhysicalApplicationPath;
        }
    }
}
