using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class ReportParameter
{
    public int ReportParameterId { get; set; } // ID tham số báo cáo

    public int? NumericalOrder { get; set; } // Thứ tự số

    public int? ItemType { get; set; } // Loại mục

    public string? ParameterName { get; set; } // Tên tham số

    public string? DisplayName { get; set; } // Tên hiển thị

    public int? ValueIntCheckBoxTrue { get; set; } // Giá trị số cho checkbox đúng

    public int? ValueIntCheckBoxFalse { get; set; } // Giá trị số cho checkbox sai

    public string? ValueStringCheckBoxTrue { get; set; } // Giá trị chuỗi cho checkbox đúng

    public string? ValueStringCheckBoxFalse { get; set; } // Giá trị chuỗi cho checkbox sai

    public int? LoadType { get; set; } // Loại tải

    public int ReportId { get; set; } // ID báo cáo

    public int TypeOfControlInputId { get; set; } // ID loại đầu vào kiểm soát

    public virtual Report Report { get; set; } = null!; // Báo cáo liên quan

    public virtual TypeOfControlInput TypeOfControlInput { get; set; } = null!; // Loại đầu vào kiểm soát liên quan
}
