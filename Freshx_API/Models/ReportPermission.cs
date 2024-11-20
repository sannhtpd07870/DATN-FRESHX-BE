using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class ReportPermission
{
    public int ReportPermissionId { get; set; }

    public int? UserId { get; set; }

    public int? ReportId { get; set; }

    public virtual Report? Report { get; set; }

    public virtual User? User { get; set; }
}
