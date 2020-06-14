using AdFrom.Models;
using System.Collections.Generic;

namespace AdFrom.Services.Interfaces
{
    public interface ICalculationService
    {
        bool IsAnomalyFound(int firstDay, int secondDay);
        int GetWeekBidsCount(ReportData reportData);
    }
}
