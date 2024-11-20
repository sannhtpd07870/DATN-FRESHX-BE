using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models;

public partial class Patient
{
    [Key]
    public int PatientId { get; set; } // ID bệnh nhân

    public string? MedicalRecordNumber { get; set; } // Số hồ sơ bệnh án

    public string? AdmissionNumber { get; set; } // Số nhập viện

    public string? Name { get; set; } // Tên bệnh nhân

    public string? Gender { get; set; } // Giới tính bệnh nhân

    public DateTime? DateOfBirth { get; set; } // Ngày sinh bệnh nhân

    public int? YearOfBirth { get; set; } // Năm sinh bệnh nhân

    public string? PhoneNumber { get; set; } // Số điện thoại bệnh nhân

    public string? IdentityCardNumber { get; set; } // Số CMND/CCCD

    public string? Address { get; set; } // Địa chỉ bệnh nhân

    public int? WardId { get; set; } // ID phường/xã

    public int? DistrictId { get; set; } // ID quận/huyện

    public int? ProvinceId { get; set; } // ID tỉnh/thành phố

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public string? ImageUrl { get; set; } // Đường dẫn đến ảnh bệnh nhân

    public string? ZaloId { get; set; } // ID Zalo của bệnh nhân

    public int? Ethnicity { get; set; } // Dân tộc của bệnh nhân

    public string? TaxCode { get; set; } // Mã số thuế của bệnh nhân

    public string? CompanyName { get; set; } // Tên công ty của bệnh nhân

    //public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>(); // Danh sách cuộc hẹn

    //public virtual ICollection<DiagnosticImagingResult> DiagnosticImagingResults { get; set; } = new List<DiagnosticImagingResult>(); // Danh sách kết quả chẩn đoán hình ảnh

    public virtual AdministrativeUnit? District { get; set; } // Đơn vị hành chính quận/huyện

    //public virtual ICollection<EinvoiceFile> EinvoiceFiles { get; set; } = new List<EinvoiceFile>(); // Danh sách tệp hóa đơn điện tử

    //public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>(); // Danh sách hóa đơn

    //public virtual ICollection<LabResult> LabResults { get; set; } = new List<LabResult>(); // Danh sách kết quả xét nghiệm

    //public virtual ICollection<LabTestFile> LabTestFiles { get; set; } = new List<LabTestFile>(); // Danh sách tệp xét nghiệm

    //public virtual ICollection<MedicalServiceRequest> MedicalServiceRequests { get; set; } = new List<MedicalServiceRequest>(); // Danh sách yêu cầu dịch vụ y tế

    public virtual AdministrativeUnit? Province { get; set; } // Đơn vị hành chính tỉnh/thành phố

    //public virtual ICollection<Reception> Receptions { get; set; } = new List<Reception>(); // Danh sách tiếp nhận

    public virtual AdministrativeUnit? Ward { get; set; } // Đơn vị hành chính phường/xã
}
