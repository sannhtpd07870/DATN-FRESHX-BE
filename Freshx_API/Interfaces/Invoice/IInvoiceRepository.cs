using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Invoice;
using Freshx_API.Models;

namespace Freshx_API.Repositories
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync(); // Retrieve all invoices

        Task<Invoice?> GetInvoiceByIdAsync(int id); // Retrieve an invoice by ID

        Task<IEnumerable<Invoice>> GetInvoicesByPatientIdAsync(int patientId); // Retrieve invoices for a specific patient

        Task AddInvoiceAsync(Invoice invoice); // Add a new invoice

        Task UpdateInvoiceAsync(Invoice invoice); // Update an existing invoice

        Task DeleteInvoiceAsync(int id); // Delete an invoice by ID

        Task<bool> SaveChangesAsync(); // Save changes to the database
    }
}
