using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Interfaces.DocumentPurposeRepository;
using Freshx_API.Models;
using Freshx_API.Repository;
using Humanizer;
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

        public async Task<List<DocumentPurposeDto>> GetAllDocumentPurposesAsync(string? searchKey)
        {
            var entities = await _repository.GetAllAsync(searchKey);
            return _mapper.Map<List<DocumentPurposeDto>>(entities);
        }

        public async Task<DocumentPurposeDto?> GetDocumentPurposeByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<DocumentPurposeDto>(entity);
        }

        public async Task<DocumentPurposeDto> CreateDocumentPurposeAsync(CreateDocumentPurposeDto dto)
        {
            var entity = _mapper.Map<DocumentPurpose>(dto); // Map DTO to entity
            var createdEntity = await _repository.CreateAsync(entity);
            return _mapper.Map<DocumentPurposeDto>(createdEntity); // Map entity back to DTO
        }


        public async Task<DocumentPurposeDto?> UpdateDocumentPurposeAsync(int id, DocumentPurposeDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            var updatedEntity = await _repository.UpdateAsync(entity);
            return _mapper.Map<DocumentPurposeDto>(updatedEntity);
        }

        public async Task<bool> DeleteDocumentPurposeAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
