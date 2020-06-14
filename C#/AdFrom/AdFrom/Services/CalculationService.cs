using AdFrom.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdFrom.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IConfiguration _configuration;

        public CalculationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int GetWeekBidsCount(List<int> bids)
        {
            return bids.Sum();
        }

        public bool IsAnomalyFound(int firstDay, int secondDay)
        {
            if (firstDay == secondDay)
            {
                return false;
            }

            if (firstDay <= 0 || secondDay <= 0)
            {
                return true;
            }

            int diferenceIndex;

            if (firstDay > secondDay)
            {
                diferenceIndex = firstDay / secondDay;
            }
            else
            {
                diferenceIndex = secondDay / firstDay;
            }

            return diferenceIndex >= int.Parse(_configuration["IncresmentDecresmentCoeficient"]);
        }
    }
}
