namespace Freshx_API.Dtos.Reception
{
    public class AddingReceptionRequest
    {
        public string? ReceptionNumber { get; set; }

        public int? SequenceNumber { get; set; }

        public bool? IsPriority { get; set; }

        public int? PatientId { get; set; }

        public int? ReceptionLocationId { get; set; }

        public int? ReceptionistId { get; set; } // nhan vien le tan khoa ngoai

        public DateTime? ReceptionDate { get; set; }

        public string? Note { get; set; }

        public int? AssignedDoctorId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? IsDeleted { get; set; }

        public string? ReasonForVisit { get; set; }
    }
}
