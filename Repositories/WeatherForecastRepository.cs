using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiVersioning.Repositories
{
    public class WeatherForecastRepository
    {
        private static readonly string[] Summaries = new[]
        {
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> GetAll()
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

        public WeatherForecast Save(WeatherForecast weatherForecast)
        {
            return weatherForecast;
        }
    }
}