using Freshx_API.Dtos.MedicalHistory;
using Freshx_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freshx_API.Interfaces
{
    public interface IMedicalHistoryRepository
    {
        Task<IEnumerable<MedicalHistoryDto>> GetAllAsync(string? searchKeyword = null); // Accept search keyword
        Task<MedicalHistoryDto?> GetByIdAsync(int id);
        Task<MedicalHistoryDto> CreateAsync(MedicalHistoryCreateUpdateDto dto);
        Task<MedicalHistoryDto> UpdateAsync(int id, MedicalHistoryCreateUpdateDto dto);
        Task<bool> DeleteAsync(int id); // Add DeleteAsync method
    }
}
