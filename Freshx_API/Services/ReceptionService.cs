using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Interfaces.IReception;
using Freshx_API.Models;

namespace Freshx_API.Services
{
    public class ReceptionService : IReceptionService
    {
        private readonly IReceptionRepository _repository;
        private readonly IMapper _mapper;

        public ReceptionService(IReceptionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateReceptionDto?> GetByIdAsync(int id)
        {
            var reception = await _repository.GetByIdAsync(id);
            return _mapper.Map<CreateReceptionDto>(reception);
        }

        public async Task<IEnumerable<CreateReceptionDto>> GetAllAsync()
        {
            var receptions = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CreateReceptionDto>>(receptions);
        }

        public async Task AddAsync(CreateReceptionDto dto)
        {
            var reception = _mapper.Map<Reception>(dto);

            // Ánh x? các MedicalServiceRequests (n?u có)
            if (dto.MedicalServiceRequests != null)
            {
                reception.MedicalServiceRequest = _mapper.Map<List<MedicalServiceRequest>>(dto.MedicalServiceRequests);
            }

            await _repository.AddAsync(reception);
        }

        public async Task UpdateAsync(CreateReceptionDto dto)
        {
            var reception = _mapper.Map<Reception>(dto);

            // C?p nh?t MedicalServiceRequests
            if (dto.MedicalServiceRequests != null)
            {
                reception.MedicalServiceRequest = _mapper.Map<List<MedicalServiceRequest>>(dto.MedicalServiceRequests);
            }

            await _repository.UpdateAsync(reception);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}