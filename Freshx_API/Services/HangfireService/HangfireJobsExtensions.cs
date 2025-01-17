using Hangfire;

namespace Freshx_API.Services.HangfireService
{
    public static class HangfireJobsExtensions
    {
        public static void ConfigureAppointmentJobs(this IApplicationBuilder app)
        {
            // Cleanup job - runs every day at 1 AM
            RecurringJob.AddOrUpdate<AppointmentJobService>(
                "cleanup-appointments",
                job => job.CleanupAppointments(),
                "0 1 * * *"); // Runs at 1 AM daily

            // Email reminder job - runs every day at 6 AM
            RecurringJob.AddOrUpdate<AppointmentJobService>(
                "appointment-reminders",
                job => job.SendAppointmentReminders(),
                "0 6 * * *"); // Runs at 6 AM daily
        }
    }
}
