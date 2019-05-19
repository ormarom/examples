using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OracleErrorExample.Infra;

namespace OracleErrorExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly LabDbContext _labDbContext;

        public ValuesController(LabDbContext labDbContext)
        {
            _labDbContext = labDbContext;
        }

        // GET api/values
        [HttpGet("getgood")]
        public async Task<IActionResult> GetGood()
        {
            var result = await new Query(_labDbContext).GetThatWorks();
            return Ok(result);
        }

        // GET api/values
        [HttpGet("getbad")]
        public async Task<IActionResult> GetBad()
        {
            var result = await new Query(_labDbContext).GetThatIsBroken();
            return Ok(result);
        }


    }
}
