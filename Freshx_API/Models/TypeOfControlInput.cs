using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class TypeOfControlInput
{
    public int TypeOfControlInputId { get; set; } // ID loại đầu vào kiểm soát

    public string? Code { get; set; } // Mã loại đầu vào kiểm soát

    public string? Name { get; set; } // Tên loại đầu vào kiểm soát

    public virtual ICollection<ReportParameter> ReportParameters { get; set; } = new List<ReportParameter>(); // Danh sách tham số báo cáo
}
