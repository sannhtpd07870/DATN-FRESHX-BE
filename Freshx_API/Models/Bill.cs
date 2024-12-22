using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Freshx_API.Models
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; } // ID hóa đơn

        public int PatientId { get; set; } // ID bệnh nhân liên quan đến hóa đơn

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; } // Tổng số tiền

        [Required]
        [StringLength(20)]
        public string PaymentStatus { get; set; } = "Pending"; // Trạng thái thanh toán (Pending, Paid)

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Ngày tạo hóa đơn

        public DateTime? UpdatedDate { get; set; } // Ngày cập nhật

        // Quan hệ
        public virtual Patient Patient { get; set; } // Tham chiếu đến bệnh nhân
        public virtual ICollection<BillDetail> BillDetails { get; set; } = new HashSet<BillDetail>(); // Danh sách chi tiết hóa đơn
        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>(); // Danh sách thanh toán
    }
}
