using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class DoctorsCommonIcd
{
    public int DoctorsCommonIcdid { get; set; }

    public int DoctorId { get; set; }

    public int IcdcatalogId { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Icdcatalog Icdcatalog { get; set; } = null!;
}
