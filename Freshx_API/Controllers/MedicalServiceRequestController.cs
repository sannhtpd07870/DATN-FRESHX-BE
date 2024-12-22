using Azure.Core;
using Freshx_API.Dtos;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Interfaces;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalServiceRequestController : ControllerBase
    {
        private readonly IMedicalServiceRequestService _service;
        private readonly ILogger<MedicalServiceRequestController> _logger;
        public MedicalServiceRequestController(
           IMedicalServiceRequestService service,
           ILogger<MedicalServiceRequestController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<MedicalServiceRequestDTO>>> Create(CreateMedicalServiceRequestDTO createDto)
        {
            try
            {
                var response = await _service.CreateAsync(createDto);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating medical service request");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<MedicalServiceRequestDTO>(
                        Request.Path,
                        "An error occurred while creating the medical service request",
                        StatusCodes.Status500InternalServerError));
            }
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<MedicalServiceRequestDTO>>>> GetAll()
        {
            try
            {
                var response = await _service.GetAllAsync();
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all medical service requests");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<IEnumerable<MedicalServiceRequestDTO>>(
                        Request.Path,
                        "An error occurred while retrieving medical service requests",
                        StatusCodes.Status500InternalServerError));
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<MedicalServiceRequestDTO>>> GetById(int id)
        {
            try
            {
                var response = await _service.GetByIdAsync(id);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting medical service request by id");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<MedicalServiceRequestDTO>(
                        Request.Path,
                        "An error occurred while retrieving the medical service request",
                        StatusCodes.Status500InternalServerError));
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<MedicalServiceRequestDTO>>> Update(
           int id,
           UpdateMedicalServiceRequestDTO updateDto)
        {
            try
            {
                var response = await _service.UpdateAsync(id, updateDto);
                    return StatusCode(StatusCodes.Status200OK, response);
                }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating medical service request");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<MedicalServiceRequestDTO>(
                        Request.Path,
                        "An error occurred while updating the medical service request",
                        StatusCodes.Status500InternalServerError));
            }
        }
    }
}
