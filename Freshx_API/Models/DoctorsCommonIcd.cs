using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models;

public partial class DoctorsCommonIcd
{
    [Key]
    public int DoctorsCommonIcdid { get; set; }

    public int DoctorId { get; set; }

    public int  ICDCatalogId { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual  ICDCatalog  ICDCatalog { get; set; } = null!;
}
