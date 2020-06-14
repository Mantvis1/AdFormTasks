using AdFrom.Services;
using System.Collections.Generic;
using Xunit;

namespace Testing
{
    public class RequestBuilderServiceTests
    {
        private readonly RequestBuilderService _requestBuilderService;

        public RequestBuilderServiceTests()
        {
            _requestBuilderService = new RequestBuilderService();
        }

        [Theory]
        [InlineData("2020-01-01", "2020-01-20")]
        public void IsRequestBodyCreatedCorrectly(string from, string to)
        {
            var dimensions = new List<string> { "date" };
            var metrics = new List<string> { "bidRequsts" };

            _requestBuilderService.AddDimensions(dimensions);
            _requestBuilderService.AddMetrics(metrics);
            _requestBuilderService.AddFilters(from, to);

            var requsetBody = _requestBuilderService.GetRequestBody();

            Assert.Equal(requsetBody.Dimensions, dimensions);
            Assert.Equal(requsetBody.Metrics, metrics); 
            Assert.Equal(requsetBody.Filter.Date.From, from);
            Assert.Equal(requsetBody.Filter.Date.To, to);
        }
    }
}
