using Freshx_API.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freshx_API.Services
{
    public interface IDocumentPurposeService
    {
        Task<DocumentPurposeDto> GetDocumentPurposeByIdAsync(int id);
        Task<IEnumerable<DocumentPurposeDto>> GetAllDocumentPurposesAsync();
        Task<DocumentPurposeDto> CreateDocumentPurposeAsync(DocumentPurposeDto documentPurposeDto);
        Task<DocumentPurposeDto> UpdateDocumentPurposeAsync(int id, DocumentPurposeDto documentPurposeDto);
        Task DeleteDocumentPurposeAsync(int id);
    }
}
