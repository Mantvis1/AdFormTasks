using AdFrom.Models;
using AdFrom.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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
                _requestBuilderService.AddFilters(_timeService.GetCurrentTime(), _timeService.AddDaysToTime(int.Parse(_configuration["WeekDaysCount"])));

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

        public async Task<List<string>> GetDatesWithHighChanges()
        {
            var anomaliesList = new List<string>();
            var client = new RestClient(_configuration["ApiLink"]);
            var token = await _authenticationService.GetToken();

            _requestBuilderService.SetDefaultMetricsAndDimensions();

            for (int i = 0; i < 12; i++)
            {
                _requestBuilderService.AddFilters(_timeService.GetCurrentTime(), _timeService.AddDaysToTime(30));

                var requestBody = _requestBuilderService.GetRequestBody();
                var responseContent = await _responseService.GetResponse(requestBody, client, token);

                for (var j = 0; j < responseContent.ReportData.Rows.Count - 1; j++)
                {
                    if (_calculationService
                        .IsAnomalyFound(int.Parse(responseContent.ReportData.Rows[j].Last().ToString()),
                        int.Parse(responseContent.ReportData.Rows[j + 1].Last().ToString())))
                    {
                        anomaliesList.Add(DateTime.Parse(responseContent.ReportData.Rows[j + 1].First().ToString()).ToString("yyyy-MM-dd"));
                    }
                }
            }

            return anomaliesList;
        }
    }
}
