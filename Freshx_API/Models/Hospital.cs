using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class Hospital
{
    public int HospitalId { get; set; } // ID bệnh viện

    public string? Code { get; set; } // Mã bệnh viện

    public string? Name { get; set; } // Tên bệnh viện

    public string? Address1 { get; set; } // Địa chỉ 1

    public string? Address2 { get; set; } // Địa chỉ 2

    public string? Address3 { get; set; } // Địa chỉ 3

    public string? PhoneNumber1 { get; set; } // Số điện thoại 1

    public string? PhoneNumber2 { get; set; } // Số điện thoại 2

    public string? PhoneNumber3 { get; set; } // Số điện thoại 3

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    //public virtual ICollection<User> Users { get; set; } = new List<User>(); // Danh sách người dùng liên quan
}
