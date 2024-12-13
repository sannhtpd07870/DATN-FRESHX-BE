using System;
using System.Collections.Generic;
using Freshx_API.Models;

namespace Freshx_API.Models;

public partial class LabTestFile
{
    public int LabTestFileId { get; set; }

    public int? ReceptionId { get; set; }

    public int? PatientId { get; set; }

    public string? FilePath { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual Reception? Reception { get; set; }
}
