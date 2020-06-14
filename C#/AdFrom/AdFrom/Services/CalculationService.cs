using AdFrom.Models;
using AdFrom.Services.Interfaces;
using Microsoft.Extensions.Configuration;
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

        public int GetWeekBidsCount(ReportData reportData)
        {
            var weekBidsSum = 0;

            foreach(var row in reportData.Rows)
            {
                weekBidsSum += int.Parse(row.Last().ToString());
            }

            return weekBidsSum;
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
