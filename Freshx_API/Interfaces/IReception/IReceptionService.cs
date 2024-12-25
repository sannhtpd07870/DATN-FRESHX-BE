using Freshx_API.Dtos;

namespace Freshx_API.Interfaces.IReception
{
    public interface IReceptionService
    {
        Task<CreateReceptionDto?> GetByIdAsync(int id);
        Task<IEnumerable<CreateReceptionDto>> GetAllAsync();
        Task AddAsync(CreateReceptionDto dto);
        Task UpdateAsync(CreateReceptionDto dto);
        Task DeleteAsync(int id);
    }

}
