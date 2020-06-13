using System.Threading.Tasks;
using AdFrom.Models;
using AdFrom.Services;
using AdFrom.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace AdFrom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataFormationController : ControllerBase
    {
        private readonly IResponseService _responseService;
        private readonly IAuthenticationService _authenticationService;

        public DataFormationController(IResponseService responseService, IAuthenticationService authenticationService)
        {
            _responseService = responseService;
            _authenticationService = authenticationService;
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

            var client = new RestClient("https://api.adform.com/v1/reportingstats/publisher/reportdata");

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
