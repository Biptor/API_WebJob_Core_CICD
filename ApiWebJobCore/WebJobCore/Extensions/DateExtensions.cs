using System;

namespace WebJobCore.Extensions
{
    public static class DateExtensions
    {
        public static DateTime EndOfDay(this DateTime @this)
        {
            return new DateTime(@this.Year, @this.Month, @this.Day).AddDays(1).Subtract(new TimeSpan(0, 0, 0, 0, 1));
        }

        public static DateTime StartOfDay(this DateTime @this)
        {
            return new DateTime(@this.Year, @this.Month, @this.Day, 0, 0, 0, 0);
        }
    }
}