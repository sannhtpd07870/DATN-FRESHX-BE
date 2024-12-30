﻿namespace Freshx_API.Dtos.Pharmacy
{
    // DTO để nhận dữ liệu từ client khi tạo hoặc cập nhật nhà thuốc
    public class PharmacyCreateUpdateDto
    {
        public string? Code { get; set; } // Mã nhà thuốc
        public string? Name { get; set; } // Tên nhà thuốc
        public int? DepartmentId { get; set; } // ID phòng ban
        public int? InventoryTypeId { get; set; } // ID loại tồn kho
        public bool? IsSuspended { get; set; } // Trạng thái tạm ngưng
        public string? NameUnaccented { get; set; } // Tên không dấu của nhà thuốc
        public bool? IsSourceManagement { get; set; } // Trạng thái quản lý nguồn
    }
}
