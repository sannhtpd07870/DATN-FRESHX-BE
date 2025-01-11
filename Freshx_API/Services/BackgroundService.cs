using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Services
{
    public class MarkRecordsAsDeletedService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _interval = TimeSpan.FromHours(24); // Lặp lại mỗi 24 giờ

        public MarkRecordsAsDeletedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Chờ cho đến khi hết thời gian chờ
                await Task.Delay(_interval, stoppingToken);

                // Thực hiện cập nhật IsDeleted cho các bản ghi qua ngày mới
                await MarkIsDeletedForPastRecords<Reception>();
                await MarkIsDeletedForPastRecords<Appointment>(); // Ví dụ cho bảng khác
            }
        }

        private async Task MarkIsDeletedForPastRecords<TEntity>() where TEntity : class
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<FreshxDBContext>();

                var today = DateTime.Today;

                // Lấy DbSet của bảng tương ứng
                var dbSet = context.Set<TEntity>();

                // Lọc các bản ghi có IsDeleted = null và ngày < hôm nay
                var entitiesToDelete = await dbSet
                    .Where(e => EF.Property<int?>(e, "IsDeleted") == null && EF.Property<DateTime?>(e, "Time") < today)
                    .ToListAsync();

                // Cập nhật trường IsDeleted cho các bản ghi cần xóa
                foreach (var entity in entitiesToDelete)
                {
                    // Use reflection to set the IsDeleted property
                    var isDeletedProperty = entity.GetType().GetProperty("IsDeleted");
                    if (isDeletedProperty != null && isDeletedProperty.CanWrite)
                    {
                        isDeletedProperty.SetValue(entity, 1);
                    }
                }


                await context.SaveChangesAsync();
            }
        }
    }

}
