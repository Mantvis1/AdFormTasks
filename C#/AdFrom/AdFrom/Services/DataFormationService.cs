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

        public DataFormationService(
           IResponseService responseService,
           IAuthenticationService authenticationService,
           IConfiguration configuration,
           IRequestBuilderService requestBuilderService,
           ITimeService timeService
           )
        {
            _responseService = responseService;
            _authenticationService = authenticationService;
            _configuration = configuration;
            _requestBuilderService = requestBuilderService;
            _timeService = timeService;
        }

        public async Task<string> GetBidsPerWeekAsync()
        {
            _requestBuilderService.AddDimensions(new List<string> { "date" });
            _requestBuilderService.AddMetrics(new List<string> { "bidRequests" });
            _requestBuilderService.AddFilters(_timeService.GetTimeYearsBeforeNow(), _timeService.GetCurrentTime());
            var requestBody = _requestBuilderService.GetRequestBody();

            var client = new RestClient(_configuration["ApiLink"]);

            var response = await _responseService.GetResponse(requestBody, client, await _authenticationService.GetToken());

            return response;
        }

        public async Task<string> GetDatesWithHighChanges()
        {
            return "";
        }
    }
}
