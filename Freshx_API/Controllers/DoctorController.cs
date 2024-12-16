using Azure.Core;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Doctor;
using Freshx_API.Services.CommonServices;
using Freshx_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _service;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(DoctorService service, ILogger<DoctorController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // API GET: Lấy danh sách bác sĩ với các tiêu chí tìm kiếm
        [HttpGet()]
        public async Task<ActionResult<ApiResponse<List<DoctorDto>>>> GetAll(string? searchKeyword, DateTime? startDate, DateTime? endDate, int? status, string? specialty, string? phone, string? email, string? gender)
        {
            try
            {
                // Gọi service để lấy danh sách bác sĩ với các tham số tìm kiếm
                var result = await _service.GetAllAsync(searchKeyword, status, startDate, endDate, specialty, phone, email, gender);

                // Nếu danh sách rỗng, trả về thông báo lỗi với mã trạng thái 404
                if (result == null || !result.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<List<DoctorDto>>(Request.Path, "Chưa có dữ liệu nào.", StatusCodes.Status404NotFound));
                }

                // Trả về dữ liệu với mã trạng thái 200 (OK)
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result, "Lấy dữ liệu thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                // Log lỗi nếu xảy ra ngoại lệ và trả về mã trạng thái 500 (Internal Server Error)
                _logger.LogError(e, "Một ngoại lệ đã xảy ra trong khi tìm nạp các bác sĩ");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<List<DoctorDto>>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        // API GET: Lấy danh sách bác sĩ chi tiết với các tiêu chí tìm kiếm
        [HttpGet("detail")]
        public async Task<ActionResult<ApiResponse<List<DoctorDetailDto>>>> GetDetailAll(string? searchKeyword, DateTime? startDate, DateTime? endDate, int? status, string? specialty, string? phone, string? email, string? gender)
        {
            try
            {
                // Gọi service để lấy danh sách bác sĩ chi tiết với các tham số tìm kiếm
                var result = await _service.GetDetailAllAsync(searchKeyword, status, startDate, endDate, specialty, phone, email, gender);

                // Nếu danh sách rỗng, trả về thông báo lỗi với mã trạng thái 404
                if (result == null || !result.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<List<DoctorDetailDto>>(Request.Path, "Chưa có dữ liệu nào.", StatusCodes.Status404NotFound));
                }

                // Trả về dữ liệu với mã trạng thái 200 (OK)
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result, "Lấy dữ liệu thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                // Log lỗi nếu xảy ra ngoại lệ và trả về mã trạng thái 500 (Internal Server Error)
                _logger.LogError(e, "Một ngoại lệ đã xảy ra trong khi tìm nạp các bác sĩ");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<List<DoctorDetailDto>>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }
        // API GET: Lấy thông tin bác sĩ theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<DoctorDto>>> GetById(int id)
        {
            try
            {
                // Gọi service để lấy thông tin chi tiết bác sĩ theo ID
                var result = await _service.GetByIdAsync(id);

                // Nếu không tìm thấy bác sĩ, trả về thông báo lỗi với mã trạng thái 404
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<DoctorDto>(Request.Path, "Bác sĩ không tồn tại.", StatusCodes.Status404NotFound));
                }

                // Trả về dữ liệu bác sĩ với mã trạng thái 200 (OK)
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result, "Lấy thông tin bác sĩ thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                // Log lỗi nếu xảy ra ngoại lệ và trả về mã trạng thái 500 (Internal Server Error)
                _logger.LogError(e, "Một ngoại lệ xảy ra trong khi tìm nạp bác sĩ bằng ID");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<DoctorDto>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        // API POST: Tạo mới bác sĩ
        [HttpPost]
        public async Task<ActionResult<ApiResponse<DoctorDto>>> Create([FromBody] DoctorCreateUpdateDto dto)
        {
            try
            {
                // Gọi service để tạo mới một bác sĩ dựa trên dữ liệu từ client
                var result = await _service.CreateAsync(dto);

                // Trả về dữ liệu bác sĩ vừa được tạo với mã trạng thái 201 (Created)
                return StatusCode(StatusCodes.Status201Created,
                    ResponseFactory.Success(Request.Path, result, "Tạo mới bác sĩ thành công.", StatusCodes.Status201Created));
            }
            catch (Exception e)
            {
                // Log lỗi nếu xảy ra ngoại lệ và trả về mã trạng thái 500 (Internal Server Error)
                _logger.LogError(e, "Một ngoại lệ đã xảy ra trong khi tạo bác sĩ");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<DoctorDto>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        // API PUT: Cập nhật thông tin bác sĩ
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Update(int id, [FromBody] DoctorCreateUpdateDto dto)
        {
            try
            {
                // Gọi service để cập nhật thông tin bác sĩ dựa trên ID và dữ liệu từ client
                await _service.UpdateAsync(id, dto);

                // Trả về thông báo thành công với mã trạng thái 200 (OK)
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, "Cập nhật thành công!", "Cập nhật thành công!", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                // Log lỗi nếu xảy ra ngoại lệ và trả về mã trạng thái 500 (Internal Server Error)
                _logger.LogError(e, "Một ngoại lệ đã xảy ra trong khi cập nhật bác sĩ");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<string>(Request.Path, "Một lỗi đã xảy ra. Bác sĩ không tông tại với ID " + id, StatusCodes.Status500InternalServerError));
            }
        }

        // API DELETE: Xóa mềm bác sĩ
        [HttpDelete("soft_delete/{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Delete(int id)
        {
            try
            {
                // Gọi service để xóa mềm bác sĩ theo ID
                await _service.DeleteAsync(id);

                // Trả về thông báo thành công với mã trạng thái 200 (OK)
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, "Xóa mềm thành công!", "Xóa mềm thành công!", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                // Log lỗi nếu xảy ra ngoại lệ và trả về mã trạng thái 500 (Internal Server Error)
                _logger.LogError(e, "Một ngoại lệ đã xảy ra trong khi xóa bác sĩ");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<string>(Request.Path, "Một lỗi đã xảy ra. Bác sĩ không tông tại với ID " + id, StatusCodes.Status500InternalServerError));
            }
        }
    }
}
