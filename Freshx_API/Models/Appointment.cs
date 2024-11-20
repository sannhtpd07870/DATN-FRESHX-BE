using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models;

public partial class Appointment
{
    [Key]
    public int AppointmentId { get; set; }

    public int? MedicalExaminationId { get; set; }

    public int? ReceptionId { get; set; }

    public int? PatientId { get; set; }

    public DateTime? AppointmentTime { get; set; }

    public DateTime? SentTime { get; set; }

    public virtual Invoice? MedicalExamination { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual Reception? Reception { get; set; }
}
