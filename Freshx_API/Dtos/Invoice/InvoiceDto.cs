using System;

namespace Freshx_API.DTOs
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
        public string? RespiratoryRate { get; set; }
        public string? Bmi { get; set; }
        public string? Symptoms { get; set; }
        public int? ICDCatalogId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Conclusion { get; set; }
        public string? MedicalAdvice { get; set; }
        public string? PrescriptionNumber { get; set; }
        public DateTime? FollowUpAppointment { get; set; }
        public string? Comorbidities { get; set; }
        public string? MedicalHistory { get; set; }
        public string? ExaminationDetails { get; set; }
        public string? LabSummary { get; set; }
        public string? TreatmentDetails { get; set; }
        public bool IsPaid { get; set; }

        // Navigation property DTOs
  
        public ICDCatalogDto? ICDCatalog { get; set; }
    }

    public class CreateInvoiceDto
    {
        public string? InvoiceNumber { get; set; }
        public string? VatinvoiceNumber { get; set; }
        public string? InvoiceType { get; set; }
        public int? ReceptionId { get; set; }
        public int? PatientId { get; set; }
        public string? RespiratoryRate { get; set; }
        public string? Bmi { get; set; }
        public string? Symptoms { get; set; }
        public int? ICDCatalogId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Conclusion { get; set; }
        public string? MedicalAdvice { get; set; }
        public string? PrescriptionNumber { get; set; }
        public DateTime? FollowUpAppointment { get; set; }
        public string? Comorbidities { get; set; }
        public string? MedicalHistory { get; set; }
        public string? ExaminationDetails { get; set; }
        public string? LabSummary { get; set; }
        public string? TreatmentDetails { get; set; }
        public int? CreatedBy { get; set; }
    }

    public class UpdateInvoiceDto
    {
        public string? InvoiceNumber { get; set; }
        public string? VatinvoiceNumber { get; set; }
        public string? InvoiceType { get; set; }
        public int? ReceptionId { get; set; }
        public int? PatientId { get; set; }
        public string? RespiratoryRate { get; set; }
        public string? Bmi { get; set; }
        public string? Symptoms { get; set; }
        public int? ICDCatalogId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Conclusion { get; set; }
        public string? MedicalAdvice { get; set; }
        public string? PrescriptionNumber { get; set; }
        public DateTime? FollowUpAppointment { get; set; }
        public string? Comorbidities { get; set; }
        public string? MedicalHistory { get; set; }
        public string? ExaminationDetails { get; set; }
        public string? LabSummary { get; set; }
        public string? TreatmentDetails { get; set; }
        public int? UpdatedBy { get; set; }
    }


    public class ICDCatalogDto
    {
        public int ICDCatalogId { get; set; }
        public string? ICDCode { get; set; }
        public string? ICDName { get; set; }
    }
}