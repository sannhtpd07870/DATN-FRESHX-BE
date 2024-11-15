using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class Dictionary
{
    public int DictionaryId { get; set; } // ID từ điển

    public string? Code { get; set; } // Mã từ điển

    public int? NameId { get; set; } // ID tên từ điển

    public string? Name { get; set; } // Tên từ điển

    public string? Description1 { get; set; } // Mô tả 1

    public string? Description2 { get; set; } // Mô tả 2

    public string? Description3 { get; set; } // Mô tả 3

    public string? Description4 { get; set; } // Mô tả 4

    public string? Description5 { get; set; } // Mô tả 5

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? UpdatedBy { get; set; } // Người cập nhật
}
