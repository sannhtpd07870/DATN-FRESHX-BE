using Freshx_API.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freshx_API.Services
{
    public interface IDocumentPurposeService
    {
        Task<List<DocumentPurposeDto>> GetAllDocumentPurposesAsync(string? searchKey);
        Task<DocumentPurposeDto?> GetDocumentPurposeByIdAsync(int id);
        Task<DocumentPurposeDto> CreateDocumentPurposeAsync(CreateDocumentPurposeDto dto);
        Task<DocumentPurposeDto?> UpdateDocumentPurposeAsync(int id, DocumentPurposeDto dto);
        Task<bool> DeleteDocumentPurposeAsync(int id);
    }
}
