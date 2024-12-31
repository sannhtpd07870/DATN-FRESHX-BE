using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;
using Freshx_API.Interfaces.LabResultRepository;

namespace Freshx_API.Repository.LabResults
{
    public class LabResultRepository : ILabResultRepository
    {
        private readonly FreshxDBContext _context;
        public LabResultRepository(FreshxDBContext context)
        {
            _context = context;
        }

        public async Task<LabResult> GetByIdAsync(int id)
        {
            //return await _context.LabResults
            //    .FindAsync(r => r.LabResultId == id && (r.IsDeleted == 0 || r.IsDeleted == null));
            return await _context.Set<LabResult>().FindAsync(id);
        }
        public async Task<IEnumerable<LabResult>> GetAllAsync()
        {
            //var query = _context.LabResults
            //    .Where(l => l.IsDeleted == 0 || l.IsDeleted == null);

            //if (!string.IsNullOrWhiteSpace(searchKeyword))
            //{
            //    query = query.Where(l => l.PatientId.ToString().Contains(searchKeyword) || 
            //                                l.ReceptionId.ToString().Contains(searchKeyword) || 
            //                                    l.ConcludingDoctorId.ToString().Contains(searchKeyword));
            //}

            //if (createdDate.HasValue)
            //{
            //    query = query.Where(r => r.CreatedDate >= createdDate.Value);
            //}

            //if (updatedDate.HasValue)
            //{
            //    query = query.Where(r => r.UpdatedDate <= updatedDate.Value);
            //}

            //return await query.ToListAsync();

            return await _context.LabResults.ToListAsync();
        }

        public async Task CreateAsync(LabResult labResult)
        {
            await _context.LabResults.AddAsync(labResult);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LabResult labResult)
        {
            //_context.Entry(labResult).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            _context.LabResults.Update(labResult);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(LabResult labResult)
        {
            //var entity = await _context.LabResults.FindAsync(id);
            //if (entity != null)
            //{
            //    entity.IsDeleted = 1;
            //    await _context.SaveChangesAsync();
            //}

            _context.LabResults.Remove(labResult);
            await _context.SaveChangesAsync();
        }

        public Task AddAsync(LabResult labResult)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
