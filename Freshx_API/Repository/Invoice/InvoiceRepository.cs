using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Freshx_API.Models;
using Freshx_API.Interfaces;

namespace Freshx_API.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly FreshxDBContext _context;

        public InvoiceRepository(FreshxDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync(string? searchKeyword = null)
        {
            var query = _context.Invoices
         .Include(i => i.Patient)
         .Include(i => i.Reception)
         .Include(i => i.ICDCatalog)
         .Where(i => i.IsDeleted != 1);

            // Nếu có searchKeyword, thêm điều kiện lọc
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query = query.Where(i =>
                    i.InvoiceNumber.Contains(searchKeyword) ||
                    (i.Patient != null && i.Patient.Name.Contains(searchKeyword))); // Tìm kiếm trong InvoiceNumber và PatientName
            }

            return await query.ToListAsync();
        }

        public async Task<Invoice?> GetByIdAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.Patient)
                .Include(i => i.Reception)
                .Include(i => i.ICDCatalog)
                .FirstOrDefaultAsync(i => i.InvoiceId == id && i.IsDeleted != 1);
        }

        public async Task<Invoice> CreateAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            return invoice;
        }

        public async Task<Invoice?> UpdateAsync(Invoice invoice)
        {
            var existingInvoice = await _context.Invoices
                .FirstOrDefaultAsync(i => i.InvoiceId == invoice.InvoiceId && i.IsDeleted != 1);

            if (existingInvoice == null)
                return null;

            _context.Entry(existingInvoice).CurrentValues.SetValues(invoice);
            return existingInvoice;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice == null || invoice.IsDeleted == 1)
                return false;

            invoice.IsDeleted = 1;
            invoice.UpdatedDate = DateTime.Now;

            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Invoices.AnyAsync(i => i.InvoiceId == id && i.IsDeleted != 1);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
