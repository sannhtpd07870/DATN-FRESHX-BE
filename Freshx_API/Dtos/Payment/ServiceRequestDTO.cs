namespace Freshx_API.Dtos.Payment
{
    public class ServiceRequestDTO
    {
        public int? ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public int Quantity { get; set; }
        public decimal? ServiceUnitPrice { get; set; }
        
    }
}
