using Freshx_API.Models;

namespace Freshx_API.Interfaces
{
    public interface IMedicalServiceRequestRepository
    {
        Task<MedicalServiceRequest?> GetByIdAsync(int id);
        Task<IEnumerable<MedicalServiceRequest>> GetAllAsync();
        Task AddAsync(MedicalServiceRequest entity);
        Task UpdateAsync(MedicalServiceRequest entity);
        Task DeleteAsync(int id);
    }

}
