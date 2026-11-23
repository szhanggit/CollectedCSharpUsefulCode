using ConfigWebApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigWebApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly IOptions<MySettingsModel> appSettings;

        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig, IOptions<MySettingsModel> app)
        {
            _logger = logger;
            configuration = iConfig;
            appSettings = app;
        }

        //http://localhost:59788/Home/Index
        public IActionResult Index()
        {
            string dbConn = configuration.GetSection("MySettings").GetSection("DbConnection").Value;
            string dbConn2 = appSettings.Value.DbConnection;


            var config = new RedisConfiguration();
            configuration.Bind("Redis", config);
            string Configuration = config.ConnectionString;
            string InstanceName = config.InstanceName;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
