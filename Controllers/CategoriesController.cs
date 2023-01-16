using Microsoft.AspNetCore.Mvc;
using CompareBikes.Services;
using CompareBikes.Models;

namespace CompareBikes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IConfiguration Configuration;

        public CategoriesController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categoriesList = CategoriesService.GetCategoriesList(Configuration);

            if (categoriesList == null) return NotFound();

            return Ok(categoriesList);
        }
    }
}
