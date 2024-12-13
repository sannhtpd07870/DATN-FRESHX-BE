using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Freshx_API.Services;
using Freshx_API.Dtos;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugCatalogController : ControllerBase
    {
        private readonly IDrugCatalogService _drugCatalogService;

        public DrugCatalogController(IDrugCatalogService drugCatalogService)
        {
            _drugCatalogService = drugCatalogService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDrugCatalogById(int id)
        {
            var response = await _drugCatalogService.GetDrugCatalogById(id);
            return StatusCode(response.StatusCode ?? StatusCodes.Status200OK, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrugCatalogs()
        {
            var response = await _drugCatalogService.GetAllDrugCatalogs();
            return StatusCode(response.StatusCode ?? StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDrugCatalog([FromBody] CreateDrugCatalogDto drugCatalogDto)
        {
            var response = await _drugCatalogService.CreateDrugCatalog(drugCatalogDto);
            return StatusCode(response.StatusCode ?? StatusCodes.Status201Created, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrugCatalog(int id, [FromBody] DrugCatalogDto drugCatalogDto)
        {
            var response = await _drugCatalogService.UpdateDrugCatalog(id, drugCatalogDto);
            return StatusCode(response.StatusCode ?? StatusCodes.Status200OK, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrugCatalog(int id)
        {
            var response = await _drugCatalogService.DeleteDrugCatalog(id);
            return StatusCode(response.StatusCode ?? StatusCodes.Status200OK, response);
        }
    }
}