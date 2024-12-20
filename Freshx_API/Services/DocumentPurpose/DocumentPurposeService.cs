using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Interfaces.DocumentPurposeRepository;
using Freshx_API.Models;
using Freshx_API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freshx_API.Services
{
    public class DocumentPurposeService : IDocumentPurposeService
    {
        private readonly IDocumentPurposeRepository _repository;
        private readonly IMapper _mapper;

        public DocumentPurposeService(IDocumentPurposeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DocumentPurposeDto> GetDocumentPurposeByIdAsync(int id)
        {
            var documentPurpose = await _repository.GetByIdAsync(id);
            return _mapper.Map<DocumentPurposeDto>(documentPurpose);
        }

        public async Task<IEnumerable<DocumentPurposeDto>> GetAllDocumentPurposesAsync()
        {
            var documentPurposes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DocumentPurposeDto>>(documentPurposes);
        }

        public async Task<DocumentPurposeDto> CreateDocumentPurposeAsync(DocumentPurposeDto documentPurposeDto)
        {
            var documentPurpose = _mapper.Map<DocumentPurpose>(documentPurposeDto);
            await _repository.AddAsync(documentPurpose);
            return _mapper.Map<DocumentPurposeDto>(documentPurpose);
        }

        public async Task<DocumentPurposeDto> UpdateDocumentPurposeAsync(int id, DocumentPurposeDto documentPurposeDto)
        {
            var existingDocumentPurpose = await _repository.GetByIdAsync(id);
            if (existingDocumentPurpose == null)
            {
                return null;
            }

            _mapper.Map(documentPurposeDto, existingDocumentPurpose);
            await _repository.UpdateAsync(existingDocumentPurpose);
            return _mapper.Map<DocumentPurposeDto>(existingDocumentPurpose);
        }

        public async Task DeleteDocumentPurposeAsync(int id)
        {
            var documentPurpose = await _repository.GetByIdAsync(id);
            if (documentPurpose != null)
            {
                await _repository.DeleteAsync(documentPurpose);
            }
        }
    }
}
