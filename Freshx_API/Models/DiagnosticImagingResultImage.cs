using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class DiagnosticImagingResultImage
{
    public int DiagnosticImagingResultImageId { get; set; }

    public int? DiagnosticImagingResultId { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public int? IsDeleted { get; set; }

    public virtual DiagnosticImagingResult? DiagnosticImagingResult { get; set; }
}
