using Freshx_API.Dtos;
using Freshx_API.Dtos.ExamineDtos;
using Freshx_API.Dtos.Patient;
using Freshx_API.Models;
namespace Freshx_API.Dtos
{
    public class CreateReceptionDto
    {
        public AddingPatientRequest AddingPatient { get; set; }
        public int? SequenceNumber { get; set; }
        public bool? IsPriority { get; set; }
        public int? PatientId { get; set; }
        public int? ReceptionLocationId { get; set; }
        public int? ReceptionistId { get; set; }
        public string? Note { get; set; }
        public int? AssignedDoctorId { get; set; }
        public List<int>? MedicalServiceRequestId { get; set; }
        public string? ReasonForVisit { get; set; }
        public List<CreateMedicalServiceRequestDto>? MedicalServiceRequest { get; set; } = new List<CreateMedicalServiceRequestDto>();
    }

    public class ReceptionDto
    {
        public int ReceptionId { get; set; }
        public int? SequenceNumber { get; set; }
        public bool? IsPriority { get; set; }
        public int? PatientId { get; set; }
        public int? ReceptionLocationId { get; set; }
        public int? ReceptionistId { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public string? Note { get; set; }
        public int? AssignedDoctorId { get; set; }
        public int? MedicalServiceRequestId { get; set; }
        public int? ServiceTotalAmount { get; set; }
        public string? ReasonForVisit { get; set; }
        public List<MedicalServiceRequestDto>? MedicalServiceRequest { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ExamineOnly Examine { get; set; }
        public LabResult LabResult { get; set; }
    }

    public class ListReceptionDto
    {
        public int ReceptionId { get; set; }
        public int? PatientId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; } // Tuổi bệnh nhân
        public string? Gender { get; set; } // Giới tính bệnh nhân
        public string? type { get; set; }
        public DateTime? time { get; set; }
        public string? ReasonForVisit { get; set; } //lý do khám
        public int? ExamineId { get; set; }
        public int? LabResultId { get; set; }
    }
}