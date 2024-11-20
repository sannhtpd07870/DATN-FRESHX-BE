using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models;

public partial class AdministrativeUnit
{
    [Key]
    public int AdministrativeUnitId { get; set; } // ID đơn vị hành chính

    public string? Code { get; set; } // Mã đơn vị hành chính

    public string? Name { get; set; } // Tên đơn vị hành chính

    public string? NameEnglish { get; set; } // Tên đơn vị hành chính bằng tiếng Anh

    public string? Level { get; set; } // Cấp độ đơn vị hành chính

    public int? Type { get; set; } // Loại đơn vị hành chính

    public string? DistrictCode { get; set; } // Mã quận

    public string? DistrictName { get; set; } // Tên quận

    public string? ProvinceCode { get; set; } // Mã tỉnh

    public string? ProvinceName { get; set; } // Tên tỉnh

    public int? HismappingId { get; set; } // ID bản đồ HIS
}
