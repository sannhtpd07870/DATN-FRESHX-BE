using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class Doctor
{
    public int DoctorId { get; set; } // ID bác sĩ

    public string? Name { get; set; } // Tên bác sĩ

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public virtual ICollection<DiagnosticImagingResult> DiagnosticImagingResults { get; set; } = new List<DiagnosticImagingResult>(); // Danh sách kết quả chẩn đoán hình ảnh

    public virtual ICollection<DoctorsCommonIcd> DoctorsCommonIcds { get; set; } = new List<DoctorsCommonIcd>(); // Danh sách ICD phổ biến của bác sĩ

    public virtual ICollection<Document> DocumentDoctors { get; set; } = new List<Document>(); // Danh sách tài liệu của bác sĩ

    public virtual ICollection<Document> DocumentReferralDoctors { get; set; } = new List<Document>(); // Danh sách tài liệu của bác sĩ giới thiệu

    public virtual ICollection<LabResult> LabResults { get; set; } = new List<LabResult>(); // Danh sách kết quả xét nghiệm

    public virtual ICollection<Reception> Receptions { get; set; } = new List<Reception>(); // Danh sách tiếp nhận
}
