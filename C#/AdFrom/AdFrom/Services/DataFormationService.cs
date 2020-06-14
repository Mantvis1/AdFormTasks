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
        public DataFormationService(
           IResponseService responseService,
           IAuthenticationService authenticationService,
           IConfiguration configuration,
           IRequestBuilderService requestBuilderService
           )
        {
            _responseService = responseService;
            _authenticationService = authenticationService;
            _configuration = configuration;
            _requestBuilderService = requestBuilderService;
        }

        public async Task<string> GetBidsPerWeekAsync()
        {
            _requestBuilderService.AddDimensions(new List<string> { "date" });
            _requestBuilderService.AddMetrics(new List<string> { "bidRequests" });
            _requestBuilderService.AddFilters("2020-01-01", "2020-01-20");
            var requestBody = _requestBuilderService.GetRequestBody();

            var client = new RestClient(_configuration["ApiLink"]);

            var response = await _responseService.GetResponse(requestBody, client, await _authenticationService.GetToken());

            return response;
        }

        public async Task<string> GetDatesWithHighChanges()
        {
            return "kjhgfds";
        }
    }
}
