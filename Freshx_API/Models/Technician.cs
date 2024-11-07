using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class Technician
{
    public int TechnicianId { get; set; } // ID kỹ thuật viên

    public string? Name { get; set; } // Tên kỹ thuật viên

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public virtual ICollection<DiagnosticImagingResult> DiagnosticImagingResults { get; set; } = new List<DiagnosticImagingResult>(); // Danh sách kết quả chẩn đoán hình ảnh

    public virtual ICollection<LabResult> LabResults { get; set; } = new List<LabResult>(); // Danh sách kết quả xét nghiệm
}
