using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models;

public partial class UserDepartment
{
    [Key]
    public int UserDepartmentId { get; set; } // ID phòng ban người dùng

    public int? UserId { get; set; } // ID người dùng

    public int? DepartmentId { get; set; } // ID phòng ban

    public virtual Department? Department { get; set; } // Phòng ban của người dùng

    public virtual User? User { get; set; } // Người dùng
}
