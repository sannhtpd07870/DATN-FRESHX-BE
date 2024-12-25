namespace Freshx_API.Dtos
{
    public class CreateReceptionDto
    {
        public int? SequenceNumber { get; set; }
        public bool? IsPriority { get; set; }
        public int? PatientId { get; set; }
        public string? PatientName { get; set; } // Tên bệnh nhân
        public int? ReceptionLocationId { get; set; }
        public int? ReceptionistId { get; set; }
        public string? ReceptionistName { get; set; } // Tên nhân viên lễ tân
        public DateTime? ReceptionDate { get; set; }
        public string? Note { get; set; }
        public int? AssignedDoctorId { get; set; }
        public string? AssignedDoctorName { get; set; } // Tên bác sĩ chỉ định
        public int? MedicalServiceRequestId { get; set; }
        public int? ServiceTotalAmount { get; set; }
        public string? ReasonForVisit { get; set; }
        public List<MedicalServiceRequestDto>? MedicalServiceRequests { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

}
