using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models;

public partial class UserActionByMedicalRecord
{
    [Key]
    public int UserActionByMedicalRecordId { get; set; }

    public int? LoginSessionId { get; set; }

    public string? MedicalRecordNumber { get; set; }

    public string? AdmissionNumber { get; set; }

    public int? UserId { get; set; }

    public string? Action { get; set; }

    public int? Status { get; set; }

    public DateTime? ActionTime { get; set; }

    public virtual LoginSession? LoginSession { get; set; }

    public virtual User? User { get; set; }
}
