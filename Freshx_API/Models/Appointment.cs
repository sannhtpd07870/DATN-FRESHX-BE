using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class Appointment
{
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
