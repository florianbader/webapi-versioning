using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiVersioning
{
    [Table("WeatherForecast")]
    public class WeatherForecast1_0
    {
        [Key]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public decimal TemperatureC { get; set; }

        public decimal TemperatureF => 32 + TemperatureC / 0.5556m;
    }
}