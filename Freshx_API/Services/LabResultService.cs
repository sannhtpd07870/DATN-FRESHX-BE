using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.LabResult;
using Freshx_API.Models;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Interfaces;
using Freshx_API.Interfaces.LabResultRepository;
using Freshx_API.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freshx_API.Services
{
    public class LabResultService : ILabResultService
    {
        private readonly ILabResultRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;

        public LabResultService(ILabResultRepository repository, IMapper mapper, ITokenRepository tokenRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
        }

        public async Task<LabResultDto?> GetLabResultByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result == null) return null;

            //if (result.IsDeleted == 1)
            //{
            //    result.LabResultId = result.LabResultId + " (đã bị xóa)";
            //}
            return _mapper.Map<LabResultDto>(result);
        }

        public async Task<IEnumerable<LabResultDto>> GetAllLabResultsAsync(string? searchKeyword, DateTime? createdDate, DateTime? updatedDate)
        {
            var result = await _repository.GetAllAsync();

            //foreach (var labResult in entities.ToList())
            //{
            //    if (labResult.IsDeleted == 1)
            //    {
            //        return labResult.LabResultId + " (đã bị xóa)";
            //    }
            //}

            return _mapper.Map<IEnumerable<LabResultDto>>(result);
        }



        public async Task<LabResultDto> CreateLabResultAsync(LabResultDto dto)
        {
            var labResult = _mapper.Map<LabResult>(dto);
            // Default
            //labResult.IsDeleted = 0;
            //labResult.CreatedDate = DateTime.UtcNow;
            //labResult.CreatedBy = int.Parse(_tokenRepository.GetUserIdFromToken());
            await _repository.AddAsync(labResult);
            return _mapper.Map<LabResultDto>(labResult);
        }

        public async Task<LabResultDto> UpdateLabResultAsync(int id, LabResultDto dto)
        {
            var existingLabResult = await _repository.GetByIdAsync(id);
            if (existingLabResult == null)
                throw new KeyNotFoundException("Kết quả xét nghiệm không tồn tại.");

            _mapper.Map(dto, existingLabResult);

            existingLabResult.UpdatedDate = DateTime.UtcNow;
            existingLabResult.UpdatedBy = int.Parse(_tokenRepository.GetUserIdFromToken());
            await _repository.UpdateAsync(existingLabResult);

            return _mapper.Map<LabResultDto>(existingLabResult);
        }

        public async Task DeleteLabResultAsync(int id)
        {
            var labResult = await _repository.GetByIdAsync(id);
            if (labResult == null)
                throw new KeyNotFoundException("Kết quả xét nghiệm không tồn tại.");
            await _repository.DeleteAsync(id);
        }
    }
}
