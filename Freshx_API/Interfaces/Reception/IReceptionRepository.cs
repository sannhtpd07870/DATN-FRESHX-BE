using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Reception;
using Freshx_API.Models;

namespace Freshx_API.Interfaces
{
    public interface IReceptionRepository
    {
        public Task<Reception?> CreateReceptionAsync(AddingReceptionRequest addingReceptionRequest);
        public Task<Reception?> UpdateReceptionAsync(int id,UpdatingReceptionRequest addingReceptionRequest);
        public Task<Reception?> GetReceptionByIdAsync(int id);
        public Task<Reception?> DeleteReceptionByIdAsync(int id);
        public Task<CustomPageResponse<IEnumerable<Reception?>>> GetReceptionsAsync(PaginationParameters paginationParameters);
    }
}
