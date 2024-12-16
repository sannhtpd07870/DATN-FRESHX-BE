using AutoMapper;
using Freshx_API.Dtos.InventoryType;
using Freshx_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryTypeController : ControllerBase
    {
        private readonly InventoryTypeService _service;

        public InventoryTypeController(InventoryTypeService service)
        {
            _service = service;
        }

        // API GET: Lấy danh sách loại tồn kho
        [HttpGet]
        public async Task<ActionResult<List<InventoryTypeDto>>> GetAll(string? searchKeyword)
        {
            var result = await _service.GetAllAsync(searchKeyword);

            if (result == null || !result.Any())
            {
                return NotFound("Chưa có dữ liệu nào.");
            }

            return Ok(result);
        }

        // API GET: Lấy thông tin loại tồn kho theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryTypeDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound("Loại tồn kho không tồn tại.");
            }

            return Ok(result);
        }

        // API POST: Tạo mới loại tồn kho
        [HttpPost]
        public async Task<ActionResult<InventoryTypeDto>> Create([FromBody] InventoryTypeCreateUpdateDto dto)
        {
            var result = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = result.InventoryTypeId }, result);
        }

        // API PUT: Cập nhật thông tin loại tồn kho
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] InventoryTypeCreateUpdateDto dto)
        {
            var isUpdated = await _service.UpdateAsync(id, dto);

            if (!isUpdated)
            {
                return NotFound("Loại tồn kho không tồn tại.");
            }

            return NoContent(); // Trả về 204 No Content khi cập nhật thành công
        }

        // API DELETE: Xóa mềm loại tồn kho
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var isDeleted = await _service.DeleteAsync(id);

            if (!isDeleted)
            {
                return NotFound("Loại tồn kho không tồn tại.");
            }

            return NoContent(); // Trả về 204 No Content khi xóa thành công
        }
    }
}
