using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class UserAction
{
    public int UserActionId { get; set; }

    public int? LoginSessionId { get; set; }

    public int? RequestObjectId { get; set; }

    public int? ServiceId { get; set; }

    public string? Action { get; set; }

    public int? Status { get; set; }

    public virtual LoginSession? LoginSession { get; set; }

    public virtual ServiceCatalog? Service { get; set; }
}
