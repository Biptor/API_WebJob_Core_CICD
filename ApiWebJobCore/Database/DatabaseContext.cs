using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public virtual DbSet<AmountDailyRequest> AmountDailyRequests { get; set; }
    }
}