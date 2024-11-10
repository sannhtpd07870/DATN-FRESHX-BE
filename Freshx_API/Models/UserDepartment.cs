using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class UserDepartment
{
    public int UserDepartmentId { get; set; } // ID phòng ban người dùng

    public int? UserId { get; set; } // ID người dùng

    public int? DepartmentId { get; set; } // ID phòng ban

    public virtual Department? Department { get; set; } // Phòng ban của người dùng

    public virtual User? User { get; set; } // Người dùng
}
