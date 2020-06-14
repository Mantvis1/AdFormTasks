using AdFrom.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Testing
{
    public class CalculationServiceTests
    {
        private readonly CalculationService _calculationService;

        public CalculationServiceTests()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            _calculationService = new CalculationService(configuration);
        }

        [Fact]
        public void BidsPerWeekCounter()
        {
          /*  var bidsPerDay = IEnumerable<object>();
            bidsPerDay.Add(new object(){ "2010-05-11", "200" });

            //   Assert.Equal(10, _calculationService.GetWeekBidsCount(bidsPerDay));
            Assert.Equal(10, 9);*/
        }

        [Theory]
        [InlineData(30, 30, false)]
        [InlineData(10, 0, true)]
        [InlineData(0, 10, true)]
        [InlineData(150, 50, true)]
        [InlineData(150, 100, false)]
        [InlineData(50, 150, true)]
        [InlineData(100, 150, false)]
        public void AnomaliesCalculator(int firstDayBidsCount, int secondDayBidsCount, bool expectedResult)
        {
            Assert.Equal(_calculationService.IsAnomalyFound(firstDayBidsCount, secondDayBidsCount), expectedResult);
        }
    }
}
