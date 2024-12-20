using AutoMapper;
using Freshx_API.Dtos.Pharmacy;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Interfaces;
using Freshx_API.Models;

namespace Freshx_API.Services
{
    public class PharmacyService
    {
        private readonly IPharmacyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;

        public PharmacyService(IPharmacyRepository repository, IMapper mapper, ITokenRepository tokenRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
        }

        // Lấy danh sách nhà thuốc với các bộ lọc
        public async Task<IEnumerable<PharmacyDto>> GetAllAsync(string? searchKeyword,
            DateTime? createdDate, DateTime? updatedDate, bool? isSuspended, int? inventoryTypeId, int? specialtyId)
        {
            var entities = await _repository.GetAllAsync(searchKeyword, createdDate, updatedDate, isSuspended, inventoryTypeId, specialtyId);
            return _mapper.Map<IEnumerable<PharmacyDto>>(entities);
        }

        // Lấy danh sách nhà thuốc với các bộ lọc
        public async Task<IEnumerable<PharmacyDetailDto>> GetDetailAllAsync(string? searchKeyword,
            DateTime? createdDate, DateTime? updatedDate, bool? isSuspended, int? inventoryTypeId, int? specialtyId)
        {
            var entities = await _repository.GetAllAsync(searchKeyword, createdDate, updatedDate, isSuspended, inventoryTypeId, specialtyId);
            return _mapper.Map<IEnumerable<PharmacyDetailDto>>(entities);
        }

        // Lấy nhà thuốc theo ID
        public async Task<PharmacyDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null || entity.IsDeleted == 1)
                return null;

            return _mapper.Map<PharmacyDto>(entity);
        }

        // Tạo mới nhà thuốc
        public async Task<PharmacyDto> CreateAsync(PharmacyCreateUpdateDto dto)
        {
            var inventoryType = await _repository.GetInventoryTypeByIdAsync(dto.InventoryTypeId);

            if (inventoryType == null)
            {
                throw new Exception("InventoryType không hợp lệ.");
            }

            var entity = _mapper.Map<Pharmacy>(dto);

            entity.IsDeleted = 0;
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = _tokenRepository.GetUserIdFromToken();

            var createdEntity = await _repository.CreateAsync(entity);

            return _mapper.Map<PharmacyDto>(createdEntity);
        }

        // Cập nhật nhà thuốc
        public async Task UpdateAsync(int id, PharmacyCreateUpdateDto dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);

            if (existingEntity == null || existingEntity.IsDeleted == 1)
                throw new KeyNotFoundException("Nhà thuốc không tồn tại.");

            var inventoryType = await _repository.GetInventoryTypeByIdAsync(dto.InventoryTypeId);

            if (inventoryType == null)
            {
                throw new Exception("InventoryType không hợp lệ.");
            }

            _mapper.Map(dto, existingEntity);

            existingEntity.UpdatedDate = DateTime.UtcNow;
            existingEntity.UpdatedBy = _tokenRepository.GetUserIdFromToken();

            await _repository.UpdateAsync(existingEntity);
        }

        // Xóa mềm nhà thuốc
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null || entity.IsDeleted == 1)
                throw new KeyNotFoundException("Nhà thuốc không tồn tại.");

            entity.IsDeleted = 1;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = _tokenRepository.GetUserIdFromToken();

            await _repository.UpdateAsync(entity);
        }
    }
}
