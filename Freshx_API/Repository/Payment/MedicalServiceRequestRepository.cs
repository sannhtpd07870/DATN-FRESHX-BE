using Freshx_API.Interfaces.Payment;
using Microsoft.EntityFrameworkCore;
using Freshx_API.Models;

namespace Freshx_API.Repository.Payment
{
    public class MedicalServiceRequestRepository : IMedicalServiceRequestRepository
    {
        private readonly FreshxDBContext _context;

        public MedicalServiceRequestRepository(FreshxDBContext context)
        {
            _context = context;
        }

        public async Task<MedicalServiceRequest> CreateMedicalServiceRequestAsync(MedicalServiceRequest medicalServiceRequest)
        {
            _context.MedicalServiceRequests.Add(medicalServiceRequest);
            await _context.SaveChangesAsync();
            return medicalServiceRequest;
        }

        public async Task<IEnumerable<MedicalServiceRequest>> GetRequestsByInvoiceIdAsync(int invoiceId)
        {
            return await _context.MedicalServiceRequests.Where(r => r.InvoiceId == invoiceId).ToListAsync();
        }
    }
}
