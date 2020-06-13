using System.Threading.Tasks;
using AdFrom.Models;
using AdFrom.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace AdFrom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataFormationController : ControllerBase
    {
        private readonly IResponseService _responseService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;
        public DataFormationController(
            IResponseService responseService,
            IAuthenticationService authenticationService,
            IConfiguration configuration
            )
        {
            _responseService = responseService;
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("bids")]
        public async Task<IActionResult> GetBidsPerWeek()
        {
            var requestBody = new RequestBodyPart()
            {
                Dimensions = { "date" },
                Metrics = { "bidRequests" },
                Filter = new Filter()
                {
                    Date = new Date()
                    {
                        From = "2020-01-01",
                        To = "2020-01-20"
                    }
                }
            };

            var client = new RestClient(_configuration["ApiLink"]);

            var response = await _responseService.GetResponse(requestBody, client, await _authenticationService.GetToken());

            return Ok(response);
        }

        [HttpGet]
        [Route("Changes")]
        public async Task<IActionResult> GetBidChnages()
        {
            return BadRequest("Notimplemented");
        }
    }
}
