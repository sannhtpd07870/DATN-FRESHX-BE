using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Interfaces;
using Freshx_API.Models;
using Freshx_API.Services.CommonServices;
using NuGet.Protocol.Core.Types;

namespace Freshx_API.Services
{
    public class MedicalServiceRequestService : IMedicalServiceRequestService
    {
        private readonly IMedicalServiceRequestRepository _repository;
        private readonly IMapper _mapper;

        public MedicalServiceRequestService(IMedicalServiceRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MedicalServiceRequestDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<MedicalServiceRequestDto>(entity);
        }

        public async Task<IEnumerable<MedicalServiceRequestDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MedicalServiceRequestDto>>(entities);
        }

        public async Task AddAsync(MedicalServiceRequestDto dto)
        {
            var entity = _mapper.Map<MedicalServiceRequest>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(MedicalServiceRequestDto dto)
        {
            var entity = _mapper.Map<MedicalServiceRequest>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }


}
