
using Freshx_API.Models;

namespace Freshx_API.Interfaces
{
    public interface IDrugCatalogRepository
    {
        Task<IEnumerable<DrugCatalog>> GetAllAsync();
        Task<DrugCatalog> GetByIdAsync(int id);
        //Task<DrugCatalog> CreateAsync(DrugCatalog drug);
        //Task UpdateAsync(DrugCatalog drug);
        //Task DeleteAsync(int id);
        //Task<bool> ExistsAsync(int id);
        //Task<IEnumerable<DrugCatalog>> SearchAsync(string searchTerm);
    }
}