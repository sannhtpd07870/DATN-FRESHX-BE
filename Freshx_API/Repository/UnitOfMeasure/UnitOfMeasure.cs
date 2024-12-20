using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class UnitOfMeasureRepository : IUnitOfMeasureRepository
    {
        private readonly FreshxDBContext _context;

        public UnitOfMeasureRepository(FreshxDBContext context)
        {
            _context = context;
        }

        // Lấy danh sách đơn vị đo lường với bộ lọc
        public async Task<IEnumerable<UnitOfMeasure>> GetAllAsync(
            string? searchKeyword,
            DateTime? createdDate,
            DateTime? updatedDate,
            int? isSuspended,
            int? isDeleted)
        {
            var query = _context.UnitOfMeasures.AsQueryable();

            // Lọc theo từ khóa tìm kiếm
            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                query = query.Where(u => u.Name.Contains(searchKeyword) || u.Code.Contains(searchKeyword));
            }

            // Lọc theo ngày tạo
            if (createdDate.HasValue)
            {
                query = query.Where(u => u.CreatedDate >= createdDate.Value);
            }

            // Lọc theo ngày cập nhật
            if (updatedDate.HasValue)
            {
                query = query.Where(u => u.UpdatedDate <= updatedDate.Value);
            }

            // Lọc theo trạng thái tạm ngưng
            if (isSuspended.HasValue)
            {
                query = query.Where(u => u.IsSuspended == isSuspended.Value);
            }

            // Lọc theo trạng thái đã xóa
            if (isDeleted.HasValue)
            {
                query = query.Where(u => u.IsDeleted == isDeleted.Value);
            }

            return await query.ToListAsync();
        }

        // Lấy đơn vị đo lường theo ID
        public async Task<UnitOfMeasure?> GetByIdAsync(int id)
        {
            return await _context.UnitOfMeasures
                .FirstOrDefaultAsync(u => u.UnitOfMeasureId == id && (u.IsDeleted == 0 || u.IsDeleted == null));
        }

        // Tạo mới đơn vị đo lường
        public async Task<UnitOfMeasure> CreateAsync(UnitOfMeasure entity)
        {
            _context.UnitOfMeasures.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // Cập nhật đơn vị đo lường
        public async Task UpdateAsync(UnitOfMeasure entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Xóa mềm đơn vị đo lường
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.UnitOfMeasures.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = 1;
                await _context.SaveChangesAsync();
            }
        }
    }
}
