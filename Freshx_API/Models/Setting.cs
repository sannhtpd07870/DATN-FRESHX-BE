using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class Setting
{
    public int SettingId { get; set; } // ID cài đặt

    public string? Code { get; set; } // Mã cài đặt

    public string? Name { get; set; } // Tên cài đặt

    public string? Content { get; set; } // Nội dung cài đặt

    public string? Description { get; set; } // Mô tả cài đặt

    public DateTime? Date1 { get; set; } // Ngày 1

    public DateTime? Date2 { get; set; } // Ngày 2

    public int? Number1 { get; set; } // Số 1

    public int? Number2 { get; set; } // Số 2

    public string? String1 { get; set; } // Chuỗi 1

    public string? String2 { get; set; } // Chuỗi 2

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? UpdatedBy { get; set; } // Người cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa
}
