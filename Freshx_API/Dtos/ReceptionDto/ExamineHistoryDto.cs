namespace Freshx_API.Dtos
{
    public class ExamineHistoryDto
    {
        public int? ReceptionId { get; set; } // ID tiếp nhận
        public int? ExamineId { get; set; } // ID khám bệnh
        public int? PatientId { get; set; } // ID bệnh nhân
        public string? PatientName { get; set; } // Tên bệnh nhân
        public string? PatientMedicalRecordNumber { get; set; } // Mã bệnh nhân
        public string? MedicalRecordNumber { get; set; } // Số hồ sơ bệnh án {tự sinh} vd: bn001}
        public int? Age { get; set; } // Tuổi bệnh nhân
        public string? Gender { get; set; } // Giới tính bệnh nhân
        public string? PhoneNumber { get; set; } // Số điện thoại bệnh nhân
        public string? Address { get; set; } // Địa chỉ bệnh nhân
        public string? AdmissionDate { get; set; }
        public List<MedicalHistory>? MedicalHistory { get; set; } // Tiền sử bệnh
        public MedicalHistory? LastExamine { get; set; } //lần khám gần nhất
        public string? DoctorName { get; set; } // Bác sĩ khám
        public ContactInfoDto? ContactInfo { get; set; }
    }

    public class ContactInfoDto
    {
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

    }
    public class MedicalHistory
    {
        public string? Diagnosis { get; set; } // Chẩn đoán
        public string? Conclusion { get; set; } // Kết luận
        public DateTime? Date { get; set; }
        public string? Doctorexamine { get; set; }
    }
}
