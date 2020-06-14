using AdFrom.Services;
using System.Collections.Generic;
using Xunit;

namespace Testing
{
    public class CalculationServiceTests
    {
        private readonly CalculationService _calculationService;

        public CalculationServiceTests()
        {
            _calculationService = new CalculationService();
        }

        [Fact]
        public void BidsPerWeekCounter()
        {
            var bidsPerDay = new List<int>() { 1, 2, 3, 4 };

            Assert.Equal(10, _calculationService.GetWeekBidsCount(bidsPerDay));
        }

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(10, 0, true)]
        [InlineData(0, 10, true)]
        [InlineData(150, 50, true)]
        [InlineData(150, 100, false)]
        [InlineData(50, 150, true)]
        public void AnomaliesCalculator(int firstDayBidsCount, int secondDayBidsCount, bool expectedResult)
        {
            Assert.Equal(_calculationService.IsAnomalyFound(firstDayBidsCount, secondDayBidsCount), expectedResult);
        }
    }
}
