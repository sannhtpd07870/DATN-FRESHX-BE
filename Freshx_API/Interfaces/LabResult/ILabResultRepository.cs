using Freshx_API.Models;

namespace Freshx_API.Interfaces.LabResultRepository
{
    public interface ILabResultRepository
    {
        Task<LabResult> GetByIdAsync(int id);
        Task<IEnumerable<LabResult>> GetAllAsync();
        Task AddAsync(LabResult labResult);
        Task UpdateAsync(LabResult labResult);
        Task DeleteAsync(int id);
    }
}