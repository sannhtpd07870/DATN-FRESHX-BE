using Freshx_API.Dtos.Payments;

namespace Freshx_API.Interfaces.Payments
{
    public interface IBillService
    {
        Task<BillDto> CreateBillAsync(BillDto billDto);
        Task<BillDto> GetBillAsync(int billId);
        Task AddPaymentAsync(PaymentDto paymentDto);
    }

}
