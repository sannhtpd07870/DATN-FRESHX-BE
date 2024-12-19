namespace Freshx_API.Dtos.Invoice
{
    public class InvoiceListResponseDto
    {
        public int InvoiceId { get; set; } // ID hóa đơn
        public string InvoiceNumber { get; set; } // Số hóa đơn
        public DateTime CreatedDate { get; set; } // Ngày tạo
        public string? PatientName { get; set; } // Tên bệnh nhân
        public bool IsPaid { get; set; } // Trạng thái đã thanh toán
    }

}
