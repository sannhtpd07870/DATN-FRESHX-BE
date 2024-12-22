namespace Freshx_API.Dtos.Payments
{
    public class BillDto
    {
        public int PatientId { get; set; }
        public List<BillDetailDto> BillDetails { get; set; } = new List<BillDetailDto>();
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
