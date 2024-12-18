using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class ServiceCatalog
{
    public int ServiceCatalogId { get; set; } // ID danh mục dịch vụ

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

    public string? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public string? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public int? PriceTypeId { get; set; } // ID loại giá

    //public virtual ICollection<ConclusionDictionary> ConclusionDictionaries { get; set; } = new List<ConclusionDictionary>(); // Danh sách từ điển kết luận

    //public virtual ICollection<ServiceCatalog> InverseParentService { get; set; } = new List<ServiceCatalog>(); // Danh sách dịch vụ con

    //public virtual ICollection<MedicalServiceRequest> MedicalServiceRequests { get; set; } = new List<MedicalServiceRequest>(); // Danh sách yêu cầu dịch vụ y tế

    public virtual ServiceCatalog? ParentService { get; set; } // Dịch vụ cha

    public virtual ServiceGroup? ServiceGroup { get; set; } // Nhóm dịch vụ

    public ICollection<ServiceCatalog> ChildServices { get; set; }
    //public PriceType PriceType { get; set; }
    //public virtual ICollection<ServiceStandardValue> ServiceStandardValues { get; set; } = new List<ServiceStandardValue>(); // Danh sách giá trị tiêu chuẩn dịch vụ

    //public virtual ICollection<UserAction> UserActions { get; set; } = new List<UserAction>(); // Danh sách hành động của người dùng
}
