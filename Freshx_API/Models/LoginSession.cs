using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class LoginSession
{
    public int LoginSessionId { get; set; }

    public int? UserId { get; set; }

    public DateTime? LoginTime { get; set; }

    public DateTime? LogoutTime { get; set; }

    public string? Ipaddress { get; set; }

    public string? Macaddress { get; set; }

    public int? DepartmentId { get; set; }

    public int? PharmacyId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<DrugBooking> DrugBookings { get; set; } = new List<DrugBooking>();

    public virtual Pharmacy? Pharmacy { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<UserActionByMedicalRecord> UserActionByMedicalRecords { get; set; } = new List<UserActionByMedicalRecord>();

    public virtual ICollection<UserAction> UserActions { get; set; } = new List<UserAction>();
}
