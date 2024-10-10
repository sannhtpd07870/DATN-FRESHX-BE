    using Freshx_API.Dtos;
using Freshx_API.Models;

namespace Freshx_API.Interfaces
{
    public interface IFilesRepository
    {
        Task<Savefile> CreateFile(FileDto fileDto);
        Task<Savefile> GetFileById(int id);
        Task<List<Savefile>> GetAllFiles();
        Task<bool> DeleteFile(int id);
        // Thêm phương thức mới
        Task<Savefile> UpdateFile(int id, FileDto fileDto);
        Task<List<string>> GetAllFilesAsync();
    }
}
