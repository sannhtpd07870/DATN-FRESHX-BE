namespace Freshx_API.Dtos.Invoice
{
    public class MedicalServiceRequestDto
    {
        public int MedicalServiceRequestId { get; set; }
        public string ServiceName { get; set; } // Tên dịch vụ y tế
        public decimal Price { get; set; } // Giá dịch vụ
        public DateTime RequestDate { get; set; } // Ngày yêu cầu
    }

}
