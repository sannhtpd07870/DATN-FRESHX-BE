namespace Freshx_API.Dtos.Receptionist
{
    // DTO hiển thị thông tin cơ bản của Receptionist
    public class ReceptionistDto
    {
        public int ReceptionistId { get; set; } // ID receptionist
        public string? Name { get; set; } // Tên lễ tân
        public string? Phone { get; set; } // Số điện thoại
        public string? Email { get; set; } // Email
        public string? Gender { get; set; } // Giới tính
        public DateTime? DateOfBirth { get; set; } // Ngày sinh
        public int? IsSuspended { get; set; } // Trạng thái tạm ngưng
    }
}
