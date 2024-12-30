using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Freshx_API.Repository
{

    public class ExamineRepository : IExamineRepository
    {
        private readonly FreshxDBContext _context;

        public ExamineRepository(FreshxDBContext context)
        {
            _context = context;
        }

        public async Task<Examine> AddAsync(Examine examine)
        {
            await _context.Examines.AddAsync(examine);
            await _context.SaveChangesAsync();
            return examine;
        }

        public async Task<Examine?> GetByIdAsync(int id)
        {
            return await _context.Examines.Include(e => e.Reception).FirstOrDefaultAsync(e => e.ExamineId == id);
        }

        public async Task<IEnumerable<Examine>> GetAllAsync()
        {
            return await _context.Examines.Include(e => e.Reception).ToListAsync();
        }

        public async Task UpdateAsync(Examine examine)
        {
            _context.Examines.Update(examine);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var examine = await _context.Examines.FindAsync(id);
            if (examine != null)
            {
                examine.IsDeleted = 1;
                await _context.SaveChangesAsync();
            }
        }
    }

}
