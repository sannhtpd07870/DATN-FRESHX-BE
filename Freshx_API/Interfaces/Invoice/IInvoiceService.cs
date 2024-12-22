using Freshx_API.DTOs;

namespace Freshx_API.Interfaces.Invoice
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync(string? searchKeyword = null);
        Task<InvoiceDto?> GetInvoiceByIdAsync(int id);
        Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceDto createInvoiceDto);
        Task<InvoiceDto?> UpdateInvoiceAsync(int id, UpdateInvoiceDto updateInvoiceDto);
        Task<bool> DeleteInvoiceAsync(int id);
    }
}
