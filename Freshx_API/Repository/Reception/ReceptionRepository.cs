using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Interfaces;
using Freshx_API.Interfaces.IReception;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Freshx_API.Repository
{
    public class ReceptionRepository : IReceptionRepository
    {
        private readonly FreshxDBContext _context;
        private readonly IDoctorRepository _doctorrepository;

        public ReceptionRepository(FreshxDBContext context, IDoctorRepository doctorrepository)
        {
            _context = context;
            _doctorrepository = doctorrepository;
        }

        public async Task<Reception?> GetByIdAsync(int id)
        {
            return await _context.Receptions
                .Include(r => r.MedicalServiceRequest)
                .Include(r => r.AssignedDoctor)
                .Include(r => r.Patient)
                .Include(r => r.Receptionist)
                .FirstOrDefaultAsync(r => r.ReceptionId == id);
           
        }

        public async Task<IEnumerable<Reception>> GetAllAsync()
        {
            return await _context.Receptions
                .Include(r => r.MedicalServiceRequest) // Bao gồm các yêu cầu dịch vụ y tế
                .ToListAsync();
        }

        public async Task<List<ExamineHistoryDto>> GetListExamine(string? searchKey, bool isHistory)
        {
            var today = DateTime.Today;
            var query = _context.Receptions
                .Include(r => r.Patient)
                .Include(r => r.Examine)
                .Where(r => r.Examine != null && r.Examine.IsDeleted == 0 && r.IsDeleted == 0);

            // Lọc lịch sử hoặc hôm nay
            if (!isHistory)
            {
                query = query.Where(r => r.Examine != null && r.Examine.IsPaid == false
                                        && r.Examine.CreatedDate.HasValue
                                        && r.Examine.CreatedDate.Value.Date == today);
            }

            // Tìm kiếm theo tên hoặc lý do khám
            if (!string.IsNullOrEmpty(searchKey))
            {
                query = query.Where(r => (r.Patient.Name != null && r.Patient.Name.Contains(searchKey))
                                        || (r.ReasonForVisit != null && r.ReasonForVisit.Contains(searchKey)));
            }

            // Lọc theo ưu tiên
            var receptions = await query
                .OrderByDescending(r => r.IsPriority)
                .ThenByDescending(r => r.Examine != null ? r.Examine.UpdatedDate : (DateTime?)null)
                .ToListAsync();

            // Ánh xạ dữ liệu sang ExamineHistoryDto
            var result = new List<ExamineHistoryDto>();

            foreach (var r in receptions)
            {
                var patient = r.Patient;
                if (patient == null) continue;

                // Lấy lịch sử bệnh nhân
                var history = await GetMedicalHistory(patient.PatientId);

                result.Add(new ExamineHistoryDto
                {
                    ReceptionId = r.ReceptionId,
                    ExamineId = r.Examine?.ExamineId,
                    PatientId = patient.PatientId,
                    PatientName = patient.Name ?? "Không rõ",
                    MedicalRecordNumber = patient.MedicalRecordNumber ?? "Không rõ",
                    Age = CalculateAge(patient.DateOfBirth),
                    Gender = patient.Gender ?? "Không rõ",
                    AdmissionDate = r.ReceptionDate?.ToString("dd/MM/yyyy HH:mm") ?? "Không rõ",
                    MedicalHistory = history,
                    LastExamine = history.FirstOrDefault()
                });
            }

            return result;
        }

        public async Task<List<ListReceptionDto>> GetListLabResult(string? searchKey, bool isHistory)
        {
            var receptions = await  _context.Receptions
                .Include(r => r.Patient) // Bao gồm thông tin bệnh nhân
                .Include(r => r.LabResult) // Bao gồm thông tin xét nghiệm
                .Where(r => r.LabResult != null && r.LabResult.IsDeleted == 0).ToListAsync(); // Điều kiện lọc LabResult
                

            if (receptions == null)
            {
                return null;
            } 

            var result = receptions.Select(r => new ListReceptionDto
            {
                ReceptionId = r.ReceptionId,
                PatientId = r.PatientId,
                Age = CalculateAge(r.Patient.DateOfBirth),
                Gender = r.Patient?.Gender,
                type = "LabResult", // Loại là xét nghiệm
                time = r.LabResult?.UpdatedDate,
                ReasonForVisit = r.ReasonForVisit,
                ExamineId = null, // Không có Examine trong hàm này
                LabResultId = r.LabResult?.LabResultId
            }).ToList();

            return result;
        }

        public async Task<ExamineHistoryDto> GetPatientHistory(int receptionId)
        {
            var reception = await _context.Receptions
                .Include(r => r.Patient)
                .Include(r => r.Examine)
                    //.ThenInclude(e => e.AssignedDoctor)
                .Where(r => r.ReceptionId == receptionId && r.IsDeleted == 0)
                .FirstOrDefaultAsync();

            if (reception == null) return null;

            var patient = reception.Patient;
            var examine = reception.Examine;

            if (patient == null) return null;
            var history = await GetMedicalHistory(patient.PatientId);
            var patientHistory = new ExamineHistoryDto
            {
                ReceptionId = reception.ReceptionId,
                ExamineId = examine?.ExamineId,
                PatientId = patient.PatientId,
                PatientName = patient.Name ?? "Không rõ",
                MedicalRecordNumber = patient.MedicalRecordNumber ?? "Không rõ",
                Age = CalculateAge(patient.DateOfBirth),
                Gender = patient.Gender ?? "Không rõ",
                AdmissionDate = reception.ReceptionDate?.ToString("dd/MM/yyyy HH:mm") ?? "Không rõ",
                MedicalHistory = history ,
                LastExamine = history[0]
                //DoctorName = examine?.AssignedDoctor?.Name ?? "Không rõ"
            };

            return patientHistory;
        }

        private int CalculateAge(DateTime? dateOfBirth)
        {
            if (!dateOfBirth.HasValue)
                return 0;

            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Value.Year;

            if (dateOfBirth.Value.Date > today.AddYears(-age)) age--;

            return age;
        }

        private async Task<List<MedicalHistory>> GetMedicalHistory(int patientId)
        {
            // Lấy thông tin từ bảng Reception, Examine, và LabResult với các điều kiện
            var receptionData = _context.Receptions
                .Include(r => r.Examine) // Lấy Examine
                .Include(r => r.LabResult) // Lấy LabResult
                 .Where(r => r.PatientId == patientId) // Lọc theo bệnh nhân
                .ToList();

            var medicalHistory = new List<MedicalHistory>();

            foreach (var reception in receptionData)
            {
                // Lọc Examine nếu tồn tại, kiểm tra điều kiện IsPaid == true và IsDeleted == 0
                if (reception.Examine != null && reception.Examine.IsPaid == true && reception.Examine.IsDeleted == 0)
                {
                    var doctor = "";
                    if(reception.Examine.UpdatedBy != null)
                    {
                        var getdoctor = await _doctorrepository.GetByIdAsync(reception.Examine.UpdatedBy ?? 1);
                        doctor = getdoctor?.Name ?? "Không rõ";
                    }
                    medicalHistory.Add(new MedicalHistory
                    {
                        Diagnosis = reception.Examine.Diagnosis,
                        Conclusion = reception.Examine.Conclusion,
                        Date = reception.Examine.UpdatedDate, // Lấy ngày cập nhật của Examine
                        Doctorexamine = doctor
                    });
                }

                // Lọc LabResult nếu tồn tại, kiểm tra điều kiện IsPaid == true và IsDeleted == 0
                if (reception.LabResult != null && reception.LabResult.IsPaid == true && reception.LabResult.IsDeleted == 0)
                {
                    var doctor = "";
                    if (reception.Examine.UpdatedBy != null)
                    {
                        var getdoctor = await _doctorrepository.GetByIdAsync(reception.Examine.UpdatedBy ?? 1);
                        doctor = getdoctor?.Name ?? "Không rõ";
                    }
                    medicalHistory.Add(new MedicalHistory
                    {
                        Diagnosis = reception.LabResult.Description ?? "Không rõ",
                        Conclusion = reception.LabResult.Conclusion ?? "không rõ",
                        Date = reception.LabResult.UpdatedDate ?? DateTime.Now, // Lấy ngày cập nhật của LabResult
                        Doctorexamine = doctor ?? "không rõ"
                    });
                }
            }

            return medicalHistory.OrderByDescending(m => m.Date).ToList(); 
        }

        public async Task<Reception?> AddAsync(Reception Addreception)
        {
            _context.Receptions.Add(Addreception);
            await _context.SaveChangesAsync();
            return Addreception;
        }

        public async Task UpdateAsync(Reception reception)
        {
            _context.Receptions.Update(reception);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reception = await _context.Receptions.FindAsync(id);
            if (reception != null)
            {
                _context.Receptions.Remove(reception);
                await _context.SaveChangesAsync();
            }
        }
    }

}