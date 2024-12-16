namespace Freshx_API.Dtos.DepartmentDtos
{
    // DTO để trả dữ liệu cơ bản về client (danh sách phòng ban)
    public class DepartmentDto
    {
        public int DepartmentId { get; set; } // ID phòng ban
        public string? Code { get; set; } // Mã phòng ban
        public string? Name { get; set; } // Tên phòng ban
    }
}
