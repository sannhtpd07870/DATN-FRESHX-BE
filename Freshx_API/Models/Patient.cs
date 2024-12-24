using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Freshx_API.Models;

public partial class Patient
{
    [Key]
    public int PatientId { get; set; } // ID bệnh nhân

    public string? MedicalRecordNumber { get; set; } // Số hồ sơ bệnh án {tự sinh} vd: bn001}
    public string? IdentityCardNumber { get; set; } // Số CMND/CCCD ktra trùng lặp

    public string? AdmissionNumber { get; set; } // Số nhập viện {tự sinh vd: nv171224001 kết hợp giữa ngày nhập viện và số thứ tuwh trong ngày}

    public string? Name { get; set; } // Tên bệnh nhân

    public string? Gender { get; set; } // Giới tính bệnh nhân
    [Column(TypeName = "date")]
    public DateTime? DateOfBirth { get; set; } // Ngày sinh bệnh nhân

    public string? PhoneNumber { get; set; } // Số điện thoại bệnh nhân

    public string? Address { get; set; } // Địa chỉ chi tiết bệnh nhân

    public int? WardId { get; set; } // ID phường/xã

    public int? DistrictId { get; set; } // ID quận/huyện

    public int? ProvinceId { get; set; } // ID tỉnh/thành phố

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public int? ImageId  { get; set; } // Id đến ảnh bệnh nhân

    public string? Ethnicity { get; set; } // Dân tộc của bệnh nhân
    public virtual District? District { get; set; } // Đơn vị hành chính quận/huyện
    public virtual Province? Province { get; set; } // Đơn vị hành chính tỉnh/thành phố
    public virtual Ward? Ward { get; set; } // Đơn vị hành chính phường/xã
    public virtual Savefile? Image { get; set; }

}
