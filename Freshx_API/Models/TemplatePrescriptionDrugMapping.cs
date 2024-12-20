using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class TemplatePrescriptionDrugMapping
{
    public int TemplatePrescriptionDrugMappingId { get; set; } // ID ánh xạ thuốc trong mẫu đơn

    public int? TemplatePrescriptionId { get; set; } // ID mẫu đơn thuốc

    public int? DrugCatalogId { get; set; } // ID danh mục thuốc

    public decimal? Quantity { get; set; } // Số lượng

    public decimal? DaysOfSupply { get; set; } // Số ngày cung cấp

    public decimal? MorningDose { get; set; } // Liều buổi sáng

    public decimal? NoonDose { get; set; } // Liều buổi trưa

    public decimal? AfternoonDose { get; set; } // Liều buổi chiều

    public decimal? EveningDose { get; set; } // Liều buổi tối

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public virtual DrugCatalog? DrugCatalog { get; set; } // Danh mục thuốc

    public virtual TemplatePrescription? TemplatePrescription { get; set; } // Mẫu đơn thuốc
}
