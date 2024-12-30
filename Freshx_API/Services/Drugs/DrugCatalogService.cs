using AutoMapper;
using Freshx_API.Models;
using Freshx_API.Dtos;
using Freshx_API.Interfaces;
using Freshx_API.Dtos.DrugCatalog;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Dtos.Country;
using Freshx_API.Dtos.Supplier;
using Freshx_API.Dtos.UnitOfMeasure;
using Freshx_API.Dtos.Drugs;

namespace Freshx_API.Services.Drugs
{
    public class DrugCatalogService
    {
        private readonly IDrugCatalogRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;

        public DrugCatalogService(IDrugCatalogRepository repository, IMapper mapper, ITokenRepository tokenRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
        }

        // Lấy danh sách danh mục thuốc với các bộ lọc
        public async Task<IEnumerable<DrugCatalogDetailDto>> GetAllAsync(string? searchKeyword,
            DateTime? createdDate, DateTime? updatedDate, int? status)
        {
            var entities = await _repository.GetAllAsync(searchKeyword, createdDate, updatedDate, status);
            // Sử dụng AutoMapper để chuyển đổi từ Model sang DTO
            return _mapper.Map<IEnumerable<DrugCatalogDetailDto>>(entities);
        }

        // Lấy danh mục thuốc theo ID
        public async Task<DrugCatalogDetailDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;
            return _mapper.Map<DrugCatalogDetailDto>(entity);
        }

        // Cập nhật danh mục thuốc

        public async Task<DrugCatalogDetailDto> UpdateAsync(DrugCatalogCreateUpdateDto dto, int id)
        {
            // Lấy đối tượng DrugCatalog từ repository
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new InvalidOperationException("Danh mục thuốc không tồn tại.");
            }

            // Cập nhật thông tin của entity từ dto
            _mapper.Map(dto, entity);

            // Cập nhật ngày sửa đổi và người sửa
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = _tokenRepository.GetUserIdFromToken();

            // Cập nhật trong database
            await _repository.UpdateAsync(entity);

            // Trả về đối tượng đã cập nhật dưới dạng DTO
            return _mapper.Map<DrugCatalogDetailDto>(entity);
        }


        // Tạo mới danh mục thuốc
        public async Task<DrugCatalogDetailDto> CreateAsync(DrugCatalogCreateUpdateDto dto)
        {
            // Kiểm tra sự tồn tại của các đối tượng liên quan
            if (dto.UnitOfMeasureId.HasValue && !await _repository.UnitOfMeasureExistsAsync(dto.UnitOfMeasureId.Value))
            {
                throw new InvalidOperationException("Đơn vị đo lường không tồn tại.");
            }

            if (dto.ManufacturerId.HasValue && !await _repository.ManufacturerExistsAsync(dto.ManufacturerId.Value))
            {
                throw new InvalidOperationException("Nhà sản xuất không tồn tại.");
            }

            if (dto.CountryId.HasValue && !await _repository.CountryExistsAsync(dto.CountryId.Value))
            {
                throw new InvalidOperationException("Quốc gia không tồn tại.");
            }

            if (dto.DrugTypeId.HasValue && !await _repository.DrugTypeExistsAsync(dto.DrugTypeId.Value))
            {
                throw new InvalidOperationException("Loại thuốc không tồn tại.");
            }

            // Tiếp tục tạo mới danh mục thuốc
            string code = GenerateUniqueCode();
            var entity = _mapper.Map<DrugCatalog>(dto);

            entity.Code = code;
            entity.IsDeleted = 0;
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = _tokenRepository.GetUserIdFromToken();

            var createdEntity = await _repository.CreateAsync(entity);
            return _mapper.Map<DrugCatalogDetailDto>(createdEntity);
        }





        // Xóa mềm danh mục thuốc
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Danh mục thuốc không tồn tại.");
            await _repository.DeleteAsync(id);
        }
        // Lấy nhà sản xuất theo ID
        public async Task<SupplierDetailDto?> GetManufacturerByIdAsync(int? manufacturerId)
        {
            var manufacturer = await _repository.GetManufacturerByIdAsync(manufacturerId);
            if (manufacturer == null) return null;
            return _mapper.Map<SupplierDetailDto>(manufacturer);
        }

        // Lấy đơn vị đo lường theo ID
        public async Task<UnitOfMeasureDetailDto?> GetUnitOfMeasureByIdAsync(int? unitOfMeasureId)
        {
            var unitOfMeasure = await _repository.GetUnitOfMeasureByIdAsync(unitOfMeasureId);
            if (unitOfMeasure == null) return null;
            return _mapper.Map<UnitOfMeasureDetailDto>(unitOfMeasure);
        }

        // Lấy quốc gia theo ID
        public async Task<CountryDto?> GetCountryByIdAsync(int? countryId)
        {
            var country = await _repository.GetCountryByIdAsync(countryId);
            if (country == null) return null;
            return _mapper.Map<CountryDto>(country);
        }

        // Lấy loại thuốc theo ID
        public async Task<DrugTypeDto?> GetDrugTypeByIdAsync(int? drugTypeId)
        {
            var drugType = await _repository.GetDrugTypeByIdAsync(drugTypeId);
            if (drugType == null) return null;
            return _mapper.Map<DrugTypeDto>(drugType);
        }

        private string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(); // Mã gồm 8 ký tự
        }

        public async Task<DrugTypeDto?> GetNameAsync(string name)
        {
            var entity = await _repository.GetNameAsync(name);
            if (entity == null)
                return null;
            return _mapper.Map<DrugTypeDto>(entity);
        }
    }
}
