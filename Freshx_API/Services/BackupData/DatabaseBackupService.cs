using Microsoft.Data.SqlClient;

namespace Freshx_API.Services.BackupData
{
    public class DatabaseBackupService : IHostedService, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DatabaseBackupService> _logger;
        private Timer _timer;

        public DatabaseBackupService(
            IConfiguration configuration,
            ILogger<DatabaseBackupService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Dịch vụ backup database đã khởi động.");

            _timer = new Timer(DoBackup, null, TimeSpan.Zero,
                TimeSpan.FromHours(24)); // Chạy mỗi 24 giờ

            return Task.CompletedTask;
        }

        private async void DoBackup(object state)
        {
            try
            {
                var primaryConnection = _configuration["ConnectionStrings:DBFreshx"];
                var backupConnection = _configuration["ConnectionStrings:DBFreshx_bk"];
                var databaseName = "DATN_freshx"; // Thay bằng tên database của bạn
                var backupPath = _configuration["DatabaseBackup:BackupPath"];
                // Tạo backup file từ server chính
               // var backupPath = Path.Combine(Path.GetTempPath(), $"backup_{DateTime.Now:yyyyMMddHHmmss}.bak");

                var backupFileName = $"backup_{DateTime.Now:yyyyMMddHHmmss}.bak";
                var fullBackupPath = Path.Combine(backupPath, backupFileName);

                using (var connection = new SqlConnection(primaryConnection))
                {
                    await connection.OpenAsync();

                    var backupQuery = $@"
                    BACKUP DATABASE [{databaseName}] 
                    TO DISK = '{fullBackupPath}'
                    WITH FORMAT, 
                         INIT,
                         NAME = N'Full Database Backup',
                         STATS = 10";

                    using (var command = new SqlCommand(backupQuery, connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }

                    _logger.LogInformation($"Đã tạo file backup tại: {fullBackupPath}");
                }

                // Restore vào server phụ
                using (var connection = new SqlConnection(backupConnection))
                {
                    await connection.OpenAsync();

                    // Ngắt kết nối hiện tại đến database
                    var disconnectQuery = $@"
                    ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

                    // Restore database
                    var restoreQuery = $@"
                    RESTORE DATABASE [{databaseName}] 
                    FROM DISK = '{fullBackupPath}'
                    WITH REPLACE,
                         STATS = 10;
                    
                    ALTER DATABASE [{databaseName}] SET MULTI_USER;";

                    using (var command = new SqlCommand(disconnectQuery + restoreQuery, connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }

                    _logger.LogInformation("Đã restore database vào server phụ thành công.");
                }

                // Xóa file backup tạm thời
                if (File.Exists(fullBackupPath))
                {
                    File.Delete(fullBackupPath);
                    _logger.LogInformation("Đã xóa file backup tạm thời.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi trong quá trình backup/restore database.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Dịch vụ backup database đã dừng.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

    public static class BackupServiceExtensions
    {
        public static IServiceCollection AddDatabaseBackupService(this IServiceCollection services)
        {
            return services.AddHostedService<DatabaseBackupService>();
        }
    }
}
