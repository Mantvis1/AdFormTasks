using AdFrom.Models;
using AdFrom.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdFrom.Services
{
    public class DataFormationService : IDataFormationService
    {
        private readonly IResponseService _responseService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;
        private readonly IRequestBuilderService _requestBuilderService;
        private readonly ITimeService _timeService;
        private readonly ICalculationService _calculationService;

        public DataFormationService(
           IResponseService responseService,
           IAuthenticationService authenticationService,
           IConfiguration configuration,
           IRequestBuilderService requestBuilderService,
           ITimeService timeService,
           ICalculationService calculationService
           )
        {
            _responseService = responseService;
            _authenticationService = authenticationService;
            _configuration = configuration;
            _requestBuilderService = requestBuilderService;
            _timeService = timeService;
            _calculationService = calculationService;
        }

        public async Task<List<BidsPerWeek>> GetBidsPerWeekAsync()
        {
            var weeksCount = int.Parse(_configuration["WeeksInOneYears"]);
            var client = new RestClient(_configuration["ApiLink"]);
            var token = await _authenticationService.GetToken();
            var bidsPerWeek = new List<BidsPerWeek>();

            _requestBuilderService.SetDefaultMetricsAndDimensions();

            for (var weekNumber = 1; weekNumber <= weeksCount; weekNumber++)
            {
                _requestBuilderService.AddFilters(_timeService.GetTime(), _timeService.AddDaysToTime(int.Parse(_configuration["WeekDaysCount"])));

                var requestBody = _requestBuilderService.GetRequestBody();
                var responseContent = await _responseService.GetResponse(requestBody, client, token);

                bidsPerWeek.Add(new BidsPerWeek
                {
                    Week = weekNumber,
                    Bids = _calculationService.GetWeekBidsCount(responseContent.ReportData)
                });
            }

            return bidsPerWeek;
        }

        public async Task<string> GetDatesWithHighChanges()
        {
            return "";
        }
    }
}
