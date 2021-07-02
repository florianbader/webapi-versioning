using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebApiVersioning.Repositories;

namespace WebApiVersioning.Controllers
{
    [ApiController]
    [Route("api/weatherforecast")]
    [ApiVersion("3.0-preview1")]
    public class WeatherForecast3Controller : ApiBaseController
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastRepository _weatherForecastRepository;

        public WeatherForecast3Controller(WeatherForecastRepository weatherForecastRepository, ILogger<WeatherForecastController> logger)
        {
            _weatherForecastRepository = weatherForecastRepository;
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastRepository.GetAll();
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<WeatherForecast> Post(WeatherForecast weatherForecast)
        {
            return Ok(_weatherForecastRepository.Save(weatherForecast));
        }
    }
}