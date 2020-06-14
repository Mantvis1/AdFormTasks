using System.Collections.Generic;

namespace AdFrom.Services.Interfaces
{
    public interface ICalculationService
    {
        bool IsAnomalyFound(int firstDay, int secondDay);
        int GetWeekBidsCount(List<int> bids);
    }
}
