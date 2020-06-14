using AdFrom.Services.Interfaces;
using System;

namespace AdFrom.Services
{
    public class TimeService : ITimeService
    {
        private readonly DateTime dateTime = DateTime.Today.AddYears(-1).AddDays(1);

        public string GetCurrentTime()
        {
            return DateTime.Today.ToString("yyyy-MM-dd");
        }

        public string GetTimeYearsBeforeNow()
        {
            return DateTime.Today.AddYears(-1).AddDays(1).ToString("yyyy-MM-dd");
        }

        public string AddDaysToTime(int days)
        {
            dateTime.AddDays(days);

            return dateTime.ToString("yyyy-MM-dd");
        }

        public string GetTime()
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
    }
}
