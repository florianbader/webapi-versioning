using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApiVersioning.Repositories;

namespace WebApiVersioning.Controllers
{
    [ApiController]
    [Route("api/weatherforecast")]
    [ApiVersion("1.0")]
    public class WeatherForecastController : ApiBaseController
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastController(WeatherForecastRepository weatherForecastRepository, ILogger<WeatherForecastController> logger)
        {
            _weatherForecastRepository = weatherForecastRepository;
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<WeatherForecast1_0> Get()
        {
            return _weatherForecastRepository.GetAll().Select(WeatherForecastTo1_0);
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<WeatherForecast> Post(WeatherForecast1_0 weatherForecast1_0)
        {
            var weatherForecast = new WeatherForecast
            {
                Date = weatherForecast1_0.Date,
                Summary = weatherForecast1_0.Description,
                TemperatureC = (int)weatherForecast1_0.TemperatureC
            };

            weatherForecast = _weatherForecastRepository.Save(weatherForecast);

            return Ok(WeatherForecastTo1_0(weatherForecast));
        }

        private WeatherForecast1_0 WeatherForecastTo1_0(WeatherForecast weatherForecast)
        {
            return new WeatherForecast1_0
            {
                Date = weatherForecast.Date,
                Description = weatherForecast.Summary,
                TemperatureC = weatherForecast.TemperatureC
            };
        }
    }
}