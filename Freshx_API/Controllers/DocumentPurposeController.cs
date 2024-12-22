using Freshx_API.Dtos;
using Freshx_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freshx_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentPurposeController : ControllerBase
    {
        private readonly IDocumentPurposeService _service;

        public DocumentPurposeController(IDocumentPurposeService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentPurposeDto>> GetDocumentPurposeById(int id)
        {
            var result = await _service.GetDocumentPurposeByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentPurposeDto>>> GetAllDocumentPurposes()
        {
            var result = await _service.GetAllDocumentPurposesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<DocumentPurposeDto>> CreateDocumentPurpose([FromBody] DocumentPurposeDto documentPurposeDto)
        {
            var result = await _service.CreateDocumentPurposeAsync(documentPurposeDto);
            return CreatedAtAction(nameof(GetDocumentPurposeById), new { id = result }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DocumentPurposeDto>> UpdateDocumentPurpose(int id, [FromBody] DocumentPurposeDto documentPurposeDto)
        {
            var result = await _service.UpdateDocumentPurposeAsync(id, documentPurposeDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentPurpose(int id)
        {
            await _service.DeleteDocumentPurposeAsync(id);
            return NoContent();
        }
    }
}
