using ConfigWebApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigWebApp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly AppIdentitySettings _appIdentitySettings;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IOptions<AppIdentitySettings> appIdentitySettingsAccessor)
        {
            _logger = logger;
            _config = config;
            _appIdentitySettings = appIdentitySettingsAccessor.Value;
        }

        public IActionResult Index()
        {
            /*https://stackoverflow.com/questions/46940710/getting-value-from-appsettings-json-in-net-core*/
            //Simple Way
            int PasswordRequiredLength = _config.GetValue<int>("AppIdentitySettings:Password:RequiredLength");
            bool RequireUppercase = _config.GetValue<bool>("AppIdentitySettings:Password:RequireUppercase");

            var key = _config["AppIdentitySettings:Password:RequireUppercase"];

            //Options Pattern
            PasswordRequiredLength = _appIdentitySettings.Password.RequiredLength;
            RequireUppercase = _appIdentitySettings.Password.RequireUppercase;
          
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
