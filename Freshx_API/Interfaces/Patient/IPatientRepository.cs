using Freshx_API.Dtos.Patient;
using Freshx_API.Models;

namespace Freshx_API.Interfaces
{
    public interface IPatientRepository
    {
        public Task<Patient?> CreatePatientAsync(AddingPatientRequest addingPatientRequest);
      //  public Task<Patient?> UpdatePatientByIdAsync(int id, UpdatingPatientRequest updatingProductDto);
       // public Task<Product?> GetProductByIdAsync(int id);
        //public Task<List<Product>?> GetProductsAsync();
        //public Task<Product?> DeleteProductByIdAsync(int id);
    }
}
