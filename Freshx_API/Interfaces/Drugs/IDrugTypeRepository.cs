using System.Threading.Tasks;
using Freshx_API.Models;

public interface IDrugTypeRepository
{
    Task<List<DrugType?>> GetDrugTypeAsync();
    Task<DrugType?> GetDrugTypeByIdAsync(int id);
    Task<DrugType> CreateDrugTypeAsync(DrugType drugType);
    Task<DrugType?> UpdateDrugTypeAsync(DrugType drugType);
    Task<bool> DeleteDrugTypeAsync(int id);
}
