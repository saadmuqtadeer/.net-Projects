using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuth.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get() {
            return Ok("");
        }
    }
}
