using Freshx_API.Models;

namespace Freshx_API.Interfaces
{
    // Interface định nghĩa các phương thức CRUD cho Receptionist
    public interface IReceptionistRepository
    {
        // Lấy tất cả Receptionist với các tiêu chí tìm kiếm
        Task<IEnumerable<Receptionist>> GetAllAsync(
            string? searchKeyword,
            DateTime? CreatedDate,
            DateTime? UpdatedDate,
            int? status);

        // Lấy thông tin Receptionist theo ID
        Task<Receptionist?> GetByIdAsync(int id);

        // Tạo mới Receptionist
        Task<Receptionist> CreateAsync(Receptionist entity);

        // Cập nhật thông tin Receptionist
        Task UpdateAsync(Receptionist entity);

        // Xóa mềm Receptionist theo ID (đánh dấu là đã xóa mà không thực sự xóa trong cơ sở dữ liệu)
        Task DeleteAsync(int id);

        // Kiểm tra trạng thái của Receptionist trước khi thực hiện các thao tác
        Task<bool> IsSuspendedAsync(int receptionistId);
    }
}
