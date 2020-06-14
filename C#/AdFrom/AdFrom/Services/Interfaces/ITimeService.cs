using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdFrom.Services.Interfaces
{
    public interface ITimeService 
    {
        public string GetCurrentTime();
        public string GetTimeYearsBeforeNow();
    }
}
