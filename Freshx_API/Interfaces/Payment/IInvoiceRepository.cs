using Freshx_API.Models;

namespace Freshx_API.Interfaces.Payment
{
    public interface IInvoiceRepository
    {
        Task<Invoice> CreateInvoiceAsync(Invoice invoice);
        Task<Invoice> GetInvoiceByIdAsync(int invoiceId);
        Task UpdateInvoiceAsync(Invoice invoice);
    }
}
