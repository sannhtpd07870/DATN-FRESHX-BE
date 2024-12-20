using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly FreshxDBContext _context;

        public SupplierRepository(FreshxDBContext context)
        {
            _context = context;
        }

        // Lấy danh sách nhà cung cấp với bộ lọc
        public async Task<IEnumerable<Supplier>> GetAllAsync(
            string? searchKeyword,
            DateTime? createdDate,
            DateTime? updatedDate,
            bool? isSuspended,
            bool? isForeign,
            bool? isStateOwned,
            int? isDeleted)
        {
            var query = _context.Suppliers.AsQueryable();

            // Lọc theo từ khóa tìm kiếm
            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                query = query.Where(s => s.Name.Contains(searchKeyword) || s.Code.Contains(searchKeyword));
            }

            // Lọc theo ngày tạo
            if (createdDate.HasValue)
            {
                query = query.Where(s => s.CreatedDate >= createdDate.Value);
            }

            // Lọc theo ngày cập nhật
            if (updatedDate.HasValue)
            {
                query = query.Where(s => s.UpdatedDate <= updatedDate.Value);
            }

            // Lọc theo trạng thái tạm ngưng
            if (isSuspended.HasValue)
            {
                query = query.Where(s => s.IsSuspended == isSuspended.Value);
            }

            // Lọc theo trạng thái nhà cung cấp nước ngoài
            if (isForeign.HasValue)
            {
                query = query.Where(s => s.IsForeign == isForeign.Value);
            }

            // Lọc theo trạng thái nhà nước
            if (isStateOwned.HasValue)
            {
                query = query.Where(s => s.IsStateOwned == isStateOwned.Value);
            }

            // Lọc theo trạng thái đã xóa
            if (isDeleted.HasValue)
            {
                query = query.Where(s => s.IsDeleted == isDeleted.Value);
            }

            return await query.ToListAsync();
        }

        // Lấy nhà cung cấp theo ID
        public async Task<Supplier?> GetByIdAsync(int id)
        {
            return await _context.Suppliers
                .FirstOrDefaultAsync(s => s.SupplierId == id && (s.IsDeleted == 0 || s.IsDeleted == null));
        }

        // Tạo mới nhà cung cấp
        public async Task<Supplier> CreateAsync(Supplier entity)
        {
            _context.Suppliers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // Cập nhật nhà cung cấp
        public async Task UpdateAsync(Supplier entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Xóa mềm nhà cung cấp
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Suppliers.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = 1;
                await _context.SaveChangesAsync();
            }
        }
    }
}
