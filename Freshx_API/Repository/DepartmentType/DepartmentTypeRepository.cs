using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class DepartmentTypeRepository : IDepartmentTypeRepository
    {
        private readonly FreshxDBContext _context;

        public DepartmentTypeRepository(FreshxDBContext context)
        {
            _context = context;
        }

        // Lấy tất cả phòng ban (lọc các bản ghi chưa bị xóa)
        public async Task<IEnumerable<DepartmentType>> GetAllAsync()
        {
            return await _context.DepartmentTypes
                .Where(d => d.IsDeleted == 0 || d.IsDeleted == null)
                .ToListAsync();
        }

        // Lấy phòng ban theo ID (lọc bản ghi chưa bị xóa)
        public async Task<DepartmentType?> GetByIdAsync(int id)
        {
            return await _context.DepartmentTypes
                .FirstOrDefaultAsync(d => d.DepartmentTypeId == id && (d.IsDeleted == 0 || d.IsDeleted == null));
        }

        // Tạo mới phòng ban
        public async Task<DepartmentType> CreateAsync(DepartmentType entity)
        {
            _context.DepartmentTypes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // Cập nhật phòng ban
        public async Task UpdateAsync(DepartmentType entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Xóa mềm phòng ban (đánh dấu IsDeleted = 1)
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.DepartmentTypes.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = 1;
                await _context.SaveChangesAsync();
            }
        }
    }
}
