using Freshx_API.Interfaces.Payment;
using Microsoft.EntityFrameworkCore;
using Freshx_API.Models;

namespace Freshx_API.Repository.Payment
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly FreshxDBContext _context;

        public InvoiceRepository(FreshxDBContext context)
        {
            _context = context;
        }

        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int invoiceId)
        {
            return await _context.Invoices.Include(i => i.MedicalServiceRequests)
                                          .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId);
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
        }
    }
}
