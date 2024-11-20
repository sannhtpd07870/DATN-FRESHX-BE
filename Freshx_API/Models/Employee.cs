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

    public string? Address { get; set; } // Địa chỉ nhân viên

    public int? WardId { get; set; } // ID phường/xã

    public int? DistrictId { get; set; } // ID quận/huyện

    public int? ProvinceId { get; set; } // ID tỉnh/thành phố

    public int? DepartmentId { get; set; } // ID phòng ban

    public int? PositionId { get; set; } // ID vị trí

    public int? TitleId { get; set; } // ID chức danh

    public string? PhoneNumber { get; set; } // Số điện thoại nhân viên

    public string? ProfessionalCertificate { get; set; } // Chứng chỉ nghề nghiệp

    public DateOnly? IssuanceDate { get; set; } // Ngày cấp chứng chỉ

    public string? IssuancePlace { get; set; } // Nơi cấp chứng chỉ

    public virtual Department? Department { get; set; } // Phòng ban của nhân viên

  //  public virtual ICollection<DiagnosticImagingResult> DiagnosticImagingResults { get; set; } = new List<DiagnosticImagingResult>(); // Danh sách kết quả chẩn đoán hình ảnh

    public virtual AdministrativeUnit? District { get; set; } // Đơn vị hành chính quận/huyện

    //public virtual ICollection<Document> DocumentApprovers { get; set; } = new List<Document>(); // Danh sách tài liệu phê duyệt

    //public virtual ICollection<Document> DocumentChiefAccountants { get; set; } = new List<Document>(); // Danh sách tài liệu kế toán trưởng

    //public virtual ICollection<Document> DocumentDeliverers { get; set; } = new List<Document>(); // Danh sách tài liệu người giao

    //public virtual ICollection<Document> DocumentInputters { get; set; } = new List<Document>(); // Danh sách tài liệu người nhập

    //public virtual ICollection<Document> DocumentInspectors { get; set; } = new List<Document>(); // Danh sách tài liệu người kiểm tra

    //public virtual ICollection<Document> DocumentReceivers { get; set; } = new List<Document>(); // Danh sách tài liệu người nhận

    //public virtual ICollection<Document> DocumentTreasurers { get; set; } = new List<Document>(); // Danh sách tài liệu thủ quỹ

    //public virtual ICollection<EmailContent> EmailContents { get; set; } = new List<EmailContent>(); // Danh sách nội dung email

    //public virtual ICollection<MedicalServiceRequest> MedicalServiceRequestAssignedBies { get; set; } = new List<MedicalServiceRequest>(); // Danh sách yêu cầu dịch vụ y tế được giao

    //public virtual ICollection<MedicalServiceRequest> MedicalServiceRequestSampleCollectors { get; set; } = new List<MedicalServiceRequest>(); // Danh sách yêu cầu dịch vụ y tế thu mẫu

    public virtual AdministrativeUnit? Province { get; set; } // Đơn vị hành chính tỉnh/thành phố

    public virtual AdministrativeUnit? Ward { get; set; } // Đơn vị hành chính phường/xã
}
