namespace Freshx_API.Dtos.Doctor
{
    public class DoctorDto
    {
        public string? IdentityCardNumber { get; set; } // Số CMND/CCCD ktra trùng lặp
        public string? Name { get; set; } // Tên bác sĩ
        public string? Specialty { get; set; } // chuyên ngành và chuyên môn
        public string? Phone { get; set; } // Số điện thoại
        public string? Email { get; set; } // Email 
        public string? Gender { get; set; } //giới tính
        public DateTime? DateOfBirth { get; set; } // Ngày sinh
        public int? AvataId { get; set; } // ảnh
        public int? WardId { get; set; } // ID phường/xã

        public int? DistrictId { get; set; } // ID quận/huyện

        public int? ProvinceId { get; set; } // ID tỉnh/thành phố

        public int? DepartmentId { get; set; } // ID phòng ban

        public string? AccountId { get; set; }
        public int? PositionId { get; set; }
    }
}
