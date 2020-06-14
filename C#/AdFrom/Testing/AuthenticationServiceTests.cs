using AdFrom.Services;
using Microsoft.Extensions.Configuration;
using System.IO;
using Xunit;

namespace Testing
{
    public class AuthenticationServiceTests
    {
        private readonly AuthenticationService _authenticationService;

        public AuthenticationServiceTests()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _authenticationService = new AuthenticationService(configuration);
        }

        [Fact]
        public async void CheckIfAutentificationWorksAsync()
        {
            Assert.NotNull(await _authenticationService.GetToken());
        }
    }
}
