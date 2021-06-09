using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NiceRedirectServer.Models;

namespace NiceRedirectServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateRedirectController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CreateRedirectController> _logger;

        public CreateRedirectController(ILogger<CreateRedirectController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Redirect Get()
        {
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