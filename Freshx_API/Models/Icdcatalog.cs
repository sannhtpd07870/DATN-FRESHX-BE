using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class ICDCatalog
{
    public int ICDCatalogId { get; set; } // ID danh mục ICD

    public string? Code { get; set; } // Mã danh mục ICD

    public string? Name { get; set; } // Tên danh mục ICD

    public string? NameEnglish { get; set; } // Tên danh mục ICD bằng tiếng Anh

    public string? NameRussian { get; set; } // Tên danh mục ICD bằng tiếng Nga

    public string? Level { get; set; } // Cấp độ danh mục ICD

    public int?  ICDCatalogGroupId { get; set; } // ID nhóm danh mục ICD

    public string? Subgroup { get; set; } // Nhóm phụ

    public short? Type { get; set; } // Loại danh mục ICD

    public bool IsInfectious { get; set; } // Trạng thái bệnh truyền nhiễm

    public bool? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public string? NameUnaccented { get; set; } // Tên không dấu của danh mục ICD

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? UpdatedBy { get; set; } // Người cập nhật

    public int? LegacyCode { get; set; } // Mã kế thừa

    //public virtual ICollection<DoctorsCommonIcd> DoctorsCommonIcds { get; set; } = new List<DoctorsCommonIcd>(); // Danh sách ICD phổ biến của bác sĩ

    public virtual  ICDCatalog?  ICDCatalogGroup { get; set; } // Nhóm danh mục ICD

    //public virtual ICollection< ICDCatalog> Inverse ICDCatalogGroup { get; set; } = new List< ICDCatalog>(); // Danh sách nhóm danh mục ICD ngược

    //public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>(); // Danh sách hóa đơn liên quan
}
