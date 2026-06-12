using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistributedCacheEx.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ICacheOperation _cacheOperation;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICacheOperation cacheOperation)
        {
            _logger = logger;
            _cacheOperation = cacheOperation;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            string[] _list = _cacheOperation.GetCache<string[]>("summary");
            if(_list == null)
            {
                _cacheOperation.SetCache<string[]>("summary", Summaries);
                _list = _cacheOperation.GetCache<string[]>("summary");
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = _list[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
