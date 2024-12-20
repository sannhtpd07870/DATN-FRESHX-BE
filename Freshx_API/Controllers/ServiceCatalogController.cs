﻿using Azure.Core;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.ServiceCatalog;
using Freshx_API.Services.CommonServices;
using Freshx_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceCatalogController : ControllerBase
    {
        private readonly ServiceCatalogService _service;
        private readonly ILogger<ServiceCatalogController> _logger;

        public ServiceCatalogController(ServiceCatalogService service, ILogger<ServiceCatalogController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet()]
        public async Task<ActionResult<ApiResponse<List<ServiceCatalogDto>>>> GetAll(string? searchKeyword, DateTime? createdDate, DateTime? updatedDate, int? status)
        {
            try
            {
                var result = await _service.GetAllAsync(searchKeyword, createdDate, updatedDate, status);

                if (result == null || !result.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<List<ServiceCatalogDto>>(Request.Path, "Không tìm thấy dữ liệu.", StatusCodes.Status404NotFound));
                }

                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result, "Dữ liệu lấy thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một lỗi đã xảy ra trong khi tìm nạp các danh mục dịch vụ.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<List<ServiceCatalogDto>>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ServiceCatalogDetailDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<ServiceCatalogDetailDto>(Request.Path, "Danh mục dịch vụ không tìm thấy.", StatusCodes.Status404NotFound));
                }

                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result, "Chi tiết danh mục dịch vụ lấy thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một lỗi đã xảy ra trong khi tìm nạp danh mục dịch vụ bởi ID.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<ServiceCatalogDetailDto>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ServiceCatalogDto>>> Create([FromBody] ServiceCatalogCreateUpdateDto dto)
        {
            try
            {
                var result = await _service.CreateAsync(dto);
                return StatusCode(StatusCodes.Status201Created,
                    ResponseFactory.Success(Request.Path, result, "Danh mục dịch vụ tạo thành công.", StatusCodes.Status201Created));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một lỗi đã xảy ra trong khi tạo danh mục dịch vụ.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<ServiceCatalogDto>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Update(int id, [FromBody] ServiceCatalogCreateUpdateDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, "Cập nhật thành công.", "Danh mục dịch vụ cập nhật thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một lỗi đã xảy ra trong khi cập nhật danh mục dịch vụ.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<string>(Request.Path, "Một lỗi đã xảy ra hoặc danh mục dịch vụ không tồn tại", StatusCodes.Status500InternalServerError));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, "Danh mục dịch vụ đã xóa thành công.", "Xóa thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một lỗi đã xảy ra trong khi xóa danh mục dịch vụ.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<string>(Request.Path, "Một lỗi đã xảy ra hoặc danh mục dịch vụ không tồn tại", StatusCodes.Status500InternalServerError));
            }
        }
    }
}
