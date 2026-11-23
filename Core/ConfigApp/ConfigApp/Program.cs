using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConfigApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string environmentName = "Dev";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{environmentName}.json", optional: false);

            IConfiguration config = builder.Build();

            var myFirstClass = config.GetSection("MyFirstClass").Get<MyFirstClass>();
            var mySecondClass = config.GetSection("MySecondClass").Get<MySecondClass>();
            Console.WriteLine($"The answer is always {myFirstClass.Option2}");
            Console.ReadLine();
        }
    }
}
