namespace Freshx_API.Dtos.Invoice
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? VatinvoiceNumber { get; set; }
        public string? InvoiceType { get; set; }
        public int? ReceptionId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? RespiratoryRate { get; set; }
        public string? Bmi { get; set; }
        public string? Symptoms { get; set; }
        public int? ICDCatalogId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Conclusion { get; set; }
        public string? MedicalAdvice { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int? IsDeleted { get; set; }
        public string? PrescriptionNumber { get; set; }
        public DateTime? FollowUpAppointment { get; set; }
        public string? Comorbidities { get; set; }
        public string? ComorbidityCodes { get; set; }
        public string? ComorbidityNames { get; set; }
        public string? MedicalHistory { get; set; }
        public string? ExaminationDetails { get; set; }
        public string? LabSummary { get; set; }
        public string? TreatmentDetails { get; set; }
        public string? FollowUpAppointmentNote { get; set; }
        public string? ReasonForVisit { get; set; }
        public string? ExaminationNote { get; set; }
        public int MedicalExaminationId { get; set; }
        public bool IsPaid { get; set; }
    }

}
