using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models;

public partial class Department
{
    [Key]
    public int DepartmentId { get; set; } // ID phòng ban

    public string? Code { get; set; } // Mã phòng ban

    public string? Name { get; set; } // Tên phòng ban

    public int? DepartmentTypeId { get; set; } // ID loại phòng ban

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public string? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public string? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public virtual DepartmentType? DepartmentType { get; set; } // Loại phòng ban

    //public virtual ICollection<Document> Documents { get; set; } = new List<Document>(); // Danh sách tài liệu liên quan

    //public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>(); // Danh sách nhân viên liên quan

    //public virtual ICollection<LoginSession> LoginSessions { get; set; } = new List<LoginSession>(); // Danh sách phiên đăng nhập của phòng ban

    //public virtual ICollection<Pharmacy> Pharmacies { get; set; } = new List<Pharmacy>(); // Danh sách nhà thuốc liên quan

    //public virtual ICollection<UserDepartment> UserDepartments { get; set; } = new List<UserDepartment>(); // Danh sách phòng ban người dùng
}
