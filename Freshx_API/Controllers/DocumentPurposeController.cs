
using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.Pharmacy;
using Freshx_API.Services;
using global::Freshx_API.Dtos.CommonDtos;
using global::Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Freshx_API.Controllers
{

    namespace Freshx_API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class DocumentPurposeController : ControllerBase
        {
            private readonly IDocumentPurposeService _service;
            private IMapper _mapper;
            public DocumentPurposeController(IDocumentPurposeService service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<ActionResult<ApiResponse<List<DocumentPurposeDto>>>> GetAllDocumentPurposes([FromQuery] string? searchKey)
            {
                try
                {
                    var result = await _service.GetAllDocumentPurposesAsync(searchKey);
                    return Ok(ResponseFactory.Success(Request.Path, result));
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ResponseFactory.Error<List<DocumentPurposeDto>>(Request.Path, ex.Message, StatusCodes.Status500InternalServerError));
                }
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<ApiResponse<DocumentPurposeDto>>> GetDocumentPurposeById(int id)
            {
                try
                {
                    var result = await _service.GetDocumentPurposeByIdAsync(id);
                    if (result == null)
                    {
                        return NotFound(ResponseFactory.Error<DocumentPurposeDto>(Request.Path, "Purpose not found.", StatusCodes.Status404NotFound));
                    }
                    return Ok(ResponseFactory.Success(Request.Path, result));
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ResponseFactory.Error<DocumentPurposeDto>(Request.Path, ex.Message, StatusCodes.Status500InternalServerError));
                }
            }

            [HttpPost]
            public async Task<ActionResult<ApiResponse<DocumentPurposeDto>>> CreateDocumentPurpose([FromBody] CreateDocumentPurposeDto dto)
            {
                try
                {
                    if (dto == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound,
                          ResponseFactory.Error<IEnumerable<PharmacyDto>>(Request.Path, "Không thể thêm.", StatusCodes.Status404NotFound));
                    }
                    var result = await _service.CreateDocumentPurposeAsync(dto);
                    return CreatedAtAction(nameof(GetDocumentPurposeById), new { id = result.DocumentPurposeId },
                        ResponseFactory.Success(Request.Path, result));
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ResponseFactory.Error<DocumentPurposeDto>(Request.Path, ex.Message, StatusCodes.Status500InternalServerError));
                }
            }

        [HttpPut("{id}")]
            public async Task<ActionResult<ApiResponse<DocumentPurposeDto>>> UpdateDocumentPurpose(int id, [FromBody] DocumentPurposeDto documentPurposeDto)
            {
                try
                {
                    var result = await _service.UpdateDocumentPurposeAsync(id, documentPurposeDto);
                    if (result == null)
                    {
                        return NotFound(ResponseFactory.Error<DocumentPurposeDto>(Request.Path, "Purpose not found.", StatusCodes.Status404NotFound));
                    }
                    return Ok(ResponseFactory.Success(Request.Path, result));
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ResponseFactory.Error<DocumentPurposeDto>(Request.Path, ex.Message, StatusCodes.Status500InternalServerError));
                }
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<ApiResponse<object>>> DeleteDocumentPurpose(int id)
            {
                try
                {
                    var isDeleted = await _service.DeleteDocumentPurposeAsync(id);
                    if (!isDeleted)
                    {
                        return NotFound(ResponseFactory.Error<object>(Request.Path, "Purpose not found.", StatusCodes.Status404NotFound));
                    }
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ResponseFactory.Error<object>(Request.Path, ex.Message, StatusCodes.Status500InternalServerError));
                }
            }
        }

    }
}
