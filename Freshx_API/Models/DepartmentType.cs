using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class DepartmentType
{
    public int DepartmentTypeId { get; set; } // ID loại phòng ban

    public string? Code { get; set; } // Mã loại phòng ban

    public string? Name { get; set; } // Tên loại phòng ban

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>(); // Danh sách phòng ban liên quan
}
