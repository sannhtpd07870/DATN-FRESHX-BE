namespace Freshx_API.Dtos.ServiceCatalog
{
    // DTO để nhận dữ liệu từ client khi tạo hoặc cập nhật danh mục dịch vụ
    public class ServiceCatalogCreateUpdateDto
    {
        public string? Code { get; set; } // Mã danh mục dịch vụ
        public string? Name { get; set; } // Tên danh mục dịch vụ
        public decimal? Price { get; set; } // Giá dịch vụ
        public string? UnitOfMeasure { get; set; } // Đơn vị đo lường
        public bool? HasStandardValue { get; set; } // Có giá trị tiêu chuẩn không
        public int? Level { get; set; } // Cấp độ dịch vụ
        public bool? IsParentService { get; set; } // Trạng thái dịch vụ cha
        public int? ParentServiceId { get; set; } // ID dịch vụ cha
        public int? ServiceGroupId { get; set; } // ID nhóm dịch vụ
        public int? IsSuspended { get; set; } // Trạng thái tạm ngưng
        //public int? PriceTypeId { get; set; } // ID loại giá
    }
}
