using Freshx_API.Models;

namespace Freshx_API.Interfaces.Payment
{
    public interface IMedicalServiceRequestRepository
    {
        Task<MedicalServiceRequest> CreateMedicalServiceRequestAsync(MedicalServiceRequest medicalServiceRequest);
        Task<IEnumerable<MedicalServiceRequest>> GetRequestsByInvoiceIdAsync(int invoiceId);
    }

}
