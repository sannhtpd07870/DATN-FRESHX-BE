using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class Pharmacy
{
    public int PharmacyId { get; set; } // ID nhà thuốc

    public string? Code { get; set; } // Mã nhà thuốc

    public string? Name { get; set; } // Tên nhà thuốc

    public int? DepartmentId { get; set; } // ID phòng ban

    public int? InventoryTypeId { get; set; } // ID loại tồn kho

    public bool? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public string? NameUnaccented { get; set; } // Tên không dấu của nhà thuốc

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? UpdatedBy { get; set; } // Người cập nhật

    public bool? IsSourceManagement { get; set; } // Trạng thái quản lý nguồn

    public int? SpecialtyId { get; set; } // ID chuyên khoa

    public int? CostCenterId { get; set; } // ID trung tâm chi phí

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public virtual Department? Department { get; set; } // Phòng ban của nhà thuốc

    public virtual ICollection<Document> DocumentCorrespondingPharmacies { get; set; } = new List<Document>(); // Danh sách tài liệu nhà thuốc tương ứng

    public virtual ICollection<Document> DocumentExecutionPharmacies { get; set; } = new List<Document>(); // Danh sách tài liệu nhà thuốc thực hiện

    public virtual ICollection<Document> DocumentIssuingPharmacies { get; set; } = new List<Document>(); // Danh sách tài liệu nhà thuốc phát hành

    public virtual ICollection<Document> DocumentReceivingPharmacies { get; set; } = new List<Document>(); // Danh sách tài liệu nhà thuốc nhận

    public virtual ICollection<Document> DocumentUsagePharmacies { get; set; } = new List<Document>(); // Danh sách tài liệu nhà thuốc sử dụng

    public virtual ICollection<DrugCatalog> DrugCatalogDepartmentPharmacies { get; set; } = new List<DrugCatalog>(); // Danh sách danh mục thuốc của nhà thuốc phòng ban

    public virtual ICollection<DrugCatalog> DrugCatalogManagementPharmacies { get; set; } = new List<DrugCatalog>(); // Danh sách danh mục thuốc của nhà thuốc quản lý

    public virtual InventoryType? InventoryType { get; set; } // Loại tồn kho của nhà thuốc

    public virtual ICollection<LoginSession> LoginSessions { get; set; } = new List<LoginSession>(); // Danh sách phiên đăng nhập của nhà thuốc

    public virtual ICollection<UserPharmacy> UserPharmacies { get; set; } = new List<UserPharmacy>(); // Danh sách người dùng của nhà thuốc
}
