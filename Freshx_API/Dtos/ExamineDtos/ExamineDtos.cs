namespace Freshx_API.Dtos.ExamineDtos
{
    public class ExamineRequestDto
    {
        public int? ReceptionId { get; set; }
        public string? RespiratoryRate { get; set; }
        public string? Bmi { get; set; }
        public string? Symptoms { get; set; }
        public int? ICDCatalogId { get; set; }
        public int? DiagnosisDictionaryId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Conclusion { get; set; }
        public string? MedicalAdvice { get; set; }
        public int? PrescriptionId { get; set; }
        public int? TemplatePrescriptionId { get; set; }
        public string? PrescriptionNumber { get; set; }
        public DateTime? FollowUpAppointment { get; set; }
        public string? ReasonForVisit { get; set; }
        public string? ExaminationNote { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string? BloodPressure { get; set; }
        public int? HeartRate { get; set; }
        public int? IsDeleted { get; set; }
    }

    public class ExamineResponseDto
    {
        public int ExamineId { get; set; }
        public int? ReceptionId { get; set; }
        public string? RespiratoryRate { get; set; }
        public string? Bmi { get; set; }
        public string? Symptoms { get; set; }
        public int? ICDCatalogId { get; set; }
        public int? DiagnosisDictionaryId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Conclusion { get; set; }
        public string? MedicalAdvice { get; set; }
        public int? PrescriptionId { get; set; }
        public int? TemplatePrescriptionId { get; set; }
        public string? PrescriptionNumber { get; set; }
        public DateTime? FollowUpAppointment { get; set; }
        public string? ReasonForVisit { get; set; }
        public string? ExaminationNote { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string? BloodPressure { get; set; }
        public int? HeartRate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedById { get; set; }
    }

}
