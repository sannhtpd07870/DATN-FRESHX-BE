﻿using AutoMapper;
using Freshx_API.Dtos.ServiceCatalog;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Interfaces;
using Freshx_API.Models;

namespace Freshx_API.Services
{
    public class ServiceCatalogService
    {
        private readonly IServiceCatalogRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;

        public ServiceCatalogService(IServiceCatalogRepository repository, IMapper mapper, ITokenRepository tokenRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
        }

        // Lấy danh sách dịch vụ với các bộ lọc
        public async Task<IEnumerable<ServiceCatalogDto>> GetAllAsync(string? searchKeyword,
            DateTime? createdDate, DateTime? updatedDate, int? status)
        {
            var entities = await _repository.GetAllAsync(searchKeyword, createdDate, updatedDate, status);

            // Kiểm tra trạng thái trước khi trả về danh sách
            foreach (var service in entities.ToList())
            {
                if (service.IsSuspended != 0)
                {
                    service.Name = service.Name + " (Tạm ngưng hoạt động)";
                }
            }

            // Sử dụng AutoMapper để chuyển đổi từ Model sang DTO
            return _mapper.Map<IEnumerable<ServiceCatalogDto>>(entities);
        }

        // Lấy thông tin chi tiết dịch vụ theo ID
        public async Task<ServiceCatalogDetailDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                return null;

            if (entity.IsSuspended != 0)
            {
                entity.Name = entity.Name + " (Tạm ngưng hoạt động)";
            }

            return _mapper.Map<ServiceCatalogDetailDto>(entity);
        }

        // Tạo mới dịch vụ
        public async Task<ServiceCatalogDto> CreateAsync(ServiceCatalogCreateUpdateDto dto)
        {
            var entity = _mapper.Map<ServiceCatalog>(dto);

            // Thiết lập giá trị mặc định
            entity.IsDeleted = 0;
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = _tokenRepository.GetUserIdFromToken();

            if (entity.IsSuspended != 0)
            {
                entity.Name += " (Tạm ngưng hoạt động)";
            }

            var createdEntity = await _repository.CreateAsync(entity);
            return _mapper.Map<ServiceCatalogDto>(createdEntity);
        }

        // Cập nhật dịch vụ
        public async Task UpdateAsync(int id, ServiceCatalogCreateUpdateDto dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);

            if (existingEntity == null)
                throw new KeyNotFoundException("Dịch vụ không tồn tại.");

            // Sử dụng AutoMapper để cập nhật dữ liệu từ DTO sang Entity
            _mapper.Map(dto, existingEntity);

            existingEntity.UpdatedDate = DateTime.UtcNow;
            existingEntity.UpdatedBy = _tokenRepository.GetUserIdFromToken();

            if (existingEntity.IsSuspended != 0)
            {
                existingEntity.Name += " (Tạm ngưng hoạt động)";
            }

            await _repository.UpdateAsync(existingEntity);
        }

        // Xóa mềm dịch vụ
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                throw new KeyNotFoundException("Dịch vụ không tồn tại.");

            await _repository.DeleteAsync(id);
        }

        // Kiểm tra trạng thái hoạt động của dịch vụ theo ID
        public async Task<bool> CheckStatusByIdAsync(int id)
        {
            return await _repository.CheckStatusByIdAsync(id);
        }
    }
}
