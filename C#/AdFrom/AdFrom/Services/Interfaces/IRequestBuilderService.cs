using AdFrom.Models;
using System.Collections.Generic;

namespace AdFrom.Services.Interfaces
{
    public interface IRequestBuilderService
    {
        RequestBodyPart GetRequestBody();
        void AddDimensions(List<string> dimensions);
        void AddMetrics(List<string> metrics);
        void AddFilters(string from, string to);
    }
}
