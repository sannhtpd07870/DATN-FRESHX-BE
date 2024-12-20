using AutoMapper;
using Freshx_API.Dtos.InventoryType;
using Freshx_API.Interfaces;
using Freshx_API.Models;

namespace Freshx_API.Services
{
    public class InventoryTypeService
    {
        private readonly IInventoryTypeRepository _repository;
        private readonly IMapper _mapper;

        public InventoryTypeService(IInventoryTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Lấy danh sách tất cả loại tồn kho
        public async Task<IEnumerable<InventoryTypeDto>> GetAllAsync(string? searchKeyword = null)
        {
            var entities = await _repository.GetAllAsync(searchKeyword);
            return _mapper.Map<IEnumerable<InventoryTypeDto>>(entities);
        }

        // Lấy thông tin loại tồn kho theo ID
        public async Task<InventoryTypeDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<InventoryTypeDto>(entity);
        }

        // Tạo mới loại tồn kho
        public async Task<InventoryTypeDto> CreateAsync(InventoryTypeCreateUpdateDto dto)
        {
            var entity = _mapper.Map<InventoryType>(dto);
            var createdEntity = await _repository.CreateAsync(entity);
            return _mapper.Map<InventoryTypeDto>(createdEntity);
        }

        // Cập nhật loại tồn kho
        public async Task<bool> UpdateAsync(int id, InventoryTypeCreateUpdateDto dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null) return false;

            _mapper.Map(dto, existingEntity);
            await _repository.UpdateAsync(existingEntity);
            return true;
        }

        // Xóa loại tồn kho
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
