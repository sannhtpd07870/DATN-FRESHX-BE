using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Interfaces;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Models;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineAppointmentController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly ILogger<OnlineAppointmentController> _logger;
        private readonly IMapper _mapper;
        private readonly IOnlineAppointmentRepository _onlineAppointmentRepository;
        public OnlineAppointmentController(ITokenRepository tokenRepository, ILogger<OnlineAppointmentController> logger, IMapper mapper, IOnlineAppointmentRepository onlineAppointmentRepository)
        {
            _tokenRepository = tokenRepository;
            _logger = logger;
            _mapper = mapper;
            _onlineAppointmentRepository = onlineAppointmentRepository;
        }
        [HttpPost("Create-OnlineAppointment")]
        public async Task<ActionResult<ApiResponse<OnlineAppointmentDto?>>> CreateOnlineAppointment([FromForm]CreateUpdateOnlineAppointment request)
        {
            try
            {
                string accountId = _tokenRepository.GetUserIdFromToken();
                if(accountId == null)
                {
                    return BadRequest(ResponseFactory.Error<OnlineAppointmentDto>(Request.Path, "Vui lòng đăng nhập vào hệ thống để tiến hành đặt lịch"));
                }
                var onlineAppointment = await _onlineAppointmentRepository.CreateOnlineAppointment(request, accountId);
                if(onlineAppointment == null)
                {
                    return BadRequest(ResponseFactory.Error<OnlineAppointmentDto>(Request.Path, "Lịch hẹn của bạn đã có người, vui lòng chọn lịch khác"));
                }
                var data = _mapper.Map<OnlineAppointmentDto>(onlineAppointment);
                return Ok(ResponseFactory.Success<OnlineAppointmentDto>(Request.Path, data, "Lịch hẹn đã được đặt thành công"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<OnlineAppointmentDto>(Request.Path,"Một ngoại lệ đã xảy ra khi tạo lịch hẹn",StatusCodes.Status500InternalServerError));
            }
        }
        [HttpGet("Get-OnlineAppointmentDetail")]
        public async Task<ActionResult<ApiResponse<OnlineAppointmentDto?>>> GetOnlineAppointmentByAccountId()
        {

            try
            {
                string accountId = _tokenRepository.GetUserIdFromToken();
                if (string.IsNullOrEmpty(accountId))
                {
                    return BadRequest(ResponseFactory.Error<OnlineAppointmentDto>(
                        Request.Path,
                        "Vui lòng đăng nhập vào hệ thống để xem đặt lịch hẹn chi tiết"
                    ));
                }

                var onlineAppointment = await _onlineAppointmentRepository.GetOnlineAppointmentById(accountId);
                if (onlineAppointment == null)
                {
                    return NotFound(ResponseFactory.Error<OnlineAppointmentDto>(
                        Request.Path,
                        "Không tìm thấy lịch hẹn"
                    ));
                }

                var data = _mapper.Map<OnlineAppointmentDto>(onlineAppointment);
                return Ok(ResponseFactory.Success<OnlineAppointmentDto>(Request.Path, data));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<OnlineAppointmentDto>(
                        Request.Path,
                        "Một ngoại lệ đã xảy ra khi hiện thông tin lịch hẹn chi tiết",
                        StatusCodes.Status500InternalServerError
                    )
                );
            }
        }

    }
}
