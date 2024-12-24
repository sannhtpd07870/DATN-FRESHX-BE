using NuGet.LibraryModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Freshx_API.Models;

public partial class TemplatePrescription
{
    public int TemplatePrescriptionId { get; set; } // ID mẫu đơn thuốc

    public string? Code { get; set; } // Mã mẫu đơn thuốc

    public string? Name { get; set; } // Tên mẫu đơn thuốc

    public int DrugCatalogId { get; set; }

    [ForeignKey("DrugCatalogId")]
    public virtual ICollection<DrugCatalog>? DrugCatalogs { get; set; } = new List<DrugCatalog>(); 
    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    //public virtual ICollection<TemplatePrescriptionDrugMapping> TemplatePrescriptionDrugMappings { get; set; } = new List<TemplatePrescriptionDrugMapping>(); // Danh sách ánh xạ thuốc trong mẫu đơn
}
