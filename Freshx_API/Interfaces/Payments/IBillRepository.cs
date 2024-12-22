using Freshx_API.Models;

namespace Freshx_API.Interfaces.Payments
{
    public interface IBillRepository
    {
        Task<Bill> AddBillAsync(Bill bill);
        Task<Bill> GetBillByIdAsync(int billId);
        Task UpdateBillAsync(Bill bill);
    }

}
