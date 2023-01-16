using Microsoft.AspNetCore.Mvc;
using CompareBikes.Models;
using CompareBikes.Services;

namespace CompareBikes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IConfiguration Configuration;

        public BrandsController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Brand>> GetBrands()
        {
            var brandsList = BrandsService.GetBrandsList(Configuration);

            if (brandsList == null) return NotFound();

            return Ok(brandsList);
        }

        [Route("{value}")]
        [HttpGet]
        public ActionResult<IEnumerable<Brand>> GetSearchedBrands(string value)
        {
            var brandsList = BrandsService.GetSearchedBrandsList(value, Configuration);

            if (brandsList == null) return NotFound();

            return Ok(brandsList);
        }
    }
}
