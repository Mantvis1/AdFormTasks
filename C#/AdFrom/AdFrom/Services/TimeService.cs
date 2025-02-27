﻿using AdFrom.Services.Interfaces;
using System;

namespace AdFrom.Services
{
    public class TimeService : ITimeService
    {
        private DateTime dateTime = DateTime.Today.AddYears(-1).AddDays(1);

        public string AddDaysToTime(int days)
        {
            dateTime = dateTime.AddDays(days);

            return dateTime.AddDays(-1).ToString("yyyy-MM-dd");
        }

        public string GetCurrentTime()
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
    }
}
