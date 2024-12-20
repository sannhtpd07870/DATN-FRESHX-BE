using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        private readonly FreshxDBContext _context;

        public ReceptionistRepository(FreshxDBContext context)
        {
            _context = context;
        }

        // Lấy tất cả Receptionist với bộ lọc
        public async Task<IEnumerable<Receptionist>> GetAllAsync(
            string? searchKeyword,
            DateTime? createdDate,
            DateTime? updatedDate,
            int? status)
        {
            // Lấy danh sách Receptionist chưa bị xóa mềm
            var query = _context.Receptionists
                .Where(r => r.IsDeleted == 0 || r.IsDeleted == null);

            // Áp dụng bộ lọc từ khóa tìm kiếm
            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                query = query.Where(r => r.Name.Contains(searchKeyword) || r.Email.Contains(searchKeyword) || r.Phone.Contains(searchKeyword));
            }

            // Lọc theo ngày tạo
            if (createdDate.HasValue)
            {
                query = query.Where(r => r.CreatedDate >= createdDate.Value);
            }

            // Lọc theo ngày cập nhật
            if (updatedDate.HasValue)
            {
                query = query.Where(r => r.UpdatedDate <= updatedDate.Value);
            }

            // Lọc theo trạng thái
            if (status.HasValue)
            {
                query = query.Where(r => r.IsSuspended == status.Value);
            }

            return await query.ToListAsync();
        }

        // Lấy Receptionist theo ID
        public async Task<Receptionist?> GetByIdAsync(int id)
        {
            return await _context.Receptionists
                .FirstOrDefaultAsync(r => r.ReceptionistId == id && (r.IsDeleted == 0 || r.IsDeleted == null));
        }

        // Tạo mới Receptionist
        public async Task<Receptionist> CreateAsync(Receptionist entity)
        {
            _context.Receptionists.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // Cập nhật Receptionist
        public async Task UpdateAsync(Receptionist entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Xóa mềm Receptionist
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Receptionists.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = 1;
                await _context.SaveChangesAsync();
            }
        }

        // Kiểm tra trạng thái tạm ngưng của Receptionist
        public async Task<bool> IsSuspendedAsync(int receptionistId)
        {
            var receptionist = await _context.Receptionists
                .FirstOrDefaultAsync(r => r.ReceptionistId == receptionistId);

            return receptionist != null && receptionist.IsSuspended == 1;
        }
    }
}
