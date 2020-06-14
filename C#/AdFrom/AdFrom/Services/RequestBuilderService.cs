using AdFrom.Models;
using AdFrom.Services.Interfaces;
using System.Collections.Generic;

namespace AdFrom.Services
{
    public class RequestBuilderService : IRequestBuilderService
    {
        private readonly RequestBodyPart _requestBody = new RequestBodyPart();

        public void AddDimensions(List<string> dimensions)
        {
            _requestBody.Dimensions = dimensions;
        }

        public void AddFilters(string from, string to)
        {
            _requestBody.Filter = new Filter()
            {
                Date = new Date()
                {
                    From = from,
                    To = to
                }
            };
        }

        public void AddMetrics(List<string> metrics)
        {
            _requestBody.Metrics = metrics;
        }

        public RequestBodyPart GetRequestBody()
        {
            return _requestBody;
        }

        public void SetDefaultMetricsAndDimensions()
        {
            _requestBody.Dimensions = new List<string> { "date" };
            _requestBody.Metrics = new List<string> { "bidRequests" };
        }

    }
}
