using Database.Entities;
using Database.Interfaces;
using Microsoft.Azure.WebJobs;
using System;
using System.Threading.Tasks;
using WebJobCore.Extensions;

namespace WebJobCore
{
    public class DailyWeatherForecastRequests
    {
        private readonly IWeatherForecastRepository _repository;

        public DailyWeatherForecastRequests(IWeatherForecastRepository repository)
        {
            _repository = repository;
        }

        public Task HandleDailyWeatherForecastRequests([TimerTrigger("0 */1 * * * *", RunOnStartup = true)] TimerInfo timerInfo)
        {
            var pivotDate = DateTime.UtcNow.AddDays(-1);
            var startDate = pivotDate.StartOfDay();
            var endDate = pivotDate.EndOfDay();

            var listWeaterForecasts = _repository.GetWeatherForecastsByDate(startDate, endDate);

            var amountDailyRequest = new AmountDailyRequest()
            {
                Amount = listWeaterForecasts.Count,
                Date = endDate
            };

            _repository.AddAmountDailyRequest(amountDailyRequest);

            return Task.CompletedTask;
        }
    }
}