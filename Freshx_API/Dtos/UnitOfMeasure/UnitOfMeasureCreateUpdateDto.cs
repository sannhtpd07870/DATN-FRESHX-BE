namespace Freshx_API.Dtos.UnitOfMeasure
{
    // DTO để nhận dữ liệu từ client khi tạo hoặc cập nhật đơn vị đo lường
    public class UnitOfMeasureCreateUpdateDto
    {
        public string? Code { get; set; } // Mã đơn vị đo lường
        public string? Name { get; set; } // Tên đơn vị đo lường
        public string? DrugType { get; set; } // Loại thuốc
        public decimal? ConversionValue { get; set; } // Giá trị chuyển đổi
        public int? IsSuspended { get; set; } // Trạng thái tạm ngưng
        public int? IsDeleted { get; set; } // Trạng thái đã xóa
    }
}
