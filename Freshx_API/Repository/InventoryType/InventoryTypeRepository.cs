using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class InventoryTypeRepository : IInventoryTypeRepository
    {
        private readonly FreshxDBContext _context;

        public InventoryTypeRepository(FreshxDBContext context)
        {
            _context = context;
        }

        // Lấy tất cả loại tồn kho, có thể tìm kiếm theo từ khóa
        public async Task<IEnumerable<InventoryType>> GetAllAsync(string? searchKeyword = null)
        {
            // Lấy tất cả các loại tồn kho mà không kiểm tra IsDeleted
            var query = _context.InventoryTypes.AsQueryable();

            // Nếu có từ khóa tìm kiếm, thêm điều kiện tìm kiếm
            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                query = query.Where(i => i.Name.Contains(searchKeyword) || i.Code.Contains(searchKeyword));
            }

            // Trả về danh sách tất cả loại tồn kho sau khi áp dụng các bộ lọc
            return await query.ToListAsync();
        }

        // Lấy loại tồn kho theo ID
        public async Task<InventoryType?> GetByIdAsync(int id)
        {
            return await _context.InventoryTypes
                .FirstOrDefaultAsync(i => i.InventoryTypeId == id);
        }

        // Tạo mới loại tồn kho
        public async Task<InventoryType> CreateAsync(InventoryType entity)
        {
            _context.InventoryTypes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // Cập nhật thông tin loại tồn kho, trả về true/false
        public async Task<bool> UpdateAsync(InventoryType entity)
        {
            var existingEntity = await _context.InventoryTypes.FindAsync(entity.InventoryTypeId);
            if (existingEntity == null)
                return false;

            // Cập nhật thông tin từ entity mới vào entity đã có
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // Xóa loại tồn kho, trả về true/false
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.InventoryTypes.FindAsync(id);
            if (entity != null)
            {
                _context.InventoryTypes.Remove(entity); // Xóa hoàn toàn bản ghi
                await _context.SaveChangesAsync();
                return true;
            }

            return false; // Không tìm thấy bản ghi để xóa
        }
    }
}
