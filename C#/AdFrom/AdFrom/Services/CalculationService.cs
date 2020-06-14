using AdFrom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdFrom.Services
{
    public class CalculationService : ICalculationService
    {
        public int GetWeekBidsCount(List<int> bids)
        {
            return bids.Sum();
        }

        public bool IsAnomalyFound(int firstDay, int secondDay)
        {
            var diferenceIndex = 0;

            if (firstDay == secondDay)
            {
                return false;
            }

            if (firstDay <= 0 || secondDay <= 0)
            {
                return true;
            }

            if (firstDay > secondDay)
            {
                diferenceIndex = firstDay / secondDay;
            }
            else
            {
                diferenceIndex = secondDay / firstDay;
            }

            return diferenceIndex >= 3;
        }
    }
}
