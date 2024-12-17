namespace Freshx_API.Dtos.Patient
{
    public class AddingPatientRequest
    {
        public string? MedicalRecordNumber { get; set; } // Số hồ sơ bệnh án

        public string? AdmissionNumber { get; set; } // Số nhập viện

        public string? Name { get; set; } // Tên bệnh nhân

        public string? Gender { get; set; } // Giới tính bệnh nhân

        public DateTime? DateOfBirth { get; set; } // Ngày sinh bệnh nhân

        public int? YearOfBirth { get; set; } // Năm sinh bệnh nhân

        public string? PhoneNumber { get; set; } // Số điện thoại bệnh nhân

        public string? IdentityCardNumber { get; set; } // Số CMND/CCCD

        public string? Address { get; set; } // Địa chỉ bệnh nhân

        public int? CreatedBy { get; set; } // Người tạo

        public DateTime? CreatedDate { get; set; } // Ngày tạo

        public int? UpdatedBy { get; set; } // Người cập nhật

        public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

        public int? IsDeleted { get; set; } // Trạng thái đã xóa

        public string? ImageUrl { get; set; } // Đường dẫn đến ảnh bệnh nhân

        public string? Ethnicity { get; set; } // Dân tộc của bệnh nhân
    }
}
