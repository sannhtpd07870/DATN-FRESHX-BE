using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models
{
    public class MedicalHistory
    {
        [Key]
        public int Id { get; set; }
        public string? Condition { get; set; }
        public DateTime DateDiagnosed { get; set; }
        public string? Treatment { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
