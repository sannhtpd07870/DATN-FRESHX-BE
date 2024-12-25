using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos;

namespace Freshx_API.Interfaces
{
    public interface IMedicalServiceRequestService
    {
        Task<MedicalServiceRequestDto?> GetByIdAsync(int id);
        Task<IEnumerable<MedicalServiceRequestDto>> GetAllAsync();
        Task AddAsync(MedicalServiceRequestDto dto);
        Task UpdateAsync(MedicalServiceRequestDto dto);
        Task DeleteAsync(int id);
    }

}
