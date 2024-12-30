using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Interfaces;
using Freshx_API.Interfaces.IReception;
using Freshx_API.Models;
using Freshx_API.Repository;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Mvc;


namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptionController : ControllerBase
    {
        private readonly IReceptionService _service;
        private readonly ILogger<ReceptionController> _logger;

        public ReceptionController(IReceptionService service, ILogger<ReceptionController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ReceptionDto?>>> GetById(int id)
        {
            try
            {
                var reception = await _service.GetByIdAsync(id);
                if (reception == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory.Error<ReceptionDto?>(Request.Path, "Reception not found"));
                }

                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path, reception));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exceptional occurred while fetching the reception by ID");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<ReceptionDto?>(Request.Path, "An error occurred while processing your request"));
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ReceptionDto>>>> GetAll()
        {
            try
            {
                var receptions = await _service.GetAllAsync();
                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path, receptions));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exceptional occurred while fetching all receptions");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<IEnumerable<ReceptionDto>>(Request.Path, "An error occurred while processing your request"));
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ReceptionDto>>> Add([FromForm] CreateReceptionDto dto)
        {
            try
            {
                var reception = await _service.AddAsync(dto);
                if (reception == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory.Error<ReceptionDto>(Request.Path, "Invalid data provided"));
                }

                return StatusCode(StatusCodes.Status201Created, ResponseFactory.Success(Request.Path, reception));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exceptional occurred while adding a new reception");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<ReceptionDto>(Request.Path, "An error occurred while processing your request"));
            }
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<object>>> Update([FromForm] CreateReceptionDto dto)
        {
            try
            {
                await _service.UpdateAsync(dto);
                return StatusCode(StatusCodes.Status204NoContent, ResponseFactory.Success<object>(Request.Path, null, "Update successful"));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exceptional occurred while updating a reception");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<object>(Request.Path, "An error occurred while processing your request"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return StatusCode(StatusCodes.Status204NoContent, ResponseFactory.Success<object>(Request.Path, null, "Delete successful"));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exceptional occurred while deleting a reception");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<object>(Request.Path, "An error occurred while processing your request"));
            }
        }
    }
    

}
