using Microsoft.AspNetCore.Mvc;
using Freshx_API.Dtos.MedicalHistory;
using Freshx_API.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freshx_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IMedicalHistoryRepository _medicalHistoryService;

        public MedicalHistoryController(IMedicalHistoryRepository medicalHistoryService)
        {
            _medicalHistoryService = medicalHistoryService;
        }

        // Lấy danh sách tất cả hồ sơ bệnh án
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalHistoryDto>>> GetAllMedicalHistories([FromQuery] string? searchKeyword)
        {
            var medicalHistories = await _medicalHistoryService.GetAllAsync(searchKeyword);
            return Ok(medicalHistories);
        }

        // Lấy hồ sơ bệnh án theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalHistoryDto>> GetMedicalHistoryById(int id)
        {
            var medicalHistory = await _medicalHistoryService.GetByIdAsync(id);

            if (medicalHistory == null)
            {
                return NotFound(); // Not Found if no record is found
            }

            return Ok(medicalHistory);
        }

        // Tạo mới hồ sơ bệnh án
        [HttpPost]
        public async Task<ActionResult<MedicalHistoryDto>> CreateMedicalHistory([FromBody] MedicalHistoryCreateUpdateDto dto)
        {
            // Kiểm tra PatientId có hợp lệ không
            if (dto.PatientId <= 0)
            {
                return BadRequest("Invalid PatientId.");
            }

            // Gọi service để tạo hồ sơ bệnh án
            var createdMedicalHistory = await _medicalHistoryService.CreateAsync(dto);

            // Trả về hồ sơ bệnh án vừa tạo với mã trạng thái 201 Created
            return CreatedAtAction(nameof(GetMedicalHistoryById), new { id = createdMedicalHistory.Id }, createdMedicalHistory);
        }


        // Cập nhật hồ sơ bệnh án
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalHistory(int id, [FromBody] MedicalHistoryCreateUpdateDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch");
            }

            var result = await _medicalHistoryService.UpdateAsync(id, dto);

            if (result == null)
            {
                return NotFound("Medical history not found.");
            }

            return Ok(result); // Return updated medical history
        }

        // Xóa hồ sơ bệnh án
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalHistory(int id)
        {
            var result = await _medicalHistoryService.DeleteAsync(id);

            if (!result)
            {
                return NotFound("Medical history not found.");
            }

            return NoContent(); // No content as the resource is deleted
        }
    }
}
