using Freshx_API.Dtos.LabResult;
using Freshx_API.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freshx_API.Interfaces.Services
{
    public interface ILabResultService
    {
        Task<LabResultDto> GetLabResultByIdAsync(int id);
        Task<IEnumerable<LabResultDto>> GetAllLabResultsAsync(string? searchKeyword, DateTime? createdDate, DateTime? updatedDate);
        Task<LabResultDto> CreateLabResultAsync(LabResultDto labResultDto);
        Task<LabResultDto> UpdateLabResultAsync(int id, LabResultDto labResultDto);
        Task DeleteLabResultAsync(int id);
    }
}
