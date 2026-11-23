using Microsoft.Extensions.Configuration;
using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Hello, World!");


            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();

            var connectionString = config["ConnectionString"];
            string two = config.GetSection("MySecondClass").GetSection("SettingOne").Value;
            string two2 = config.GetSection("MySecondClass")["SettingOne"];
            var emailHost = config["Smtp:Host"];
            Console.WriteLine($"Connection String is: {connectionString}");
            Console.WriteLine($"Email Host is: {emailHost}");
            var settingTwo = config["MySecondClass:SettingOne"];
            var Item1 = config["Smtp:Deeper:Item1"];
            Console.WriteLine(settingTwo);


        }
    }
}
