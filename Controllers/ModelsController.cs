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
        public ActionResult<IEnumerable<Model>> GetModels(string brand, int? year, string? type) 
        {
            var modelsList = ModelsService.GetModelsList(brand, year, type, Configuration);

            if (modelsList == null) return NotFound();

            return Ok(modelsList);
        }

        [Route("years/{min}-{max}")]
        [HttpGet]
        public ActionResult<IEnumerable<Model>> GetModelsByYear(string brand, string? type,  int min, int max)
        {
            var modelsList = ModelsService.GetModelsListByYear(brand, type, min, max, Configuration);

            if (modelsList == null) return NotFound();

            return Ok(modelsList);
        }


        [Route("power/{min}-{max}")]
        [HttpGet]
        public ActionResult<IEnumerable<Model>> GetModelsByPower(string brand, string? type, int min, int max)
        {
            var modelsList = ModelsService.GetModelsListByPower(brand, type, min, max, Configuration);

            if (modelsList == null) return NotFound();

            return Ok(modelsList);
        }

        [Route("search/{value}")]
        [HttpGet]
        public ActionResult<IEnumerable<Model>> GetSearchResults(string value)
        {
            var modelsList = ModelsService.GetSearchResultsList(value, Configuration);

            if (modelsList == null) return NotFound();

            return Ok(modelsList);
        }

        [Route("{brand}/{value}")]
        [HttpGet]
        public ActionResult<IEnumerable<Model>> GetSearchedModels(string brand, string value)
        {
            var modelsList = ModelsService.GetSearchedModelsList(brand, value, Configuration);

            if (modelsList == null) return NotFound();

            return Ok(modelsList);
        }

        [Route("specs/{brand}/{model}")]
        [HttpGet]
        public ActionResult<IEnumerable<BikeSpecs>> GetBikeSpecs(string model, int year)
        {
            var specs = ModelsService.GetBikeSpecsList(model, year, Configuration);

            if (specs == null) return NotFound();

            return Ok(specs);
        }
    }
}
