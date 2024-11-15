using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class TemplatePrescription
{
    public int TemplatePrescriptionId { get; set; } // ID mẫu đơn thuốc

    public string? Code { get; set; } // Mã mẫu đơn thuốc

    public string? Name { get; set; } // Tên mẫu đơn thuốc

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public virtual ICollection<TemplatePrescriptionDrugMapping> TemplatePrescriptionDrugMappings { get; set; } = new List<TemplatePrescriptionDrugMapping>(); // Danh sách ánh xạ thuốc trong mẫu đơn
}
