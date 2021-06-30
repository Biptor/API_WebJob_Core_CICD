using Database.Entities;
using Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly DatabaseContext _dbContext;

        public WeatherForecastRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddAmountDailyRequest(AmountDailyRequest item)
        {
            _dbContext.AmountDailyRequests.Add(item);

            _dbContext.SaveChanges();
        }

        public void AddWeatherForecasts(List<WeatherForecast> item)
        {
            _dbContext.WeatherForecasts.AddRange(item);

            _dbContext.SaveChanges();
        }

        public List<WeatherForecast> GetWeatherForecastsByDate(DateTime fromDateTime, DateTime toDateTime)
        {
            return _dbContext.WeatherForecasts.Where(item => item.Date < toDateTime && item.Date > fromDateTime).ToList();
        }
    }
}