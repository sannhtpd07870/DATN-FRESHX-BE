using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class User
{
    public int UserId { get; set; } // ID người dùng

    public string? UserCode { get; set; } // Mã người dùng

    public string? UserName { get; set; } // Tên người dùng

    public string? Password { get; set; } // Mật khẩu người dùng

    public int? HospitalId { get; set; } // ID bệnh viện

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public virtual Hospital? Hospital { get; set; } // Bệnh viện của người dùng

    public virtual ICollection<LoginSession> LoginSessions { get; set; } = new List<LoginSession>(); // Danh sách phiên đăng nhập

    public virtual ICollection<MenuPermission> MenuPermissions { get; set; } = new List<MenuPermission>(); // Danh sách quyền truy cập menu

    public virtual ICollection<ReportPermission> ReportPermissions { get; set; } = new List<ReportPermission>(); // Danh sách quyền truy cập báo cáo

    public virtual ICollection<UserActionByMedicalRecord> UserActionByMedicalRecords { get; set; } = new List<UserActionByMedicalRecord>(); // Danh sách hành động của người dùng theo hồ sơ bệnh án

    public virtual ICollection<UserDepartment> UserDepartments { get; set; } = new List<UserDepartment>(); // Danh sách phòng ban của người dùng

    public virtual ICollection<UserPharmacy> UserPharmacies { get; set; } = new List<UserPharmacy>(); // Danh sách nhà thuốc của người dùng
}
