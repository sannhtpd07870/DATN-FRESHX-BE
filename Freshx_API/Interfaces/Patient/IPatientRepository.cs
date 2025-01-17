using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Patient;
using Freshx_API.Models;

namespace Freshx_API.Interfaces
{
    public interface IPatientRepository
    {
        public Task<Patient?> CreatePatientAsync(AddingPatientRequest addingPatientRequest);
        public Task<Patient?> UpdatePatientByIdAsync(int id, UpdatingPatientRequest updatingPatientRequest);
        public Task<Patient?> GetPatientByIdAsync(int id);
        public Task<List<PatientResponseDto?>> GetPatientsAsync(Parameters parameters);
        public Task<Patient?> DeletePatientByIdAsync(int id);
        public Task<PatientHistoryDto> GetPatientHistory(int id, string? keyword = null, DateTime? startDate = null, DateTime? endDate = null);
    }
}
