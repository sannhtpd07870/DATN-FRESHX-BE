using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class EmailAccount
{
    public int EmailAccountId { get; set; } // ID tài khoản email

    public string? EmailAddress { get; set; } // Địa chỉ email

    public string? Password { get; set; } // Mật khẩu tài khoản email

    public string? Description { get; set; } // Mô tả tài khoản email

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? UpdatedBy { get; set; } // Người cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa
}
