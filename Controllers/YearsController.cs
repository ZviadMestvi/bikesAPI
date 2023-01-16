using Microsoft.AspNetCore.Mvc;
using CompareBikes.Models;
using CompareBikes.Services;

namespace CompareBikes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearsController : ControllerBase
    {
        private IConfiguration Configuration;

        public YearsController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Year>> GetYears()
        {
            var yearsList = YearsService.GetYearsList(Configuration);

            if (yearsList == null) return NotFound();

            return Ok(yearsList);
        }
    }
}
