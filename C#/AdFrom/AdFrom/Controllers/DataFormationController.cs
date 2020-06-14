using System.Threading.Tasks;
using AdFrom.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdFrom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataFormationController : ControllerBase
    {
        private readonly IDataFormationService _dataFormationService;

        public DataFormationController(IDataFormationService dataFormationService)
        {
            _dataFormationService = dataFormationService;
        }

        [HttpGet]
        [Route("bids")]
        public async Task<IActionResult> GetBidsPerWeek()
        {
            var response = await _dataFormationService.GetBidsPerWeekAsync();

            if (response.Count == 0)
            {
                return NotFound("Something wrong");
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("changes")]
        public async Task<IActionResult> GetBidChnages()
        {
            var response = await _dataFormationService.GetDatesWithHighChanges();

            if (response.Count == 0)
            {
                return NotFound("Anomalies not found");
            }

            return Ok(response);
        }
    }
}
