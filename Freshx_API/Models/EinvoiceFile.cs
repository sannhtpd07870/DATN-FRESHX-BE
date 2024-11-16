using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class EinvoiceFile
{
    public int EinvoiceFileId { get; set; }

    public int? PatientId { get; set; }

    public int? InvoiceId { get; set; }

    public string? FilePath { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Invoice? Invoice { get; set; }

    public virtual Patient? Patient { get; set; }
}
