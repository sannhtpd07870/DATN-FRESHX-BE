using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Freshx_API.Services.CommonServices;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Drugs;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugTypeController : ControllerBase
    {
        private readonly IDrugTypeService _drugTypeService;
        private readonly ILogger<DrugTypeController> _logger;

        public DrugTypeController(IDrugTypeService drugTypeService, ILogger<DrugTypeController> logger)
        {
            _drugTypeService = drugTypeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<DrugTypeDto>>>> GetDrugType()
        {
            try
            {
                var drugType = await _drugTypeService.GetDrugTypeAsync();

                if (drugType == null)
                {
                    return NotFound(ResponseFactory.Error<DrugTypeDto>(
                        Request.Path,
                        "Drug type not found",
                        StatusCodes.Status404NotFound));
                }

                return Ok(ResponseFactory.Success(Request.Path, drugType, "Drug type retrieved successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the drug type with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<DrugTypeDto>(
                        Request.Path,
                        "An error occurred while retrieving the drug type",
                        StatusCodes.Status500InternalServerError));
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<DrugTypeDto>>> GetDrugTypeById(int id)
        {
            try
            {
                var drugType = await _drugTypeService.GetDrugTypeByIdAsync(id);

                if (drugType == null)
                {
                    return NotFound(ResponseFactory.Error<DrugTypeDto>(
                        Request.Path,
                        "Drug type not found",
                        StatusCodes.Status404NotFound));
                }

                return Ok(ResponseFactory.Success(Request.Path, drugType, "Drug type retrieved successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the drug type with ID {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<DrugTypeDto>(
                        Request.Path,
                        "An error occurred while retrieving the drug type",
                        StatusCodes.Status500InternalServerError));
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<DrugTypeDto>>> CreateDrugType([FromBody] DrugTypeCreateDto createDto)
        {
            try
            {
                var createdDrugType = await _drugTypeService.CreateDrugTypeAsync(createDto);

                return StatusCode(StatusCodes.Status201Created,
                    ResponseFactory.Success(Request.Path, createdDrugType, "Drug type created successfully", StatusCodes.Status201Created));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new drug type");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<DrugTypeDto>(
                        Request.Path,
                        "An error occurred while creating the drug type",
                        StatusCodes.Status500InternalServerError));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<DrugTypeDto>>> UpdateDrugType(int id, [FromBody] DrugTypeUpdateDto updateDto)
        {
            try
            {
                var updatedDrugType = await _drugTypeService.UpdateDrugTypeAsync(id, updateDto);

                if (updatedDrugType == null)
                {
                    return NotFound(ResponseFactory.Error<DrugTypeDto>(
                        Request.Path,
                        "Drug type not found",
                        StatusCodes.Status404NotFound));
                }

                return Ok(ResponseFactory.Success(Request.Path, updatedDrugType, "Drug type updated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the drug type with ID {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<DrugTypeDto>(
                        Request.Path,
                        "An error occurred while updating the drug type",
                        StatusCodes.Status500InternalServerError));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteDrugType(int id)
        {
            try
            {
                var isDeleted = await _drugTypeService.DeleteDrugTypeAsync(id);

                if (!isDeleted)
                {
                    return NotFound(ResponseFactory.Error<bool>(
                        Request.Path,
                        "Drug type not found",
                        StatusCodes.Status404NotFound));
                }

                return Ok(ResponseFactory.Success(Request.Path, true, "Drug type deleted successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the drug type with ID {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<bool>(
                        Request.Path,
                        "An error occurred while deleting the drug type",
                        StatusCodes.Status500InternalServerError));
            }
        }
    }
}
