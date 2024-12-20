using AutoMapper;
using Freshx_API.Dtos.Receptionist;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Interfaces;
using Freshx_API.Models;

namespace Freshx_API.Services
{
    public class ReceptionistService
    {
        private readonly IReceptionistRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;

        public ReceptionistService(IReceptionistRepository repository, IMapper mapper, ITokenRepository tokenRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
        }

        // Lấy danh sách nhân viên lễ tân với các bộ lọc
        public async Task<IEnumerable<ReceptionistDto>> GetAllAsync(string? searchKeyword,
            DateTime? createdDate, DateTime? updatedDate, int? status)
        {
            var entities = await _repository.GetAllAsync(searchKeyword, createdDate, updatedDate, status);

            // Kiểm tra trạng thái IsSuspended và cập nhật tên nếu cần thiết
            foreach (var receptionist in entities.ToList())
            {
                if (receptionist.IsSuspended == 1)
                {
                    receptionist.Name = receptionist.Name + " (Tạm ngưng hoạt động)";
                }
            }

            // Sử dụng AutoMapper để chuyển đổi từ Model sang DTO
            return _mapper.Map<IEnumerable<ReceptionistDto>>(entities);
        }

        public async Task<IEnumerable<ReceptionistDetailDto>> GetDetailAllAsync(string? searchKeyword,
          DateTime? createdDate, DateTime? updatedDate, int? status)
        {
            var entities = await _repository.GetAllAsync(searchKeyword, createdDate, updatedDate, status);

            // Kiểm tra trạng thái IsSuspended và cập nhật tên nếu cần thiết
            foreach (var receptionist in entities.ToList())
            {
                if (receptionist.IsSuspended == 1)
                {
                    receptionist.Name = receptionist.Name + " (Tạm ngưng hoạt động)";
                }
            }

            // Sử dụng AutoMapper để chuyển đổi từ Model sang DTO
            return _mapper.Map<IEnumerable<ReceptionistDetailDto>>(entities);
        }

        // Lấy nhân viên lễ tân theo ID
        public async Task<ReceptionistDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null) return null;

            // Kiểm tra trạng thái tạm ngưng và cập nhật tên nếu cần thiết
            if (entity.IsSuspended == 1)
            {
                entity.Name = entity.Name + " (Tạm ngưng hoạt động)";
            }

            return _mapper.Map<ReceptionistDto>(entity);
        }

        // Tạo mới nhân viên lễ tân
        public async Task<ReceptionistDto> CreateAsync(ReceptionistCreateUpdateDto dto)
        {
            var entity = _mapper.Map<Receptionist>(dto);

            // Thiết lập giá trị mặc định
            entity.IsDeleted = 0;
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = _tokenRepository.GetUserIdFromToken();

            var createdEntity = await _repository.CreateAsync(entity);

            return _mapper.Map<ReceptionistDto>(createdEntity);
        }

        // Cập nhật thông tin nhân viên lễ tân
        public async Task UpdateAsync(int id, ReceptionistCreateUpdateDto dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);

            if (existingEntity == null)
                throw new KeyNotFoundException("Nhân viên lễ tân không tồn tại.");

            // Sử dụng AutoMapper để cập nhật dữ liệu từ DTO sang Entity
            _mapper.Map(dto, existingEntity);

            existingEntity.UpdatedDate = DateTime.UtcNow;
            existingEntity.UpdatedBy = _tokenRepository.GetUserIdFromToken();

            await _repository.UpdateAsync(existingEntity);
        }

        // Xóa mềm nhân viên lễ tân
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                throw new KeyNotFoundException("Nhân viên lễ tân không tồn tại.");

            await _repository.DeleteAsync(id);
        }

        // Kiểm tra trạng thái tạm ngưng
        public async Task<bool> IsSuspendedAsync(int id)
        {
            return await _repository.IsSuspendedAsync(id);
        }
    }
}
