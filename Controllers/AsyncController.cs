using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetPeople.Controllers
{
    [Route("")]
    [ApiController]
    public class AsyncController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(5000);
            stopwatch.Stop();
            return Ok(stopwatch.Elapsed.TotalSeconds);
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok();
        }
    }
}
