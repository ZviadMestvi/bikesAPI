 using Microsoft.AspNetCore.Mvc;
using CompareBikes.Models;
using CompareBikes.Services;

namespace CompareBikes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private IConfiguration Configuration;

        public ModelsController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Model>> GetModels(string brand, string? category, int? year, int? minYear, int maxYear) 
        {
            var modelsList = ModelsService.filterModels(brand, category, year, minYear, maxYear, Configuration);

            if (modelsList == null) return NotFound();

            return Ok(modelsList);
        }

        [Route("search/{value}")]
        [HttpGet]
        public ActionResult<IEnumerable<Model>> GetModelsBySearch(string value)
        {
            var modelsList = ModelsService.getModelsBySearchQuery(value, Configuration);

            if (modelsList == null) return NotFound();

            return Ok(modelsList);
        }
    }
}
