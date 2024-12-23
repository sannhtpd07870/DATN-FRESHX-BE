using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos;
using Freshx_API.Models;

namespace Freshx_API.Repositories
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice?> GetByIdAsync(int id);
        Task<Invoice> CreateAsync(Invoice invoice);
        Task<Invoice?> UpdateAsync(Invoice invoice);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task SaveChangesAsync();
    }
}