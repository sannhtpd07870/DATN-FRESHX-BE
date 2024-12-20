using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Invoice;
using Freshx_API.Models;

namespace Freshx_API.Repositories
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync(); // Get all invoices

        Task<Invoice?> GetInvoiceByIdAsync(int id); // Get an invoice by ID

        Task<IEnumerable<Invoice>> GetInvoicesByPatientIdAsync(int patientId); // Get invoices for a specific patient

        Task AddInvoiceAsync(Invoice invoice); // Add a new invoice

        Task<bool> UpdateInvoiceAsync(Invoice invoice); // Update an existing invoice

        Task<bool> DeleteInvoiceAsync(int id); // Delete an invoice by ID

        Task<bool> SaveChangesAsync(); // Save changes to the database
    }
}
