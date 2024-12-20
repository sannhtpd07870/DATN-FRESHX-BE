using Freshx_API.Models;

namespace Freshx_API.Interfaces.DocumentPurposeRepository
{
    public interface IDocumentPurposeRepository
    {
        Task<List<DocumentPurpose>> GetAllAsync(string? searchKey);
        Task<DocumentPurpose?> GetByIdAsync(int id);
        Task<DocumentPurpose> CreateAsync(DocumentPurpose entity);
        Task<DocumentPurpose> UpdateAsync(DocumentPurpose entity);
        Task<bool> DeleteAsync(int id);
    }

}
