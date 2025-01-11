using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Dtos.Patient
{
    public class PatientVisitDto
    {
        public int ReceptionId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<MedicalHistoryDto> History { get; set; }
        public LastVisitDto LastVisit { get; set; }
    }

    public class MedicalHistoryDto
    {
        public int Year { get; set; }
        public string Description { get; set; }
    }

    public class LastVisitDto
    {
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public string Doctor { get; set; }
    }


    public class PatientHistoryDto
    {
        public int PatientId { get; set; } // ID bệnh nhân
        public int? TotalVisits { get; set; } // tổng số lần khám
        public VisitsPerYear? VisitsThisYear { get; set; } // số lần khám trong năm nay
        public List<PatienMedicalHistoryDto>? PatientMedicalHistory { get; set; }                                             
    }
    public class VisitsPerYear
    {
        public string? Year { get; set; }
        public int? VisitCount { get; set; }
    }
    public class PatienMedicalHistoryDto
    {
        public int? ReceptionId { get; set; }
        public ExamineMedicalHistory? Examine { get; set; }
        public LapResultMedicalHistory? LapResult { get; set; }
        
    }
 
    public class ExamineMedicalHistory
    {
        public int ExamineId { get; set; }
        public string? Symptoms { get; set; } // Triệu chứng
        public string? TreatmentDetails { get; set; } // Chi tiết điều trị
        public double? Temperature { get; set; } // Nhiệt độ cơ thể
        public double? BloodPressureSystolic { get; set; } // Huyết áp tâm thu
        public double? BloodPressureDiastolic { get; set; } // Huyết áp tâm trương
        public double? HeartRate { get; set; } // Nhịp tim (lần/phút)
        public string? Diagnosis { get; set; } // Chẩn đoán
        public string? Conclusion { get; set; } // Kết luận
        public string? MedicalAdvice { get; set; } // Lời khuyên y tế
        public DateTime? Date { get; set; } // ngày khám
        public string? DoctorName { get; set; } // bác sĩ khám
        public string? Department { get; set; } // phòng ban
        public PrescriptionExamineHistory? PrescriptionExamine { get; set; }
    }
    public class PrescriptionExamineHistory
    {
        public int PrescriptionId { get; set; } // ID đơn thuốc
        public List<Freshx_API.Models.PrescriptionDetail> Details { get; set; }
    }

  
    public class LapResultMedicalHistory 
    {
        public int LabResultId { get; set; } // ID kết quả xét nghiệm
        public string? Conclusion { get; set; } // Kết luận
        public string? Description { get; set; } // Mô tả
        public string? Note { get; set; } // Ghi chú
    }
}
