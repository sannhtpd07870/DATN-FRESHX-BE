using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Freshx_API.Models;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos;
using Freshx_API.Interfaces.LabResultRepository;
using Freshx_API.Interfaces.Services;
using Freshx_API.Services;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Http;
using Sprache;
using Freshx_API.Dtos.LabResult;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LabResultController : ControllerBase
    {
        private readonly FreshxDBContext _context;
        private readonly ILabResultService _service;

        public LabResultController(FreshxDBContext context, ILabResultService service)
        {
            _context = context;
            _service = service;
        }

        // GET: LabResult get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<LabResultDto>>> GetLabResultById(int id)
        {
            //var freshxDBContext = _context.LabResults.Include(l => l.ConcludingDoctor).Include(l => l.Patient).Include(l => l.Reception).Include(l => l.Technician);
            //return View(await freshxDBContext.ToListAsync());

            var result = await _service.GetLabResultByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<LabResultDto>(Request.Path, "Không tìm thấy kết quả xét nghiệm.", StatusCodes.Status404NotFound));
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        // GET: LabResults get all
        [HttpGet]
        public async Task<ActionResult<ApiResponse<LabResultDto>>> GetAllLabResults(string? searchKeyword, DateTime? createdDate, DateTime? updatedDate)
        {
            var result = await _service.GetAllLabResultsAsync(searchKeyword, createdDate, updatedDate);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<LabResultDto>(Request.Path, "Không tìm thấy kết quả xét nghiệm.", StatusCodes.Status404NotFound));
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        // GET: LabResults/Create
        [HttpPost("create")]
        public async Task<ActionResult<ApiResponse<LabResultDto>>> CreateLabResult([FromBody] LabResultDto labResult)
        {
            try
            {
                var create = await _service.CreateLabResultAsync(labResult);
                return StatusCode(StatusCodes.Status201Created,
                   ResponseFactory.Success(Request.Path, CreateLabResult, "Tạo kết quả thành công.", StatusCodes.Status201Created));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        ResponseFactory.Error<string>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        // POST: LabResults/Edit
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ApiResponse<LabResultDto>>> UpdateLabResult(int id, [Bind("LabResultId,ExecutionDate,ExecutionTime,ReceptionId,PatientId,TechnicianId,ConcludingDoctorId,Conclusion,Result,Description,Note,Instruction,Diagnosis,ResultTypeId,SampleReceivedTime,SampleTypeId,SampleQualityId,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsDeleted,SpouseName,SpouseYearOfBirth,SampleCollectionLocationMedicalFacilityId,IsSampleCollectedAtHome,SampleReceivedDate,SampleCollectionDate,SampleCollectionTime")] LabResult labResult)
        {
            if (id != labResult.LabResultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabResultExists(labResult.LabResultId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ConcludingDoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorId", labResult.ConcludingDoctorId);
            //ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", labResult.PatientId);
            //ViewData["ReceptionId"] = new SelectList(_context.Receptions, "ReceptionId", "ReceptionId", labResult.ReceptionId);
            //ViewData["TechnicianId"] = new SelectList(_context.Technicians, "TechnicianId", "TechnicianId", labResult.TechnicianId);
            return Ok(labResult);
        }

        // GET: LabResults/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<LabResultDto>>> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labResult = await _context.LabResults
                .Include(l => l.ConcludingDoctor)
                .Include(l => l.Patient)
                .Include(l => l.Reception)
                .Include(l => l.Technician)
                .FirstOrDefaultAsync(m => m.LabResultId == id);
            if (labResult == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: LabResults/Delete/5
        [HttpPost("delete"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ApiResponse<LabResultDto>>> DeleteConfirmed(int id)
        {
            var labResult = await _context.LabResults.FindAsync(id);
            if (labResult != null)
            {
                _context.LabResults.Remove(labResult);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabResultExists(int id)
        {
            return _context.LabResults.Any(e => e.LabResultId == id);
        }
    }
}
