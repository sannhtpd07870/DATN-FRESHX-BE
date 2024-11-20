using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models;

public partial class UserPharmacy
{
    [Key]
    public int UserPharmacyId { get; set; } // ID nhà thuốc người dùng

    public int? UserId { get; set; } // ID người dùng

    public int? PharmacyId { get; set; } // ID nhà thuốc

    public virtual Pharmacy? Pharmacy { get; set; } // Nhà thuốc

    public virtual User? User { get; set; } // Người dùng
}
