using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models
{
    public class Receptionist
    {
        [Key]
        public int ReceptionistId { get; set; } // ID receptionist
        public string? Name { get; set; } // Tên le tan
        public string? Phone { get; set; } // Số điện thoại
        public string? Email { get; set; } // Email 
        public string? Gender { get; set; } //giới tính
        public DateTime? DateOfBirth { get; set; } // Ngày sinh
        public int? IsSuspended { get; set; } // Trạng thái tạm ngưng
        public string? CreatedBy { get; set; } // Người tạo

        public DateTime? CreatedDate { get; set; } // Ngày tạo

        public string? UpdatedBy { get; set; } // Người cập nhật

        public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

        public int? IsDeleted { get; set; } // Trạng thái đã xóa

        //public virtual ICollection<DiagnosticImagingResult> DiagnosticImagingResults { get; set; } = new List<DiagnosticImagingResult>(); // Danh sách kết quả chẩn đoán hình ảnh

        //public virtual ICollection<DoctorsCommonIcd> DoctorsCommonIcds { get; set; } = new List<DoctorsCommonIcd>(); // Danh sách ICD phổ biến của bác sĩ

        //public virtual ICollection<Document> DocumentDoctors { get; set; } = new List<Document>(); // Danh sách tài liệu của bác sĩ

        //public virtual ICollection<Document> DocumentReferralDoctors { get; set; } = new List<Document>(); // Danh sách tài liệu của bác sĩ giới thiệu

        //public virtual ICollection<LabResult> LabResults { get; set; } = new List<LabResult>(); // Danh sách kết quả xét nghiệm

        public virtual ICollection<Reception> Receptions { get; set; } = new List<Reception>(); // Danh sách tiếp nhận
    }
}
