using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class EmailContentImage
{
    public int EmailContentImageId { get; set; }

    public int? EmailContentId { get; set; }

    public string? ImageName { get; set; }

    public string? ImageUrl { get; set; }

    public int? IsDeleted { get; set; }

    public virtual EmailContent? EmailContent { get; set; }
}
