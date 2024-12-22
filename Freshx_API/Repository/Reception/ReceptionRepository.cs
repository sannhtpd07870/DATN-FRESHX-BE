using AutoMapper;

using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public interface IReceptionRepository
    {
        Task<List<Reception>> GetAllReceptionsAsync();
        Task<Reception?> GetReceptionByIdAsync(int receptionId);
        Task<List<Reception>> GetReceptionsByPatientIdAsync(int patientId);
        Task CreateReceptionAsync(Reception reception);
        Task UpdateReceptionAsync(Reception reception);
        Task DeleteReceptionAsync(int receptionId);
    }

    public class ReceptionRepository : IReceptionRepository
    {
        private readonly FreshxDBContext _context;

        public ReceptionRepository(FreshxDBContext context)
        {
            _context = context;
        }

        public async Task<List<Reception>> GetAllReceptionsAsync()
        {
            return await _context.Receptions.Include(r => r.Patient).Include(r => r.AssignedDoctor).ToListAsync();
        }

        public async Task<Reception?> GetReceptionByIdAsync(int receptionId)
        {
            return await _context.Receptions.Include(r => r.Patient).Include(r => r.AssignedDoctor)
                                             .FirstOrDefaultAsync(r => r.ReceptionId == receptionId);
        }

        public async Task<List<Reception>> GetReceptionsByPatientIdAsync(int patientId)
        {
            return await _context.Receptions.Include(r => r.Patient).Include(r => r.AssignedDoctor)
                                             .Where(r => r.PatientId == patientId).ToListAsync();
        }

        public async Task CreateReceptionAsync(Reception reception)
        {
            await _context.Receptions.AddAsync(reception);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReceptionAsync(Reception reception)
        {
            _context.Receptions.Update(reception);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReceptionAsync(int receptionId)
        {
            var reception = await _context.Receptions.FindAsync(receptionId);
            if (reception != null)
            {
                _context.Receptions.Remove(reception);
                await _context.SaveChangesAsync();
            }
        }
    }

}
