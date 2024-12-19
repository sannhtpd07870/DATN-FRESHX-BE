using AutoMapper;
using Freshx_API.Dtos.ServiceGroup;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Interfaces;
using Freshx_API.Models;

namespace Freshx_API.Services
{
    public class ServiceGroupService
    {
        private readonly IServiceGroupRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;

        public ServiceGroupService(IServiceGroupRepository repository, IMapper mapper, ITokenRepository tokenRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
        }

        // Lấy danh sách nhóm dịch vụ với các bộ lọc
        public async Task<IEnumerable<ServiceGroupDto>> GetAllAsync(string? searchKeyword,
            DateTime? createdDate, DateTime? updatedDate, int? status)
        {
            var entities = await _repository.GetAllAsync(searchKeyword, createdDate, updatedDate, status);

            // Sử dụng AutoMapper để chuyển đổi từ Model sang DTO
            return _mapper.Map<IEnumerable<ServiceGroupDto>>(entities);
        }

        // Lấy danh sách nhóm dịch vụ chi tiết với các bộ lọc
        public async Task<IEnumerable<ServiceGroupDetailDto>> GetDetailAllAsync(string? searchKeyword,
            DateTime? createdDate, DateTime? updatedDate, int? status)
        {
            var entities = await _repository.GetAllAsync(searchKeyword, createdDate, updatedDate, status);

            // Sử dụng AutoMapper để chuyển đổi từ Model sang DTO
            return _mapper.Map<IEnumerable<ServiceGroupDetailDto>>(entities);
        }

        // Lấy nhóm dịch vụ theo ID
        public async Task<ServiceGroupDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null) return null;

            return _mapper.Map<ServiceGroupDto>(entity);
        }

        // Tạo mới nhóm dịch vụ
        public async Task<ServiceGroupDto> CreateAsync(ServiceGroupCreateUpdateDto dto)
        {
            // Kiểm tra nếu nhóm dịch vụ đã tồn tại (nếu cần)
            var existingEntity = await _repository.GetByNameAsync(dto.Name);
            if (existingEntity != null)
            {
                throw new Exception("Nhóm dịch vụ đã tồn tại.");
            }

            var entity = _mapper.Map<ServiceGroup>(dto);

            // Thiết lập giá trị mặc định
            entity.IsDeleted = 0;
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = _tokenRepository.GetUserIdFromToken();

            var createdEntity = await _repository.CreateAsync(entity);

            return _mapper.Map<ServiceGroupDto>(createdEntity);
        }

        // Cập nhật nhóm dịch vụ
        public async Task UpdateAsync(int id, ServiceGroupCreateUpdateDto dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);

            if (existingEntity == null)
                throw new KeyNotFoundException("Nhóm dịch vụ không tồn tại.");

            // Sử dụng AutoMapper để cập nhật dữ liệu từ DTO sang Entity
            _mapper.Map(dto, existingEntity);

            existingEntity.UpdatedDate = DateTime.UtcNow;
            existingEntity.UpdatedBy = _tokenRepository.GetUserIdFromToken();

            await _repository.UpdateAsync(existingEntity);
        }

        // Xóa mềm nhóm dịch vụ
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                throw new KeyNotFoundException("Nhóm dịch vụ không tồn tại.");

            await _repository.DeleteAsync(id);
        }

    }
}
