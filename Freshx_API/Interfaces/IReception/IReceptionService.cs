using Freshx_API.Dtos;
using Freshx_API.Dtos.Patient;

namespace Freshx_API.Interfaces.IReception
{
    public interface IReceptionService
    {
        Task<ReceptionDto?> GetByIdAsync(int id);
        Task<IEnumerable<ReceptionDto>> GetAllAsync();
        Task<ReceptionDto> AddAsync(CreateReceptionDto dto);
        Task UpdateAsync(CreateReceptionDto dto);
        Task DeleteAsync(int id);
        Task<ExamineHistoryDto> GetPatientHistory(int receptionId);
        Task<List<ListReceptionDto>> GetListLabResult(string? searchKey, bool isHistory);
        Task<List<ListReceptionDto>> GetListExamine(string? searchKey, bool isHistory);
    }
}
