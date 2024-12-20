using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; } // ID đơn thuốc

    public int? MedicalExaminationId { get; set; } // ID khám bệnh

    public string? PrescriptionNumber { get; set; } // Số đơn thuốc

    public int? DrugCatalogId { get; set; } // ID danh mục thuốc

    public decimal? MorningDose { get; set; } // Liều buổi sáng

    public decimal? NoonDose { get; set; } // Liều buổi trưa

    public decimal? AfternoonDose { get; set; } // Liều buổi chiều

    public decimal? EveningDose { get; set; } // Liều buổi tối

    public decimal? DaysOfSupply { get; set; } // Số ngày cung cấp

    public decimal? Quantity { get; set; } // Số lượng

    public decimal? UnitPrice { get; set; } // Giá đơn vị

    public decimal? TotalAmount { get; set; } // Tổng số tiền

    public bool? IsDispensed { get; set; } // Trạng thái đã phát thuốc

    public decimal? DispensedQuantity { get; set; } // Số lượng đã phát

    public bool? IsPaid { get; set; } // Trạng thái đã thanh toán

    public int? CreatedBy { get; set; } // Người tạo

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public int? UpdatedBy { get; set; } // Người cập nhật

    public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public string? Note { get; set; } // Ghi chú

    //public virtual ICollection<DrugBooking> DrugBookings { get; set; } = new List<DrugBooking>(); // Danh sách đặt thuốc

    public virtual DrugCatalog? DrugCatalog { get; set; } // Danh mục thuốc

    public virtual Invoice? MedicalExamination { get; set; } // Khám bệnh liên quan
}
