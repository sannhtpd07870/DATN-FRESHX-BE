using AutoMapper;
using Freshx_API.Dtos.Patient;
using Freshx_API.Interfaces;
using Freshx_API.Models;

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
    }
}
