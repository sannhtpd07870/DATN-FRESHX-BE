using Freshx_API.Interfaces.DocumentPurposeRepository;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class DocumentPurposeRepository : IDocumentPurposeRepository
    {
        private readonly FreshxDBContext _context;

        public DocumentPurposeRepository(FreshxDBContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentPurpose>> GetAllAsync(string? searchKey)
        {
            return await _context.DocumentPurposes
                .Where(dp => string.IsNullOrEmpty(searchKey) || dp.Name.Contains(searchKey))
                .ToListAsync();
        }

        public async Task<DocumentPurpose?> GetByIdAsync(int id)
        {
            return await _context.DocumentPurposes.FindAsync(id);
        }

        public async Task<DocumentPurpose> CreateAsync(DocumentPurpose entity)
        {
            _context.DocumentPurposes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<DocumentPurpose> UpdateAsync(DocumentPurpose entity)
        {
            _context.DocumentPurposes.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.DocumentPurposes.FindAsync(id);
            if (entity == null) return false;

            _context.DocumentPurposes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
