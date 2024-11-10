using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class MedicalServiceRequest
{
    public int MedicalServiceRequestId { get; set; }

    public string? RequestNumber { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? RequestTime { get; set; }

    public int? ReceptionId { get; set; }

    public int? PatientId { get; set; }

    public int? ServiceId { get; set; }

    public int? Quantity { get; set; }

    public decimal? ServiceUnitPrice { get; set; }

    public decimal? ServiceTotalAmount { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsPaid { get; set; }

    public string? Status { get; set; }

    public int? AssignedById { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? IsDeleted { get; set; }

    public int? SampleCollectorId { get; set; }

    public DateTime? SampleCollectionDate { get; set; }

    public DateTime? SampleCollectionTime { get; set; }

    public string? NumberOfTubes { get; set; }

    public string? Sid { get; set; }

    public DateTime? ExecutionDate { get; set; }

    public DateTime? ExecutionTime { get; set; }

    public string? Result { get; set; }

    public int? ParentMedicalServiceRequestId { get; set; }

    public virtual Employee? AssignedBy { get; set; }

    public virtual ICollection<DiagnosticImagingResult> DiagnosticImagingResults { get; set; } = new List<DiagnosticImagingResult>();

    public virtual ICollection<MedicalServiceRequest> InverseParentMedicalServiceRequest { get; set; } = new List<MedicalServiceRequest>();

    public virtual MedicalServiceRequest? ParentMedicalServiceRequest { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual Reception? Reception { get; set; }

    public virtual Employee? SampleCollector { get; set; }

    public virtual ServiceCatalog? Service { get; set; }
}
