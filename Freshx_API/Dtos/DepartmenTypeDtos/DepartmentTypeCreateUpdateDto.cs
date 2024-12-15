namespace Freshx_API.Dtos.DepartmenTypeDtos
{
    // DTO để nhận dữ liệu từ client khi tạo hoặc cập nhật phòng ban
    public class DepartmentTypeCreateUpdateDto
    {
        public string? Code { get; set; } // Mã phòng ban
        public string? Name { get; set; } // Tên phòng ban
        public int? IsSuspended { get; set; } // Trạng thái tạm ngưng
    }
}
