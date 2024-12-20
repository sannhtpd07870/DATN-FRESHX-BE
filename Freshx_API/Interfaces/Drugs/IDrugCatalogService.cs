using System.Threading.Tasks;
using Freshx_API.Dtos;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.DrugCatalog;

namespace Freshx_API.Services
{
    public interface IDrugCatalogService
    {
        Task<ApiResponse<DrugCatalogDetailDto>> GetDrugCatalogById(int id);
        Task<ApiResponse<IEnumerable<DrugCatalogDetailDto>>> GetAllDrugCatalogs();
        Task<ApiResponse<bool>> CreateDrugCatalog(CreateDrugCatalogDetailDto DrugCatalogDetailDto);
        Task<ApiResponse<bool>> UpdateDrugCatalog(int id, DrugCatalogDetailDto DrugCatalogDetailDto);
        Task<ApiResponse<bool>> DeleteDrugCatalog(int id);
    }
}