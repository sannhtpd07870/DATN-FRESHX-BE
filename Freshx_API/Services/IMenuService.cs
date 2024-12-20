using Freshx_API.Dtos.Menu;

namespace Freshx_API.Services
{
    public interface IMenuService
    {
        Task<List<MenuDto>> GetMenusAsync(string? searchKey = null);
        Task<MenuDto> GetMenuByIdAsync(int menuId);
    }

}
