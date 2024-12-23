using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Freshx_API.Models;

public partial class Patient
{
    [Key]
    public int PatientId { get; set; } // ID bệnh nhân

    public string? MedicalRecordNumber { get; set; } // Số hồ sơ bệnh án

    public string? AdmissionNumber { get; set; } // Số nhập viện

    public string? Name { get; set; } // Tên bệnh nhân

    public string? Gender { get; set; } // Giới tính bệnh nhân
    [Column(TypeName = "date")]
    public DateTime? DateOfBirth { get; set; } // Ngày sinh bệnh nhân

    public string? PhoneNumber { get; set; } // Số điện thoại bệnh nhân

    public string? IdentityCardNumber { get; set; } // Số CMND/CCCD

    public string? Address { get; set; } // Địa chỉ bệnh nhân

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public string? ImageUrl { get; set; } // Đường dẫn đến ảnh bệnh nhân

    // public string? ZaloId { get; set; } // ID Zalo của bệnh nhân

    public string? Ethnicity { get; set; } // Dân tộc của bệnh nhân

}
