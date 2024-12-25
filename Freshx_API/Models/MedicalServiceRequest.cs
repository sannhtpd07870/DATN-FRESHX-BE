using System;
using System.Collections.Generic;
using Freshx_API.Models;

namespace Freshx_API.Models;

public partial class MedicalServiceRequest
{
    public int MedicalServiceRequestId { get; set; } // mã yc dịch vụ
    public DateTime? RequestTime { get; set; } // thời gian yc
    public int? ReceptionId { get; set; } //id tiếp nhận
    public int? ServiceId { get; set; } // id dịch vụ
    public int? Quantity { get; set; } // số lượng
    public decimal? ServiceTotalAmount { get; set; } // tổng tiền dịch vụ
    public bool? IsApproved { get; set; } // có được phép thực hiện?
    public bool? Status { get; set; } // trạng thái?
    public int? AssignedById { get; set; } // người chỉ định
    public int? CreatedBy { get; set; } // tạo bởi

    public DateTime? CreatedDate { get; set; } // Ngày tạo

    public string? UpdatedBy { get; set; } // Cập nhật bởi

    public DateTime? UpdatedDate { get; set; } // ngày cập nhật

    public int? IsDeleted { get; set; } // đã xóa?

    public virtual Employee? AssignedByEmployee { get; set; }
    public virtual Doctor? AssignedByDoctor { get; set; }

    public virtual MedicalServiceRequest? ParentMedicalServiceRequest { get; set; }
    
    public virtual Patient? Patient { get; set; }

    public virtual Reception? Reception { get; set; }

    public virtual ServiceCatalog? Service { get; set; }
}
