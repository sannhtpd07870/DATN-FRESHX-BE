using System;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Dtos
{
    public class PatientDTO
    {
        public int PatientId { get; set; }
        public string? MedicalRecordNumber { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? IdentityCardNumber { get; set; }
        // Thêm các trường cần thiết khác
    }

    public class CreatePatientDTO
    {
        [Required]
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? IdentityCardNumber { get; set; }
    }
}