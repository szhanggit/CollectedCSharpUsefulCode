using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TXC.Common.CacheManagement.Resolver;
using TXC.Common.Domain;

namespace Consumer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ITenantConfigHelper _tenantConfigHelper;
        private readonly ITenantDbConnection _tenantDbConnection;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger
            , ITenantDbConnection tenantDbConnection
            , ITenantConfigHelper tenantConfigHelper)
        {
            _logger = logger;
            _tenantConfigHelper = tenantConfigHelper;
            _tenantDbConnection = tenantDbConnection;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            TenantConfig queueNameConfig = await _tenantConfigHelper.GetTenantConfigValue("TX2ConnectorQueueName", 1);

            Response<IDbConnection> conn = await _tenantDbConnection.GetTenantDbConnection("1", false, default);



            /******************************************************************/
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
