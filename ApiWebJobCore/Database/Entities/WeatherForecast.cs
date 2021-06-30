using System;

namespace Database.Entities
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public string Summary { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
    }
}