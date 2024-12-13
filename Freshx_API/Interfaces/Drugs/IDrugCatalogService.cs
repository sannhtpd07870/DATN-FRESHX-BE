using System.Threading.Tasks;
using Freshx_API.Dtos;
using Freshx_API.Dtos.CommonDtos;

namespace Freshx_API.Services
{
    public interface IDrugCatalogService
    {
        Task<ApiResponse<DrugCatalogDto>> GetDrugCatalogById(int id);
        Task<ApiResponse<IEnumerable<DrugCatalogDto>>> GetAllDrugCatalogs();
        Task<ApiResponse<bool>> CreateDrugCatalog(CreateDrugCatalogDto drugCatalogDto);
        Task<ApiResponse<bool>> UpdateDrugCatalog(int id, DrugCatalogDto drugCatalogDto);
        Task<ApiResponse<bool>> DeleteDrugCatalog(int id);
    }
}