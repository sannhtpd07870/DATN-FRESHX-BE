using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Patient;
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
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory.Error<ReceptionDto?>(Request.Path, "Không tìm thấy tiếp nhận"));
                }

                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path, reception));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Xảy ra lỗi khi lấy thông tin tiếp nhận bằng ID");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<ReceptionDto?>(Request.Path, "Đã xảy ra lỗi khi xử lý yêu cầu của bạn"));
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
                _logger.LogError(e, "Xảy ra lỗi khi lấy dữ liệu");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<IEnumerable<ReceptionDto>>(Request.Path, "Đã xảy ra lỗi khi xử lý yêu cầu của bạn:" + e.Message));
            }
        }

        [HttpGet("examine")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ExamineHistoryDto>>>> GetExamine(string? searchKey, bool isHistory = false)
        {
            try
            {
                var receptions = await _service.GetListExamine(searchKey, isHistory);
                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path, receptions));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Xảy ra lỗi khi lấy dữ liệu");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<IEnumerable<ReceptionDto>>(Request.Path, "Đã xảy ra lỗi khi xử lý yêu cầu của bạn:" + e.Message));
            }
        }
        [HttpGet("lapresult")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ExamineHistoryDto>>>> GetLapReult(string? searchKey, bool isHistory = false)
        {
            try
            {
                var receptions = await _service.GetListLabResult(searchKey, isHistory);
                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path, receptions));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Xảy ra lỗi khi lấy dữ liệu");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<IEnumerable<ReceptionDto>>(Request.Path, "Đã xảy ra lỗi khi xử lý yêu cầu của bạn:" + e.Message));
            }
        }

        [HttpGet("examine/{Id}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ExamineHistoryDto>>>> GetExamine(int Id)
        {
            try
            {
                var receptions = await _service.GetPatientHistory(Id);
                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path, receptions));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Xảy ra lỗi khi lấy dữ liệu");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<IEnumerable<ReceptionDto>>(Request.Path, "Đã xảy ra lỗi khi xử lý yêu cầu của bạn:" + e.Message));
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
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory.Error<ReceptionDto>(Request.Path, "Dữ liệu được cung cấp không hợp lệ"));
                }

                return StatusCode(StatusCodes.Status201Created, ResponseFactory.Success(Request.Path, reception));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<ReceptionDto>(Request.Path, "Đã xảy ra lỗi:" + e.Message));
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ApiResponse<object>>> Update(int Id,[FromForm] UpdateReceptionDto dto)
        {
            try
            {
                await _service.UpdateAsync(Id, dto);
                return StatusCode(StatusCodes.Status204NoContent, ResponseFactory.Success<object>(Request.Path, null, "Cập nhật thành công"));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Xảy ra lỗi khi cập nhật tiếp nhận");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<object>(Request.Path, "Đã xảy ra lỗi khi xử lý yêu cầu của bạn:" +e.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return StatusCode(StatusCodes.Status204NoContent, ResponseFactory.Success<object>(Request.Path, null, "Xóa thành công"));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Xảy ra lỗi khi xóa tiếp nhận");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<object>(Request.Path, "Đã xảy ra lỗi khi xử lý yêu cầu của bạn"));
            }
        }
    }
    

}
