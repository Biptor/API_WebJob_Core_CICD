using ApiCore.Models.Response;
using Database.Entities;
using Database.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiWebJobServBusCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastRepository _repository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastResponse> Get()
        {
            var rng = new Random();
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecastResponse
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            _repository.AddWeatherForecasts(createForecastsEntities(forecasts));

            return forecasts;
        }

        private List<WeatherForecast> createForecastsEntities(WeatherForecastResponse[] forecasts)
        {
            var entities = new List<WeatherForecast>();

            foreach (var item in forecasts)
            {
                entities.Add(new WeatherForecast()
                {
                    Date = item.Date,
                    Summary = item.Summary,
                    TemperatureC = item.TemperatureC,
                    TemperatureF = item.TemperatureF
                });
            }

            return entities;
        }
    }
}