﻿using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class UnitOfMeasure
{
    public int UnitOfMeasureId { get; set; } // ID đơn vị đo lường

    public string? Code { get; set; } // Mã đơn vị đo lường

    public string? Name { get; set; } // Tên đơn vị đo lường

    public string? DrugType { get; set; } // Loại thuốc

    public decimal? ConversionValue { get; set; } // Giá trị chuyển đổi

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public string? CreatedBy { get; set; } // Người tạo

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public string? UpdatedBy { get; set; } // Người cập nhật

    //public virtual ICollection<DocumentDetail> DocumentDetailOriginalUnitOfMeasures { get; set; } = new List<DocumentDetail>(); // Danh sách chi tiết tài liệu đơn vị đo lường gốc

    //public virtual ICollection<DocumentDetail> DocumentDetailUnitOfMeasures { get; set; } = new List<DocumentDetail>(); // Danh sách chi tiết tài liệu đơn vị đo lường

    //public virtual ICollection<DrugCatalog> DrugCatalogs { get; set; } = new List<DrugCatalog>(); // Danh sách danh mục thuốc liên quan
}
