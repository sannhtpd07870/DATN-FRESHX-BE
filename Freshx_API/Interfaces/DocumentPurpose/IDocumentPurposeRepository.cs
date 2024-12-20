using Freshx_API.Models;

namespace Freshx_API.Interfaces.DocumentPurposeRepository
{
    public interface IDocumentPurposeRepository
    {
        Task<DocumentPurpose> GetByIdAsync(int id);
        Task<IEnumerable<DocumentPurpose>> GetAllAsync();
        Task AddAsync(DocumentPurpose documentPurpose);
        Task UpdateAsync(DocumentPurpose documentPurpose);
        Task DeleteAsync(DocumentPurpose documentPurpose);
    }

}
