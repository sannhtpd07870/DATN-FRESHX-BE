namespace Freshx_API.Dtos.Doctor
{
    public class DoctorDto
    {
        public int DoctorId { get; set; } // ID bác sĩ
        public string? Name { get; set; } // Tên bác sĩ
        public int? IsSuspended { get; set; } // Trạng thái tạm ngưng
    }
}
