using AutoMapper;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Patient;
using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly FreshxDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientRepository> _logger;
        public PatientRepository(FreshxDBContext context, IMapper mapper, ILogger<PatientRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Patient?> CreatePatientAsync(AddingPatientRequest addingPatientRequest)
        {
            try
            {
                var patient = new Patient()
                {
                    MedicalRecordNumber = addingPatientRequest?.MedicalRecordNumber,
                    AdmissionNumber = addingPatientRequest?.AdmissionNumber,
                    Name = addingPatientRequest?.Name,
                    Gender = addingPatientRequest?.Gender,
                    DateOfBirth = addingPatientRequest?.DateOfBirth,
                    PhoneNumber = addingPatientRequest?.PhoneNumber,
                    IdentityCardNumber = addingPatientRequest?.IdentityCardNumber,
                    Address = addingPatientRequest?.Address,
                    CreatedBy = addingPatientRequest?.CreatedBy,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = 0,
                    ImageUrl = addingPatientRequest?.ImageUrl,
                    Ethnicity = addingPatientRequest?.Ethnicity
                };
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await _context.Patients.AddAsync(patient);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return patient;
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exception occured while getting products");
                throw;

            }
        }
        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            try
            {
                return await _context.Patients.FindAsync(id);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "An exception occured while getting products");
                throw;
            }
        }
        public async Task<Patient?> UpdatePatientByIdAsync(int id, UpdatingPatientRequest updatingPatientRequest)
        {
            try
            {
                var patient = await _context.Patients.FindAsync(id);
                if(patient != null)
                {
                    patient.MedicalRecordNumber = updatingPatientRequest.MedicalRecordNumber;
                    patient.AdmissionNumber = updatingPatientRequest.AdmissionNumber;
                    patient.Name = updatingPatientRequest.Name;
                    patient.Gender = updatingPatientRequest.Gender;
                    patient.PhoneNumber = updatingPatientRequest.PhoneNumber;
                    patient.IdentityCardNumber = updatingPatientRequest.IdentityCardNumber;
                    patient.Address = updatingPatientRequest.Address;
                    patient.CreatedBy = updatingPatientRequest.CreatedBy;
                    patient.CreatedDate = patient.CreatedDate;
                    patient.UpdatedDate = DateTime.UtcNow;
                    patient.UpdatedBy = updatingPatientRequest.UpdatedBy;
                    patient.IsDeleted = updatingPatientRequest.IsDeleted;
                    patient.ImageUrl = updatingPatientRequest.ImageUrl;
                    patient.Ethnicity = updatingPatientRequest.Ethnicity;
                    var result = await _context.SaveChangesAsync();
                    if(result>0)
                    {
                        return patient;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured while updating patient by id: {id}");
                throw;
            }
        }
        public async Task<Patient?> DeletePatientByIdAsync(int id)
        {
            try
            {
                var patient = await _context.Patients.FindAsync(id); 
                if(patient != null)
                {
                    _context.Patients.Remove(patient);
                    var result = await _context.SaveChangesAsync();
                    if(result > 0)
                    {
                        return patient;
                    }
                }
                return null;
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"An exception occured while deleting product by id: {id}");
                throw;
            }
        }
        public async Task<CustomPageResponse<IEnumerable<Patient?>>> GetPatientsAsync(PaginationParameters parameters)
        {
            var query = _context.Patients.AsQueryable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                query = query.Where(u =>
                    (u.Name != null && u.Name.Contains(parameters.SearchTerm)) ||
                    (u.Address != null && u.Address.Contains(parameters.SearchTerm)));
            }

            // Apply sorting
            if (parameters.SortOrderAsc ?? true)
            {
                query = query.OrderBy(u => u.Name ?? string.Empty);
            }
            else
            {
                query = query.OrderByDescending(u => u.Name ?? string.Empty);
            }

            // Get total count before pagination
            var totalRecords = await query.CountAsync();

            // Apply pagination
            var items = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return new CustomPageResponse<IEnumerable<Patient?>>(
                items,
                parameters.PageNumber,
                parameters.PageSize,
                totalRecords);
        }
    }
}
