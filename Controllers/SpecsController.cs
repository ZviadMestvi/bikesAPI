using Microsoft.AspNetCore.Mvc;
using CompareBikes.Services;
using CompareBikes.Models;

namespace CompareBikes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecsController : ControllerBase
    {
        private IConfiguration Configuration;

        public SpecsController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        [Route("{brand}-{model}-{year}")]
        [HttpGet]
        public ActionResult<IEnumerable<Model>> GetBike(string brand, string model, int year)
        {
            var modelsList = SpecsService.getBikeSpecs(brand, model, year, Configuration);

            if (modelsList == null) return NotFound();

            return Ok(modelsList);
        }
    }
}
