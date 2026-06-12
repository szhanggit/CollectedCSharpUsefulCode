using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.IO;

namespace MemoryCacheTry
{
    class Program
    {
        //https://docs.microsoft.com/en-us/dotnet/api/system.runtime.caching.memorycache?view=dotnet-plat-ext-3.1
        static void Main(string[] args)
        {
            FirstExample();

            //https://www.c-sharpcorner.com/UploadFile/87b416/working-with-caching-in-C-Sharp/
            StockItems PS = new StockItems();
            List<string> Pizzas = (List<string>)PS.GetAvailableStocks();
            Pizzas = (List<string>)PS.GetAvailableStocks();

            ThirdExample();
            ThirdExample();
        }

        public static void FirstExample()
        {
            ObjectCache cache = MemoryCache.Default;
            string fileContents = cache["filecontents"] as string;

            if (fileContents == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();

                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10.0);

                List<string> filePaths = new List<string>();
                filePaths.Add(@"C:\E\C#\Cache\ObjectCache\MemoryCache\MemoryCacheTry\MemoryCacheTry\bin\Debug\file.txt");

                policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));

                // Fetch the file contents.  
                fileContents = File.ReadAllText("file.txt");

                cache.Set("filecontents", fileContents, policy);
            }
        }

        public static void ThirdExample()
        {
            StockItems PS = new StockItems();
            List<string> Pizzas = (List<string>)PS.AddOrGetAvailableStocks("MyKey");
        }
    }
}
