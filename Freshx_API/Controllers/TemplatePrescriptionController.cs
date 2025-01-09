﻿using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Mvc;
using Freshx_API.Dtos.TmplPrescription;
using Freshx_API.Services.TmplPrescription;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TmplPrescriptionController : ControllerBase
    {
        private readonly TmplPrescriptionService _service;
        private readonly ILogger<PrescriptionController> _logger;

        public TmplPrescriptionController(TmplPrescriptionService service, ILogger<PrescriptionController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<TmplPrescriptionDto>>>> GetAll([FromQuery] string? searchKey)
        {
            try
            {
                var result = await _service.GetAllAsync(searchKey);

                if (!result.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<List<TmplPrescriptionDto>>(Request.Path, "Không tìm thấy dữ liệu.", StatusCodes.Status404NotFound));
                }

                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result, "Dữ liệu lấy thành công.", StatusCodes.Status200OK));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Một lỗi đã xảy ra khi tìm nạp danh sách toa thuốc.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<List<TmplPrescriptionDto>>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<TmplPrescriptionDto>>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    ResponseFactory.Error<TmplPrescriptionDto>(Request.Path, "Không tìm thấy dữ liệu.", StatusCodes.Status404NotFound));
            }

            return StatusCode(StatusCodes.Status200OK,
                ResponseFactory.Success(Request.Path, result, "Dữ liệu lấy thành công.", StatusCodes.Status200OK));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTmplPrescriptionDto dto)
        {
            await _service.AddAsync(dto);
            return StatusCode(StatusCodes.Status201Created,
                ResponseFactory.Success(Request.Path, dto, "Thêm mới thành công.", StatusCodes.Status201Created));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTmplPrescriptionDto dto)
        {
            await _service.UpdateAsync(dto);
            return StatusCode(StatusCodes.Status200OK,
                ResponseFactory.Success(Request.Path, dto, "Cập nhật thành công.", StatusCodes.Status200OK));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK,
                ResponseFactory.Success(Request.Path, true, "Xóa thành công.", StatusCodes.Status200OK));
        }
    }

}