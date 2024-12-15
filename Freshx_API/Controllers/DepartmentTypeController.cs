using Freshx_API.Dtos.DepartmenTypeDtos;
using Freshx_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentTypeController : ControllerBase
    {
        private readonly DepartmentTypeService _service;

        public DepartmentTypeController(DepartmentTypeService service)
        {
            _service = service;
        }

        // API GET: Lấy danh sách phòng ban
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            if (result == null || !result.Any())
                return NotFound("Chưa có dữ liệu nào.");
            return Ok(result);
        }

        // API GET: Lấy danh sách chi tiết phòng ban
        [HttpGet("detail")]
        public async Task<IActionResult> GetDetailAll()
        {
            var result = await _service.GetAllDetailAsync();
            if (result == null || !result.Any())
                return NotFound("Chưa có dữ liệu nào.");
            return Ok(result);
        }


        // API GET: Lấy thông tin phòng ban theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound("Phòng ban không tồn tại.");
            return Ok(result);
        }

        // API POST: Tạo mới phòng ban
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentTypeCreateUpdateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.DepartmentTypeId }, result);
        }

        // API PUT: Cập nhật thông tin phòng ban
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartmentTypeCreateUpdateDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok("Cập nhật thành công!");
        }

        // API DELETE: Xóa mềm phòng ban
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Xóa mền thành công!");
        }
    }
}
