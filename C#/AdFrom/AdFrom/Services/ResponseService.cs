using AdFrom.Models;
using AdFrom.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace AdFrom.Services
{
    public class ResponseService : IResponseService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;

        public ResponseService(IConfiguration configuration, IAuthenticationService authenticationService)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        public async Task<APIData> GetResponse(RequestBodyPart requestBody)
        {
            var client = new RestClient(_configuration["ApiLink"]);
            var request = new RestRequest(Method.POST)
                .AddParameter("Authorization", string.Format("Bearer {0}", await _authenticationService.GetToken()), ParameterType.HttpHeader)
                .AddJsonBody(requestBody);

            var aPIData = JsonConvert.DeserializeObject<APIData>((await client.ExecuteAsync(request)).Content);

            return aPIData;
        }
    }
}
