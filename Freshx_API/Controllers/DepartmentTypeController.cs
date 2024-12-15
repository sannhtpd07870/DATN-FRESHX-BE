using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.DepartmenTypeDtos;
using Freshx_API.Services;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentTypeController : ControllerBase
    {
        private readonly DepartmentTypeService _service;
        private readonly ILogger<AccountController> _logger;
        public DepartmentTypeController(DepartmentTypeService service, ILogger<AccountController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // API GET: Lấy danh sách phòng ban
        [HttpGet()]
        public async Task<ActionResult<ApiResponse<List<DepartmentTypeDto>>>> GetAll(string? searchKeyword,
      DateTime? CreatetDate,
      DateTime? UpdatedDate,
      int? status)
        {
            try
            {
                // Gọi service để lấy danh sách tất cả các phòng ban
                var result = await _service.GetAllAsync(searchKeyword, CreatetDate, UpdatedDate, status);

                // Nếu danh sách rỗng, trả về thông báo lỗi với mã trạng thái 404
                if (result == null || !result.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<List<DepartmentTypeDto>>(Request.Path, "Chưa có dữ liệu nào.", StatusCodes.Status404NotFound));
                }

                // Trả về dữ liệu với mã trạng thái 200 (OK)
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result, "Lấy dữ liệu thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                // Log lỗi nếu xảy ra ngoại lệ và trả về mã trạng thái 500 (Internal Server Error)
                _logger.LogError(e, "An exception occurred while fetching departments");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<List<DepartmentTypeDto>>(Request.Path, "An error occurred.", StatusCodes.Status500InternalServerError));
            }
        }

        // API GET: Lấy danh sách chi tiết phòng ban
        [HttpGet("detail")]
        public async Task<ActionResult<ApiResponse<List<DepartmentTypeDetailDto>>>> GetDetailAll(string? searchKeyword,
      DateTime? startDate,
      DateTime? endDate,
      int? status)
        {
            try
            {
                // Gọi service để lấy danh sách chi tiết của tất cả phòng ban
                var result = await _service.GetAllDetailAsync(searchKeyword,startDate,endDate,status);

                // Nếu danh sách rỗng, trả về thông báo lỗi với mã trạng thái 404
                if (result == null || !result.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<List<DepartmentTypeDetailDto>>(Request.Path, "Chưa có dữ liệu nào.", StatusCodes.Status404NotFound));
                }

                // Trả về dữ liệu chi tiết với mã trạng thái 200 (OK)
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result, "Lấy dữ liệu chi tiết thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                // Log lỗi nếu xảy ra ngoại lệ và trả về mã trạng thái 500 (Internal Server Error)
                _logger.LogError(e, "An exception occurred while fetching department details");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<List<DepartmentTypeDetailDto>>(Request.Path, "An error occurred.", StatusCodes.Status500InternalServerError));
            }
        }

        // API GET: Lấy thông tin phòng ban theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<DepartmentTypeDto>>> GetById(int id)
        {
            try
            {
                // Gọi service để lấy thông tin chi tiết của phòng ban theo ID
                var result = await _service.GetByIdAsync(id);

                // Nếu không tìm thấy phòng ban, trả về thông báo lỗi với mã trạng thái 404
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<DepartmentTypeDto>(Request.Path, "Phòng ban không tồn tại.", StatusCodes.Status404NotFound));
                }

                // Trả về dữ liệu phòng ban với mã trạng thái 200 (OK)
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, result, "Lấy thông tin phòng ban thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                // Log lỗi nếu xảy ra ngoại lệ và trả về mã trạng thái 500 (Internal Server Error)
                _logger.LogError(e, "An exception occurred while fetching department by ID");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<DepartmentTypeDto>(Request.Path, "An error occurred.", StatusCodes.Status500InternalServerError));
            }
        }

        // API POST: Tạo mới phòng ban
        [HttpPost]
        public async Task<ActionResult<ApiResponse<DepartmentTypeDto>>> Create([FromBody] DepartmentTypeCreateUpdateDto dto)
        {
            try
            {
                // Gọi service để tạo mới một phòng ban dựa trên dữ liệu từ client
                var result = await _service.CreateAsync(dto);

                // Trả về dữ liệu phòng ban vừa được tạo với mã trạng thái 201 (Created)
                return StatusCode(StatusCodes.Status201Created,
                    ResponseFactory.Success(Request.Path, result, "Tạo mới phòng ban thành công.", StatusCodes.Status201Created));
            }
            catch (Exception e)
            {
                // Log lỗi nếu xảy ra ngoại lệ và trả về mã trạng thái 500 (Internal Server Error)
                _logger.LogError(e, "An exception occurred while creating department");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<DepartmentTypeDto>(Request.Path, "An error occurred.", StatusCodes.Status500InternalServerError));
            }
        }

        // API PUT: Cập nhật thông tin phòng ban
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Update(int id, [FromBody] DepartmentTypeCreateUpdateDto dto)
        {
            try
            {
                // Gọi service để cập nhật thông tin phòng ban dựa trên ID và dữ liệu từ client
                await _service.UpdateAsync(id, dto);

                // Trả về thông báo thành công với mã trạng thái 200 (OK)
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, "Cập nhật thành công!", "Cập nhật thành công!", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                // Log lỗi nếu xảy ra ngoại lệ và trả về mã trạng thái 500 (Internal Server Error)
                _logger.LogError(e, "An exception occurred while updating department");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<string>(Request.Path, "An error occurred.", StatusCodes.Status500InternalServerError));
            }
        }

        // API DELETE: Xóa mềm phòng ban
        [HttpDelete("soft_delete{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Delete(int id)
        {
            try
            {
                // Gọi service để xóa mềm phòng ban theo ID
                await _service.DeleteAsync(id);

                // Trả về thông báo thành công với mã trạng thái 200 (OK)
                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, "Xóa mềm thành công!", "Xóa mềm thành công!", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                // Log lỗi nếu xảy ra ngoại lệ và trả về mã trạng thái 500 (Internal Server Error)
                _logger.LogError(e, "An exception occurred while deleting department");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<string>(Request.Path, "An error occurred.", StatusCodes.Status500InternalServerError));
            }
        }
    }
}
