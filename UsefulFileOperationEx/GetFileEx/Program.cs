using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetFileEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchPattern = "ParkingLogApp.*.dll";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File");
            foreach (var assembly in Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories).Select(Assembly.LoadFrom))
            {
                string name = assembly.FullName;
            }

            searchPattern = "*.xlsx";
            foreach (var Spreadsheet in Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories))
            {
                string name = Spreadsheet.ToString();
            }

            foreach (var Spreadsheet in Directory.GetFiles(path))
            {
                string name = Spreadsheet.ToString();
            }
        }
    }
}
