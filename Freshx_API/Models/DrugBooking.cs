﻿using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class DrugBooking
{
    public int DrugBookingId { get; set; } // ID đặt thuốc

    public int? LoginSessionId { get; set; } // ID phiên đăng nhập

    public int? MedicalExaminationId { get; set; } // ID khám bệnh

    public int? PrescriptionId { get; set; } // ID đơn thuốc

    public int? DrugCatalogId { get; set; } // ID danh mục thuốc

    public decimal? MorningDose { get; set; } // Liều buổi sáng

    public decimal? NoonDose { get; set; } // Liều buổi trưa

    public decimal? AfternoonDose { get; set; } // Liều buổi chiều

    public decimal? EveningDose { get; set; } // Liều buổi tối

    public decimal? DaysOfSupply { get; set; } // Số ngày cung cấp

    public decimal? Quantity { get; set; } // Số lượng

    public decimal? UnitPrice { get; set; } // Giá đơn vị

    public decimal? TotalAmount { get; set; } // Tổng số tiền

    public string? Action { get; set; } // Hành động

    public int? Status { get; set; } // Trạng thái

    public string? Note { get; set; } // Ghi chú

    public virtual DrugCatalog? DrugCatalog { get; set; } // Danh mục thuốc

    public virtual LoginSession? LoginSession { get; set; } // Phiên đăng nhập liên quan

    public virtual Invoice? MedicalExamination { get; set; } // Khám bệnh liên quan

    public virtual Prescription? Prescription { get; set; } // Đơn thuốc liên quan
}
