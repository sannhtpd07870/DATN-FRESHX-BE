using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;
namespace Freshx_API.Repository
{
    public class DrugCatalogRepository : IDrugCatalogRepository
    {

        private readonly FreshxDBContext _context;
        public DrugCatalogRepository(FreshxDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DrugCatalog>> GetAllAsync()
        {
            return await _context.DrugCatalogs
                .Include(d => d.DrugType)
                .Include(d => d.UnitOfMeasure)
                .ToListAsync();
        }
        public async Task<DrugCatalog> GetByIdAsync(int id)
        {
            return await _context.DrugCatalogs
                .Include(d => d.DrugType)
                .Include(d => d.UnitOfMeasure)
                .FirstOrDefaultAsync(d => d.DrugCatalogId == id);
        }
        // Implement các method khác...
    }
}
