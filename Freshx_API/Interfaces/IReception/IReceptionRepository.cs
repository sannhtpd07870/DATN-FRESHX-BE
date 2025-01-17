using Freshx_API.Dtos;
using Freshx_API.Models;

namespace Freshx_API.Interfaces.IReception
{
    public interface IReceptionRepository
    {
        Task<Reception?> GetByIdAsync(int id);
        Task<IEnumerable<Reception>> GetAllAsync();
        Task<Reception?> AddAsync(Reception reception);
        Task UpdateAsync(Reception reception);
        Task DeleteAsync(int id);
        Task<ExamineHistoryDto> GetPatientHistory(int receptionId);
        Task<List<ExamineHistoryDto>> GetListExamine(string? searchKey, bool isHistory);
        Task<List<ListReceptionDto>> GetListLabResult(string? searchKey, bool isHistory);
    }

}
