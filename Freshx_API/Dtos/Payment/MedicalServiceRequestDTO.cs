namespace Freshx_API.Dtos.Payment
{
    public class MedicalServiceRequestDTO
    {
        public int? ServiceId { get; set; }
        public int? Quantity { get; set; }
        public decimal? ServiceUnitPrice { get; set; }
        public decimal? ServiceTotalAmount { get; set; }
        public bool? IsPaid { get; set; }
        public int? InvoiceId { get; set; }
    }
}
