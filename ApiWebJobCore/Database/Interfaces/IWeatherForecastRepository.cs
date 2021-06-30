using Database.Entities;
using System;
using System.Collections.Generic;

namespace Database.Interfaces
{
    public interface IWeatherForecastRepository
    {
        void AddWeatherForecasts(List<WeatherForecast> item);

        List<WeatherForecast> GetWeatherForecastsByDate(DateTime fromDateTime, DateTime toDateTime);

        void AddAmountDailyRequest(AmountDailyRequest item);
    }
}