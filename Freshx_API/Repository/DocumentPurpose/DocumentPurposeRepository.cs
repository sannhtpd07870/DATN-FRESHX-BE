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

        public async Task<DocumentPurpose> GetByIdAsync(int id)
        {
            return await _context.DocumentPurposes.FindAsync(id);
        }

        public async Task<IEnumerable<DocumentPurpose>> GetAllAsync()
        {
            return await _context.DocumentPurposes.ToListAsync();
        }

        public async Task AddAsync(DocumentPurpose documentPurpose)
        {
            await _context.DocumentPurposes.AddAsync(documentPurpose);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DocumentPurpose documentPurpose)
        {
            _context.DocumentPurposes.Update(documentPurpose);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(DocumentPurpose documentPurpose)
        {
            _context.DocumentPurposes.Remove(documentPurpose);
            await _context.SaveChangesAsync();
        }
    }
}
