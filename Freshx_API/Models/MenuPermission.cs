using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models;

public partial class MenuPermission
{
    [Key]
    public int MenuPermissionId { get; set; } // ID quyền truy cập menu

    public int? UserId { get; set; } // ID người dùng

    public int? MenuId { get; set; } // ID menu

    public virtual Menu? Menu { get; set; } // Menu liên quan
}
