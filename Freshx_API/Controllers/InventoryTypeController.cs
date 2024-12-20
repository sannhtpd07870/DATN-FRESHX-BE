using AutoMapper;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.InventoryType;
using Freshx_API.Services;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryTypeController : ControllerBase
    {
        private readonly InventoryTypeService _service;
        private readonly ILogger<InventoryTypeController> _logger;

        public InventoryTypeController(InventoryTypeService service, ILogger<InventoryTypeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // API GET: Lấy danh sách loại tồn kho
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<InventoryTypeDto>>>> GetAll(string? searchKeyword)
        {
            try
            {
                var result = await _service.GetAllAsync(searchKeyword);

                if (result == null || !result.Any())
                {
                    return StatusCode(
                        StatusCodes.Status404NotFound,
                        ResponseFactory.Error<IEnumerable<InventoryTypeDto>>(Request.Path, "Chưa có dữ liệu nào.", StatusCodes.Status404NotFound)
                    );
                }

                return StatusCode(
                    StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result)
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching inventory types.");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<IEnumerable<InventoryTypeDto>>(Request.Path, "Internal server error", StatusCodes.Status500InternalServerError)
                );
            }
        }

        // API GET: Lấy thông tin loại tồn kho theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<InventoryTypeDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);

                if (result == null)
                {
                    return StatusCode(
                        StatusCodes.Status404NotFound,
                        ResponseFactory.Error<InventoryTypeDto>(Request.Path, "Loại tồn kho không tồn tại.", StatusCodes.Status404NotFound)
                    );
                }

                return StatusCode(
                    StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result)
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching inventory type with ID: {id}");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<InventoryTypeDto>(Request.Path, "Internal server error", StatusCodes.Status500InternalServerError)
                );
            }
        }

        // API POST: Tạo mới loại tồn kho
        [HttpPost]
        public async Task<ActionResult<ApiResponse<InventoryTypeDto>>> Create([FromBody] InventoryTypeCreateUpdateDto dto)
        {
            try
            {
                var result = await _service.CreateAsync(dto);

                return StatusCode(
                    StatusCodes.Status201Created,
                    ResponseFactory.Success(Request.Path, result)
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating inventory type.");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<InventoryTypeDto>(Request.Path, "Internal server error", StatusCodes.Status500InternalServerError)
                );
            }
        }

        // API PUT: Cập nhật thông tin loại tồn kho
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> Update(int id, [FromBody] InventoryTypeCreateUpdateDto dto)
        {
            try
            {
                var isUpdated = await _service.UpdateAsync(id, dto);

                if (!isUpdated)
                {
                    return StatusCode(
                        StatusCodes.Status404NotFound,
                        ResponseFactory.Error<object>(Request.Path, "Loại tồn kho không tồn tại.", StatusCodes.Status404NotFound)
                    );
                }

                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseFactory.Success<object>(Request.Path, null)
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating inventory type with ID: {id}");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<object>(Request.Path, "Internal server error", StatusCodes.Status500InternalServerError)
                );
            }
        }

        // API DELETE: Xóa mềm loại tồn kho
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(int id)
        {
            try
            {
                var isDeleted = await _service.DeleteAsync(id);

                if (!isDeleted)
                {
                    return StatusCode(
                        StatusCodes.Status404NotFound,
                        ResponseFactory.Error<object>(Request.Path, "Loại tồn kho không tồn tại.", StatusCodes.Status404NotFound)
                    );
                }

                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseFactory.Success<object>(Request.Path, null)
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting inventory type with ID: {id}");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<object>(Request.Path, "Internal server error", StatusCodes.Status500InternalServerError)
                );
            }
        }
    }
}
