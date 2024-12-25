using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class MedicalServiceRequestRepository : IMedicalServiceRequestRepository
    {
        private readonly FreshxDBContext _context;

        public MedicalServiceRequestRepository(FreshxDBContext context)
        {
            _context = context;
        }

        public async Task<MedicalServiceRequest?> GetByIdAsync(int id)
        {
            return await _context.MedicalServiceRequests
                                 .Include(m => m.AssignedByEmployee)
                                 .Include(m => m.Patient)
                                 .FirstOrDefaultAsync(m => m.MedicalServiceRequestId == id);
        }

        public async Task<IEnumerable<MedicalServiceRequest>> GetAllAsync()
        {
            return await _context.MedicalServiceRequests.ToListAsync();
        }

        public async Task AddAsync(MedicalServiceRequest entity)
        {
            _context.MedicalServiceRequests.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MedicalServiceRequest entity)
        {
            _context.MedicalServiceRequests.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.MedicalServiceRequests.FindAsync(id);
            if (entity != null)
            {
                _context.MedicalServiceRequests.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
