using AdFrom.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdFrom.Services.Interfaces
{
    public interface IDataFormationService
    {
        Task<string> GetBidsPerWeekAsync();
        Task<string> GetDatesWithHighChanges();
    }
}
