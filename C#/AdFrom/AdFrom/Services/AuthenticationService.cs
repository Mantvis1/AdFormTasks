using AdFrom.Services.Interfaces;
using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdFrom.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GetToken()
        {
            var response = await new HttpClient().RequestTokenAsync(new TokenRequest
            {
                Address = _configuration["TokenSourceEndpoint"],
                GrantType = _configuration["ApiLogInInformation:grant_type"],
                ClientId = _configuration["ApiLogInInformation:client_id"],
                ClientSecret = _configuration["ApiLogInInformation:client_secret"],

                Parameters =
                {
                    { "scope", _configuration["ApiLogInInformation:scope"] }
                }
            });

            return response.AccessToken;
        }
    }
}
