using AdFrom.Services.Interfaces;
using System;

namespace AdFrom.Services
{
    public class TimeService : ITimeService
    {
        public string GetCurrentTime()
        {
            return DateTime.Today.ToString("yyyy-MM-dd");
        }

        public string GetTimeYearsBeforeNow()
        {
            return DateTime.Today.AddYears(-1).AddDays(1).ToString("yyyy-MM-dd");
        }
    }
}
