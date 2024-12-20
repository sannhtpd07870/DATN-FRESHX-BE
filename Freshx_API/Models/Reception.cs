using System;
using System.Collections.Generic;
using Freshx_API.Models;

namespace Freshx_API.Models;

public partial class Reception
{
    public int ReceptionId { get; set; }

    public string? ReceptionNumber { get; set; }

    public int? SequenceNumber { get; set; }

    public bool? IsPriority { get; set; }

    public int? PatientId { get; set; }

    public int? ReceptionLocationId { get; set; }

    public int? ReceptionistId { get; set; } // nhan vien le tan khoa ngoai

    public DateTime? ReceptionDate { get; set; }

   // public string? ContactAddress { get; set; }

    public string? Note { get; set; }

    public int? AssignedDoctorId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? IsDeleted { get; set; }

    public string? ReasonForVisit { get; set; }

    //public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Doctor? AssignedDoctor { get; set; } // bác sĩ khám

    //public virtual ICollection<DiagnosticImagingResult> DiagnosticImagingResults { get; set; } = new List<DiagnosticImagingResult>();

    //public virtual ICollection<ExaminationConfirmation> ExaminationConfirmations { get; set; } = new List<ExaminationConfirmation>();

    //public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    //public virtual ICollection<LabResult> LabResults { get; set; } = new List<LabResult>();

    //public virtual ICollection<LabTestFile> LabTestFiles { get; set; } = new List<LabTestFile>();

   // public virtual ICollection<MedicalServiceRequest> MedicalServiceRequests { get; set; } = new List<MedicalServiceRequest>();

    public virtual Patient? Patient { get; set; } // bệnh nhân khám
    public virtual Receptionist? Receptionist { get; set; } // nhân viên tiếp nhận
}
