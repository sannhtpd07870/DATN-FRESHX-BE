namespace Freshx_API.Dtos.Payment
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public int? PatientId { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool? IsPaid { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ReceptionId { get; set; }
        public List<ServiceRequestDTO> ServiceRequests { get; set; }
    }
}
