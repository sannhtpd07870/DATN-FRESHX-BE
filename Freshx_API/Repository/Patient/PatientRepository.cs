using AutoMapper;
using Azure.Core;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Patient;
using Freshx_API.Interfaces;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Models;
using Freshx_API.Services.CommonServices;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly FreshxDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientRepository> _logger;
        private readonly NumberGeneratorService _numberGenerator;
        private readonly ITokenRepository _tokenRepository;
        private readonly IFileService _fileService;
        public PatientRepository(FreshxDBContext context, IMapper mapper, ILogger<PatientRepository> logger, NumberGeneratorService generatorService, ITokenRepository tokenRepository, IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _numberGenerator = generatorService;
            _tokenRepository = tokenRepository;
            _fileService = fileService;
        }
        public async Task<Patient?> CreatePatientAsync(AddingPatientRequest addingPatientRequest)
        {
            try
            {
                int? avartarId;
                var listfiles = new List<IFormFile> { addingPatientRequest.AvatarFile };
                if (addingPatientRequest.AvatarFile == null)
                {
                    avartarId = null;
                }
                else
                {
                    var avartar = await _fileService.SaveFileAsync(_tokenRepository.GetUserIdFromToken(), "avarta", listfiles);
                    avartarId = avartar[0].Id;
                }
                var user = await _context.Users.FindAsync(addingPatientRequest.Email);
                string? accountId = null;
                if (user != null)
                {
                    accountId = user.Id;
                }
                // Generate numbers
                string medicalRecordNumber = await _numberGenerator.GenerateMedicalRecordNumber();
                string admissionNumber = await _numberGenerator.GenerateAdmissionNumber(DateTime.UtcNow);


                var patient = new Patient
                {
                    MedicalRecordNumber = medicalRecordNumber,
                    AdmissionNumber = admissionNumber,
                    Name = addingPatientRequest?.Name,
                    Gender = addingPatientRequest?.Gender,
                    DateOfBirth = addingPatientRequest?.DateOfBirth,
                    PhoneNumber = addingPatientRequest?.PhoneNumber,
                    IdentityCardNumber = addingPatientRequest?.IdentityCardNumber,
                    CreatedBy = _tokenRepository.GetUserIdFromToken(),
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = 0,
                    IsSuspended = 0,
                    Ethnicity = addingPatientRequest?.Ethnicity,
                    WardId = addingPatientRequest?.WardId,
                    DistrictId = addingPatientRequest?.DistrictId,
                    ProvinceId = addingPatientRequest?.ProvinceId,
                    AccountId = accountId,
                    ImageId = avartarId,
                    Email = addingPatientRequest?.Email,
                };
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await _context.Patients.AddAsync(patient);
                        await _context.SaveChangesAsync();
                        // Load related entities to generate address
                        await _context.Entry(patient)
                            .Reference(p => p.Ward)
                            .LoadAsync();
                        await _context.Entry(patient)
                            .Reference(p => p.District)
                            .LoadAsync();
                        await _context.Entry(patient)
                            .Reference(p => p.Province)
                            .LoadAsync();
                        patient.Address = patient.FormattedAddress;
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
                var patient = await _context.Patients.FindAsync(id);
                if (patient == null || patient.IsDeleted == 1)
                {
                    return null;
                }
                return patient;

            }
            catch (Exception e)
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
                if (patient == null)
                {
                    return null;
                }
                else
                {
                    int? avartarId;
                    if (patient.ImageId == null)
                    {
                        var listFiles = new List<IFormFile> { updatingPatientRequest.AvatarFile };
                        if (updatingPatientRequest.AvatarFile == null)
                        {
                            avartarId = null;
                        }
                        else
                        {
                            var avartar = await _fileService.SaveFileAsync(_tokenRepository.GetUserIdFromToken(), "avarta", listFiles);
                            avartarId = avartar[0].Id;
                        }
                        patient.ImageId = avartarId;
                    }
                    else if (updatingPatientRequest.AvatarFile != null)
                    {
                        await _fileService.UpdateFileAsync(patient.ImageId, updatingPatientRequest.AvatarFile);
                    }
                    patient.Name = updatingPatientRequest.Name;
                    patient.Gender = updatingPatientRequest.Gender;
                    patient.PhoneNumber = updatingPatientRequest.PhoneNumber;
                    patient.IdentityCardNumber = updatingPatientRequest.IdentityCardNumber;
                    patient.UpdatedBy = _tokenRepository.GetUserIdFromToken();
                    patient.UpdatedDate = DateTime.UtcNow;
                    patient.Ethnicity = updatingPatientRequest.Ethnicity;
                    patient.WardId = updatingPatientRequest?.WardId;
                    patient.DistrictId = updatingPatientRequest?.DistrictId;
                    patient.ProvinceId = updatingPatientRequest?.ProvinceId;
                    patient.Email = updatingPatientRequest?.Email;
                    patient.DateOfBirth = updatingPatientRequest?.DateOfBirth;


                    // Update address after loading relations
                    await _context.Entry(patient)
                        .Reference(p => p.Ward)
                        .LoadAsync();
                    await _context.Entry(patient)
                        .Reference(p => p.District)
                        .LoadAsync();
                    await _context.Entry(patient)
                        .Reference(p => p.Province)
                        .LoadAsync();

                    patient.Address = patient.FormattedAddress;

                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
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
                if (patient != null)
                {
                    patient.IsDeleted = 1;
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return patient;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured while deleting product by id: {id}");
                throw;
            }
        }

        public async Task<PatientHistoryDto> GetPatientHistory(int id, string? keyword = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                // Kiểm tra bệnh nhân
                var patient = await _context.Patients
                    .Where(p => p.IsDeleted == 0 && p.PatientId == id)
                    .FirstOrDefaultAsync();

                if (patient == null)
                {
                    throw new Exception("Không tìm thấy bệnh nhân.");
                }

                // Lấy danh sách tiếp nhận của bệnh nhân
                var receptionsQuery = _context.Receptions
                    .Where(r => r.PatientId == id && r.IsDeleted == 0)
                    .Include(r => r.Examine)
                    .ThenInclude(e => e.Prescription)
                    .ThenInclude(p => p.PrescriptionDetails)
                    .Include(r => r.LabResult)
                    .AsQueryable();

                // Tìm kiếm theo từ khóa (triệu chứng, chẩn đoán)
                if (!string.IsNullOrEmpty(keyword))
                {
                    receptionsQuery = receptionsQuery.Where(r =>
                        r.Examine.Symptoms.Contains(keyword) ||
                        r.Examine.Diagnosis.Contains(keyword) ||
                        r.Examine.Conclusion.Contains(keyword));
                }

                // Lọc theo ngày
                if (startDate.HasValue)
                {
                    receptionsQuery = receptionsQuery.Where(r => r.Examine.UpdatedDate >= startDate.Value);
                }
                if (endDate.HasValue)
                {
                    receptionsQuery = receptionsQuery.Where(r => r.Examine.UpdatedDate <= endDate.Value);
                }

                var receptions = await receptionsQuery.ToListAsync();

                // Tính toán số lần khám trong năm
                var currentYear = DateTime.Now.Year;
                var visitsThisYear = receptions.Count(r => r.Examine.UpdatedDate.HasValue && r.Examine.UpdatedDate.Value.Year == currentYear);

                // Chuẩn bị dữ liệu trả về
                var result = new PatientHistoryDto
                {
                    PatientId = id,
                    TotalVisits = receptions.Count,
                    VisitsThisYear = new VisitsPerYear
                    {
                        Year = currentYear.ToString(),
                        VisitCount = visitsThisYear
                    },
                    PatientMedicalHistory = (await Task.WhenAll(receptions.Select(async r => new PatienMedicalHistoryDto
                    {
                        ReceptionId = r.ReceptionId,
                        Examine = r.Examine == null ? null : new ExamineMedicalHistory
                        {
                            ExamineId = r.Examine.ExamineId,
                            Symptoms = r.Examine.Symptoms,
                            TreatmentDetails = r.Examine.TreatmentDetails,
                            Temperature = r.Examine.Temperature,
                            BloodPressureSystolic = r.Examine.BloodPressureSystolic,
                            BloodPressureDiastolic = r.Examine.BloodPressureDiastolic,
                            HeartRate = r.Examine.HeartRate,
                            Diagnosis = r.Examine.Diagnosis,
                            Conclusion = r.Examine.Conclusion,
                            MedicalAdvice = r.Examine.MedicalAdvice,
                            Date = r.Examine.UpdatedDate,
                            DoctorName = "",
                            //Department = r.Examine.Department,
                            PrescriptionExamine = r.Examine.Prescription == null ? null : new PrescriptionExamineHistory
                            {
                                PrescriptionId = r.Examine.Prescription.PrescriptionId,
                                Details = r.Examine.Prescription.PrescriptionDetails.ToList(),
                            }
                        },
                        LapResult = r.LabResult == null ? null : new LapResultMedicalHistory
                        {
                            LabResultId = r.LabResult.LabResultId,
                            Conclusion = r.LabResult.Conclusion,
                            Description = r.LabResult.Description,
                            Note = r.LabResult.Note
                        }
                    }))).ToList()
                };

                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Lỗi khi lấy lịch sử bệnh nhân.");
               throw;
            }
        }
    
    public async Task<List<Patient?>> GetPatientsAsync(Parameters parameters)
        {
            var query = _context.Patients.Where(p => p.IsDeleted == 0).AsQueryable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                query = query.Where(u =>
                    (u.Name != null && u.Name.Contains(parameters.SearchTerm)) ||
                    (u.Address != null && u.Address.Contains(parameters.SearchTerm)));
            }

            // Apply sorting
            // Sort by created date
            query = parameters.SortOrderAsc ?? true
               ? query.OrderBy(p => p.CreatedDate)
               : query.OrderByDescending(p => p.CreatedDate);
            return await query.ToListAsync();
        }

    }
}
