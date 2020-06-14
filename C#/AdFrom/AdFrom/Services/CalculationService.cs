using AdFrom.Models;
using AdFrom.Services.Interfaces;
using Microsoft.Extensions.Configuration;
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

        public bool IsAnomalyFound(int firstDayBids, int secondDayBids)
        {
            if (firstDayBids == secondDayBids)
            {
                return false;
            }

            if (firstDayBids <= 0 || secondDayBids <= 0)
            {
                return true;
            }

            int diferenceIndex;

            if (firstDayBids > secondDayBids)
            {
                diferenceIndex = firstDayBids / secondDayBids;
            }
            else
            {
                diferenceIndex = secondDayBids / firstDayBids;
            }

            return diferenceIndex >= int.Parse(_configuration["IncresmentDecresmentCoeficient"]);
        }
    }
}
