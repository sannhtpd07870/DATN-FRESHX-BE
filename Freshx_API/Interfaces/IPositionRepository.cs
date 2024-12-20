using Freshx_API.Dtos;
using Freshx_API.Models;

namespace Freshx_API.Interfaces
{
    public interface IPositionRepository
    {
        public Task<List<Position>> GetPositionsAsync();
        public Task<Position?> CreatePositionAsync(AddingPositionRequest addingPositionRequest);
        public Task<Position?> GetPositionByIdAsync(int id);
    }
}
