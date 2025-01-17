using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Interfaces;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Models;
using Freshx_API.Services.CommonServices;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace Freshx_API.Services
{

    public class MedicalServiceRequestService : IMedicalServiceRequestService
    {
        private readonly IMedicalServiceRequestRepository _repository;
        private readonly IMapper _mapper;
        private readonly FreshxDBContext _context;

        public MedicalServiceRequestService(IMedicalServiceRequestRepository repository, IMapper mapper, FreshxDBContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<MedicalServiceRequestDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<MedicalServiceRequestDto>(entity);
        }

        public async Task<IEnumerable<MedicalServiceRequestDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            Console.WriteLine(entities);
            return _mapper.Map<IEnumerable<MedicalServiceRequestDto>>(entities);
        }

        public async Task<MedicalServiceRequestDto> AddAsync(CreateMedicalServiceRequestDto medicalServiceRequestDto)
        {
            var entity = _mapper.Map<MedicalServiceRequest>(medicalServiceRequestDto);
            entity.RequestTime = DateTime.Now;
            entity.CreatedDate = DateTime.Now;
            entity.IsDeleted = 0;
            entity.IsApproved = true;
            entity.Status = false;
            var result = await _repository.AddAsync(entity);
            return _mapper.Map<MedicalServiceRequestDto>(result);
        }

        public async Task<MedicalServiceRequestDto> UpdateAsync(int Id, UpdateMedicalServiceRequestDto medicalServiceRequestDto)
        {
            var existingRequest = await _repository.GetByIdAsync(Id) ?? 
                throw new FileNotFoundException($"Mã yêu cầu {Id} không tồn tại");
            existingRequest.UpdatedDate = DateTime.Now;
            existingRequest.RequestTime = DateTime.Now;
            var entity = _mapper.Map(medicalServiceRequestDto, existingRequest);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<MedicalServiceRequestDto>(result);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }



}
