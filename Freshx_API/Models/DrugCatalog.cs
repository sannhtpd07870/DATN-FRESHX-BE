﻿using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class DrugCatalog
{
  public int DrugCatalogId { get; set; } // ID danh mục thuốc

    public string? Code { get; set; } // Mã danh mục thuốc

    public string? Name { get; set; } // Tên danh mục thuốc

    public int? UnitOfMeasureId { get; set; } // ID đơn vị đo lường

    public int? ManufacturerId { get; set; } // ID nhà sản xuất

    public int? CountryId { get; set; } // ID quốc gia

    public string? FullName { get; set; } // Tên đầy đủ của thuốc

    public string? NameUnaccented { get; set; } // Tên không dấu của thuốc

    public string? ActiveIngredient { get; set; } // Thành phần hoạt chất

    public string? Usage { get; set; } // Cách sử dụng

    public string? Dosage { get; set; } // Liều lượng

    public string? Effect { get; set; } // Tác dụng

    public int? DrugTypeId { get; set; } // ID loại thuốc

    public string? DrugClassification { get; set; } // Phân loại thuốc

    public string? RouteOfAdministration { get; set; } // Đường dùng thuốc

    public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? UpdatedBy { get; set; } // Người cập nhật

    public string? NationalDrugCode { get; set; } // Mã thuốc quốc gia

    public string? Description { get; set; } // Mô tả thuốc

    public string? ReferenceNumber { get; set; } // Số tham chiếu

    public string? Note1 { get; set; } // Ghi chú 1

    public string? Note2 { get; set; } // Ghi chú 2

    public string? Note3 { get; set; } // Ghi chú 3

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public DateTime? StartDate { get; set; } // Ngày bắt đầu

    public DateTime? EndDate { get; set; } // Ngày kết thúc

    public decimal? QuantityImported { get; set; } // Số lượng nhập khẩu

    public decimal? QuantityInStock { get; set; } // Số lượng tồn kho

    public decimal? CostPrice { get; set; } // Giá vốn

    public decimal? UnitPrice { get; set; } // Giá bán

    public int? ManagementPharmacyId { get; set; } // ID nhà thuốc quản lý

      public int? DepartmentPharmacyId { get; set; } // ID nhà thuốc phòng ban

    public virtual Country? Country { get; set; } // Quốc gia của thuốc

    public virtual Pharmacy? DepartmentPharmacy { get; set; } // Nhà thuốc phòng ban

    //public virtual ICollection<DocumentDetail> DocumentDetails { get; set; } = new List<DocumentDetail>(); // Danh sách chi tiết tài liệu

    //public virtual ICollection<DrugBooking> DrugBookings { get; set; } = new List<DrugBooking>(); // Danh sách đặt thuốc

    public virtual DrugType? DrugType { get; set; } // Loại thuốc

    public virtual Pharmacy? ManagementPharmacy { get; set; } // Nhà thuốc quản lý
    public virtual Supplier? Manufacturer { get; set; }

    //public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    //public virtual ICollection<TemplatePrescriptionDrugMapping> TemplatePrescriptionDrugMappings { get; set; } = new List<TemplatePrescriptionDrugMapping>();

    public virtual UnitOfMeasure? UnitOfMeasure { get; set; }
}
