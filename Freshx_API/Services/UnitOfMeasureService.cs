using AutoMapper;
using Freshx_API.Dtos.UnitOfMeasure;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Interfaces;
using Freshx_API.Models;

namespace Freshx_API.Services
{
    public class UnitOfMeasureService
    {
        private readonly IUnitOfMeasureRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;

        public UnitOfMeasureService(IUnitOfMeasureRepository repository, IMapper mapper, ITokenRepository tokenRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
        }

        // Lấy danh sách đơn vị đo lường
        public async Task<IEnumerable<UnitOfMeasureDetailDto>> GetAllAsync(
            string? searchKeyword,
            DateTime? createdDate,
            DateTime? updatedDate,
            int? isSuspended,
            int? isDeleted)
        {
            var entities = await _repository.GetAllAsync(
                searchKeyword, createdDate, updatedDate, isSuspended, isDeleted);
            return _mapper.Map<IEnumerable<UnitOfMeasureDetailDto>>(entities);
        }

        // Lấy danh sách chi tiết đơn vị đo lường
        public async Task<IEnumerable<UnitOfMeasureDetailDto>> GetAllDetailAsync(
            string? searchKeyword,
            DateTime? createdDate,
            DateTime? updatedDate,
            int? isSuspended,
            int? isDeleted)
        {
            var entities = await _repository.GetAllAsync(
                searchKeyword, createdDate, updatedDate, isSuspended, isDeleted);
            return _mapper.Map<IEnumerable<UnitOfMeasureDetailDto>>(entities);
        }

        // Lấy thông tin đơn vị đo lường theo ID
        public async Task<UnitOfMeasureDetailDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return null;
            return _mapper.Map<UnitOfMeasureDetailDto>(entity);
        }

        // Tạo mới đơn vị đo lường
        public async Task<UnitOfMeasureDetailDto> CreateAsync(UnitOfMeasureCreateUpdateDto dto)
        {
            var entity = _mapper.Map<UnitOfMeasure>(dto);
            entity.IsDeleted = 0;
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = _tokenRepository.GetUserIdFromToken();
            var createdEntity = await _repository.CreateAsync(entity);
            return _mapper.Map<UnitOfMeasureDetailDto>(createdEntity);
        }

        // Cập nhật đơn vị đo lường
        public async Task UpdateAsync(int id, UnitOfMeasureCreateUpdateDto dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
                throw new KeyNotFoundException("Đơn vị đo lường không tồn tại.");
            _mapper.Map(dto, existingEntity);
            existingEntity.UpdatedDate = DateTime.UtcNow;
            existingEntity.UpdatedBy = _tokenRepository.GetUserIdFromToken();
            await _repository.UpdateAsync(existingEntity);
        }

        // Xóa mềm đơn vị đo lường
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Đơn vị đo lường không tồn tại.");
            await _repository.DeleteAsync(id);
        }
    }
}
