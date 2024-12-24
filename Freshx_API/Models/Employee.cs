using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class Employee
{
    public int EmployeeId { get; set; } // ID nhân viên

    public string? EmployeeCode { get; set; } // Mã nhân viên

    public string? FirstName { get; set; } // Tên nhân viên

    public string? LastName { get; set; } // Họ nhân viên

    public DateTime? DateOfBirth { get; set; } // Ngày sinh nhân viên

    public string? Gender { get; set; } // Giới tính nhân viên
    public int? AvataId { get; set; }
    public string? Address { get; set; } // Địa chỉ nhân viên
   

    public int? WardId { get; set; } // ID phường/xã

    public int? DistrictId { get; set; } // ID quận/huyện

    public int? ProvinceId { get; set; } // ID tỉnh/thành phố

    public int? DepartmentId { get; set; } // ID phòng ban

    public string? PhoneNumber { get; set; } // Số điện thoại nhân viên

    public string? ProfessionalCertificate { get; set; } // Chứng chỉ nghề nghiệp

    public DateOnly? IssuanceDate { get; set; } // Ngày cấp chứng chỉ

    public string? IssuancePlace { get; set; } // Nơi cấp chứng chỉ

    public virtual Department? Department { get; set; } // Phòng ban của nhân viên

  //  public virtual ICollection<DiagnosticImagingResult> DiagnosticImagingResults { get; set; } = new List<DiagnosticImagingResult>(); // Danh sách kết quả chẩn đoán hình ảnh

    public virtual District? District { get; set; } // Đơn vị hành chính quận/huyện

    public virtual Province? Province { get; set; } // Đơn vị hành chính tỉnh/thành phố

    public virtual Ward? Ward { get; set; } // Đơn vị hành chính phường/xã
    public virtual Savefile? Avata { get; set; }
}
