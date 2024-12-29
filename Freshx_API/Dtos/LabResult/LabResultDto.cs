﻿using Freshx_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Dtos.LabResult
{
    public class LabResultDto
    {
        // Mã kết quả xét nghiệm
        [Required(ErrorMessage = "Mã kết quả xét nghiệm không được để trống.")]
        public int LabResultId { get; set; }
        // Ngày thực hiện
        [Required(ErrorMessage = "Vui lòng điền ngày thực hiện.")]
        public DateTime? ExecutionDate { get; set; }
        // Thời gian thực hiện
        public DateTime? ExecutionTime { get; set; }
        // ID tiếp nhận
        [Required(ErrorMessage = "Vui lòng điền ID người tiếp nhận.")]
        public int? ReceptionId { get; set; }
        // ID bệnh nhân
        [Required(ErrorMessage = "Vui lòng điền ID bệnh nhân.")]
        public int? PatientId { get; set; }
        // ID kỹ thuật viên thực hiện
        [Required(ErrorMessage = "Vui lòng điền ID bệnh nhân.")]
        public int? TechnicianId { get; set; }
        // ID bác sĩ kết luận
        [Required(ErrorMessage = "Vui lòng điền ID bệnh nhân.")]
        public int? ConcludingDoctorId { get; set; }
        // Kết luận
        [Required(ErrorMessage = "Vui lòng điền ID bệnh nhân.")]
        public string? Conclusion { get; set; }
        // Kết quả
        [Required(ErrorMessage = "Vui lòng điền ID bệnh nhân.")]
        public string? Result { get; set; }
        // Mô tả
        public string? Description { get; set; }
        // Ghi chú
        public string? Note { get; set; }
        // Lời dặn
        public string? Instruction { get; set; }
        // Chẩn đoán
        public string? Diagnosis { get; set; }
        // ID loại kết quả
        public int? ResultTypeId { get; set; }
        // Thời gian nhận mẫu
        public DateTime? SampleReceivedTime { get; set; }
        // ID loại mẫu
        public int? SampleTypeId { get; set; }
        // ID chất lượng mẫu
        public int? SampleQualityId { get; set; }
        // Người tạo
        public int? CreatedBy { get; set; }
        // Ngày tạo
        public DateTime? CreatedDate { get; set; }
        // Người cập nhật
        public int? UpdatedBy { get; set; }
        // Ngày cập nhật
        public DateTime? UpdatedDate { get; set; }
        // Đã xóa
        public int? IsDeleted { get; set; }
        // Ngày nhận mẫu
        public DateTime? SampleReceivedDate { get; set; }
        // Ngày lấy mẫu
        public DateTime? SampleCollectionDate { get; set; }
        // Thời gian lấy mẫu
        public DateTime? SampleCollectionTime { get; set; }

        //public virtual Doctor? ConcludingDoctor { get; set; }

        //public virtual Patient? Patient { get; set; }

        public virtual Reception? Reception { get; set; }

        public virtual Technician? Technician { get; set; }
    }
}
