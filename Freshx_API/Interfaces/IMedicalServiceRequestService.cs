using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos;

namespace Freshx_API.Interfaces
{
    public interface IMedicalServiceRequestService
    {
        Task<ApiResponse<IEnumerable<MedicalServiceRequestDTO>>> GetAllAsync();
        Task<ApiResponse<MedicalServiceRequestDTO>> GetByIdAsync(int id);
        Task<ApiResponse<MedicalServiceRequestDTO>> CreateAsync(CreateMedicalServiceRequestDTO createDto);
        Task<ApiResponse<MedicalServiceRequestDTO>> UpdateAsync(int id, UpdateMedicalServiceRequestDTO updateDto);
        Task<ApiResponse<bool>> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<MedicalServiceRequestDTO>>> GetByReceptionIdAsync(int receptionId);
    }
}
