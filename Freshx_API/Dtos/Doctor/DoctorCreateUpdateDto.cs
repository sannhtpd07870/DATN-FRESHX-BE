namespace Freshx_API.Dtos.Doctor
{
    public class DoctorCreateUpdateDto
    {
        public string? Name { get; set; } // Tên bác sĩ
        public string? Specialty { get; set; } // chuyên ngành và chuyên môn
        public string? Phone { get; set; } // Số điện thoại
        public string? Email { get; set; } // Email 
        public string? Gender { get; set; } //giới tính
        public DateTime? DateOfBirth { get; set; } // Ngày sinh
        public int? IsSuspended { get; set; } // Trạng thái tạm ngưng
    }
}
