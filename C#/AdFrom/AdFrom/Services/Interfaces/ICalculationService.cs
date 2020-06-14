using System.Collections.Generic;

namespace AdFrom.Services.Interfaces
{
    interface ICalculationService
    {
        bool IsAnomalyFound(int firstDay, int secondDay);
        int GetWeekBidsCount(List<int> bids);
    }
}
