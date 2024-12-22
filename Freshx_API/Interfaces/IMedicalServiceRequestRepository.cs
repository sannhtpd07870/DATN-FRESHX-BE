using Freshx_API.Models;

namespace Freshx_API.Interfaces
{
    public interface IMedicalServiceRequestRepository
    {
        Task<IEnumerable<MedicalServiceRequest>> GetAllAsync();
        Task<MedicalServiceRequest> GetByIdAsync(int id);
        Task<IEnumerable<MedicalServiceRequest>> GetByReceptionIdAsync(int receptionId);
        Task<MedicalServiceRequest> CreateAsync(MedicalServiceRequest request);
        Task UpdateAsync(MedicalServiceRequest request);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<string> GenerateRequestNumber();
    }
}
