namespace Freshx_API.Dtos
{
    public class ReceptionDto
    {
        public int ReceptionId { get; set; }
        public string? ReceptionNumber { get; set; }
        public bool? IsPriority { get; set; }
        public int? PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public string? ReasonForVisit { get; set; }
        public List<MedicalServiceRequestDTO> Services { get; set; }
    }

    public class CreateReceptionDto
    {
        public int? PatientId { get; set; }
        public CreatePatientDTO? NewPatient { get; set; } // Nếu là bệnh nhân mới
        public bool IsPriority { get; set; }
        public string? ReasonForVisit { get; set; }
        public List<CreateMedicalServiceRequestDTO> Services { get; set; }
    }

    public class UpdateReceptionDto
    {
        public int ReceptionId { get; set; }
        public string? ReceptionNumber { get; set; }
        public bool? IsPriority { get; set; }
        public int? PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public string? ReasonForVisit { get; set; }
        public List<MedicalServiceRequestDTO> Services { get; set; }
    }
}