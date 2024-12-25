using AutoMapper;

using Freshx_API.Interfaces;
using Freshx_API.Interfaces.IReception;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class ReceptionRepository : IReceptionRepository
    {
        private readonly FreshxDBContext _context;

        public ReceptionRepository(FreshxDBContext context)
        {
            _context = context;
        }

        public async Task<Reception?> GetByIdAsync(int id)
        {
            return await _context.Receptions
                .Include(r => r.MedicalServiceRequest)
                .Include(r => r.AssignedDoctor)
                .Include(r => r.Patient)
                .Include(r => r.Receptionist)
                .FirstOrDefaultAsync(r => r.ReceptionId == id);
        }

        public async Task<IEnumerable<Reception>> GetAllAsync()
        {
            return await _context.Receptions
                .Include(r => r.MedicalServiceRequest)
                .Include(r => r.AssignedDoctor)
                .Include(r => r.Patient)
                .Include(r => r.Receptionist)
                .ToListAsync();
        }

        public async Task AddAsync(Reception reception)
        {
            _context.Receptions.Add(reception);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reception reception)
        {
            _context.Receptions.Update(reception);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reception = await _context.Receptions.FindAsync(id);
            if (reception != null)
            {
                _context.Receptions.Remove(reception);
                await _context.SaveChangesAsync();
            }
        }
    }

}