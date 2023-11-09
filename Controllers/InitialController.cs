using CompareBikes.Models;
using CompareBikes.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompareBikes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InitialController : ControllerBase
    {
        private IConfiguration Configuration;

        public InitialController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        /* Get brands, years and types list on initial load */
        [HttpGet]
        public ActionResult<IEnumerable<Model>> Get()
        {
            var results = InitialService.getResults(Configuration);

            if (results == null) return NotFound();

            return Ok(results);
        }
    }
}
