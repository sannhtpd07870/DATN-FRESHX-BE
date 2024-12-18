namespace Freshx_API.Dtos.Receptionist
{
    // DTO hiển thị chi tiết thông tin Receptionist
    public class ReceptionistDetailDto
    {
        public int ReceptionistId { get; set; } // ID receptionist
        public string? Name { get; set; } // Tên lễ tân
        public string? Phone { get; set; } // Số điện thoại
        public string? Email { get; set; } // Email
        public string? Gender { get; set; } // Giới tính
        public DateTime? DateOfBirth { get; set; } // Ngày sinh
        public int? IsSuspended { get; set; } // Trạng thái tạm ngưng
        public string? CreatedBy { get; set; } // Người tạo
        public DateTime? CreatedDate { get; set; } // Ngày tạo
        public string? UpdatedBy { get; set; } // Người cập nhật
        public DateTime? UpdatedDate { get; set; } // Ngày cập nhật
    }
}
