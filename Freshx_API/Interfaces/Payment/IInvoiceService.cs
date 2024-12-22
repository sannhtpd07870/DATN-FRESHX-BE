using Freshx_API.Dtos.Payment;

namespace Freshx_API.Interfaces.Payment
{
    public interface IInvoiceService
    {
        Task<InvoiceDTO> CreateInvoiceAsync(InvoiceDTO invoiceDTO);
        Task<InvoiceDTO> GetInvoiceByIdAsync(int invoiceId);
        Task MarkInvoiceAsPaidAsync(int invoiceId);
    }
}
