using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Webapi.Controllers
{
    [ApiController]
    [Authorize]
    // [Route("[controller]")]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> log;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.log = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            log.LogInformation($"random number is {rng.Next()}");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }

        [HttpGet]
        [Route("/api/health")]
        public ActionResult HealthCheck()
        {
            // Random rand = new Random();
            // if (rand.Next(10) > 5)
            // {
            return Ok();
            // }
            // else
            // {
            // return BadRequest();
            // }
            // throw new Exception("hello ex");
        }
    }
}