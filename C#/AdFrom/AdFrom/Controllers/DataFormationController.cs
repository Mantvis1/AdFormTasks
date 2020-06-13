using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdFrom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataFormationController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetBidsPerWeek()
        {
            return BadRequest("Not implemented");
        }

        [HttpGet]
        public async Task<IActionResult> GetBidsWhen()
        {
            return BadRequest("Not implemented");
        }
    }
}
