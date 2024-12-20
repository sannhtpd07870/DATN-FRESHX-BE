using Freshx_API.Dtos;
using Freshx_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freshx_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PharmacyDto>> GetPharmacyById(int id)
        {
            var pharmacy = await _pharmacyService.GetPharmacyByIdAsync(id);
            if (pharmacy == null)
                return NotFound();
            return Ok(pharmacy);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PharmacyDto>>> GetAllPharmacies()
        {
            var pharmacies = await _pharmacyService.GetAllPharmaciesAsync();
            foreach (var pharmacy in pharmacies)
            {
                Console.WriteLine($"PharmacyId: {pharmacy.PharmacyId}, Code: {pharmacy.Code}, DepartmentId: {pharmacy.DepartmentId}");
            }
            return Ok(pharmacies);
        }

        [HttpPost]
        public async Task<ActionResult<PharmacyDto>> CreatePharmacy(PharmacyCreateDto pharmacyDto)
        {
            var createdPharmacy = await _pharmacyService.CreatePharmacyAsync(pharmacyDto);
            return CreatedAtAction(nameof(GetPharmacyById), new { id = createdPharmacy.PharmacyId }, createdPharmacy);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PharmacyDto>> UpdatePharmacy(int id, PharmacyUpdateDto pharmacyDto)
        {
            var updatedPharmacy = await _pharmacyService.UpdatePharmacyAsync(id, pharmacyDto);
            if (updatedPharmacy == null)
                return NotFound();
            return Ok(updatedPharmacy);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacy(int id)
        {
            await _pharmacyService.DeletePharmacyAsync(id);
            return NoContent();
        }
    }
}