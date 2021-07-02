using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiVersioning
{
    [Table("WeatherForecastV2")]
    public class WeatherForecast
    {
        [Key]
        public DateTime Date { get; set; }

        public string Summary { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}