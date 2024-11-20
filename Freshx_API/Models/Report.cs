using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class Report
{
    public int ReportId { get; set; } // ID báo cáo

    public string? ReportCode { get; set; } // Mã báo cáo

    public string? ReportName { get; set; } // Tên báo cáo

    public string? ProcedureName { get; set; } // Tên quy trình

    public string? ReportFile { get; set; } // Tệp báo cáo

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? UpdatedBy { get; set; } // Người cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    //public virtual ICollection<ReportParameter> ReportParameters { get; set; } = new List<ReportParameter>(); // Danh sách tham số báo cáo

    //public virtual ICollection<ReportPermission> ReportPermissions { get; set; } = new List<ReportPermission>(); // Danh sách quyền truy cập báo cáo
}
