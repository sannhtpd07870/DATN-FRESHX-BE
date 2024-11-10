using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class MenuPermission
{
    public int MenuPermissionId { get; set; } // ID quyền truy cập menu

    public int? UserId { get; set; } // ID người dùng

    public int? MenuId { get; set; } // ID menu

    public virtual Menu? Menu { get; set; } // Menu liên quan

    public virtual User? User { get; set; } // Người dùng liên quan
}
