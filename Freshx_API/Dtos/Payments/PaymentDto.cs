namespace Freshx_API.Dtos.Payments
{
    public class PaymentDto
    {
        public int BillId { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentMethod { get; set; }
    }

}
