using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var aH = new AppSettingsHandler("appsettings.json");
            var aS = aH.GetAppSettings();
            var myPath = aS.DataBase.PathToDatabases;
        }
    }
}
