﻿using Azure.Core;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Pharmacy;
using Freshx_API.Services.CommonServices;
using Freshx_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PharmacyController : ControllerBase
    {
        private readonly PharmacyService _service;
        private readonly ILogger<PharmacyController> _logger;

        public PharmacyController(PharmacyService service, ILogger<PharmacyController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet()]
        public async Task<ActionResult<ApiResponse<IEnumerable<PharmacyDto>>>> GetAll(string? searchKeyword, DateTime? createdDate, DateTime? updatedDate, bool? isSuspended, int? inventoryTypeId, int? specialtyId)
        {
            try
            {
                var result = await _service.GetAllAsync(searchKeyword, createdDate, updatedDate, isSuspended, inventoryTypeId, specialtyId);

                if (result == null || !result.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<IEnumerable<PharmacyDto>>(Request.Path, "Không tìm thấy dữ liệu.", StatusCodes.Status404NotFound));
                }

                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result, "Dữ liệu lấy thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một lỗi đã xảy ra trong khi tìm nạp danh sách nhà thuốc.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<IEnumerable<PharmacyDto>>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }


        [HttpGet("detail")]
        public async Task<ActionResult<ApiResponse<IEnumerable<PharmacyDetailDto>>>> GetDetailAll(string? searchKeyword, DateTime? createdDate, DateTime? updatedDate, bool? isSuspended, int? inventoryTypeId, int? specialtyId)
        {
            try
            {
                var result = await _service.GetDetailAllAsync(searchKeyword, createdDate, updatedDate, isSuspended, inventoryTypeId, specialtyId);

                if (result == null || !result.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<IEnumerable<PharmacyDetailDto>>(Request.Path, "Không tìm thấy dữ liệu.", StatusCodes.Status404NotFound));
                }

                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result, "Dữ liệu lấy thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một lỗi đã xảy ra trong khi tìm nạp danh sách nhà thuốc.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<IEnumerable<PharmacyDto>>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PharmacyDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<PharmacyDto>(Request.Path, "Nhà thuốc không tìm thấy.", StatusCodes.Status404NotFound));
                }

                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result, "Chi tiết nhà thuốc lấy thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một lỗi đã xảy ra trong khi tìm nạp nhà thuốc theo ID.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<PharmacyDto>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<PharmacyDto>>> Create([FromBody] PharmacyCreateUpdateDto dto)
        {
            try
            {
                var result = await _service.CreateAsync(dto);
                return StatusCode(StatusCodes.Status201Created,
                    ResponseFactory.Success(Request.Path, result, "Nhà thuốc tạo thành công.", StatusCodes.Status201Created));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một lỗi đã xảy ra trong khi tạo nhà thuốc.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<PharmacyDto>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Update(int id, [FromBody] PharmacyCreateUpdateDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, "Cập nhật thành công.", "Nhà thuốc cập nhật thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một lỗi đã xảy ra trong khi cập nhật nhà thuốc.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<string>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, "Nhà thuốc đã xóa thành công.", "Xóa thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một lỗi đã xảy ra trong khi xóa nhà thuốc.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<string>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }
    }
}