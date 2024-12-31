﻿using Freshx_API.Dtos;
using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class OnlineAppointmentRepository : IOnlineAppointmentRepository
    {
        private readonly FreshxDBContext _context;
        private readonly ILogger<OnlineAppointmentRepository> _logger;
        public OnlineAppointmentRepository(FreshxDBContext context, ILogger<OnlineAppointmentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OnlineAppointment?> CreateOnlineAppointment(CreateUpdateOnlineAppointment request, string accountId)
        {
            try
            {
                // Kiểm tra bác sĩ đã có lịch hẹn trong khung giờ này chưa
                var isAvailableDoctor = await _context.OnlineAppointments
                    .FirstOrDefaultAsync(o => o.TimeSlotId == request.TimeSlotId
                        && o.DoctorId == request.DoctorId
                        && o.Date == request.Date);
                if(isAvailableDoctor != null)
                {
                    return null;
                }

                var onlineAppointment = new OnlineAppointment
                {
                    DoctorId = request.DoctorId,
                    AccountId = accountId,
                    TimeSlotId = request.TimeSlotId,
                    Date = request.Date,
                    ReasonForVisit = request.ReasonForVisit,
                    CreatedAt = DateTime.UtcNow
                };
                await _context.OnlineAppointments.AddAsync(onlineAppointment);
                await _context.SaveChangesAsync();
                // Load related data after saving
                return await _context.OnlineAppointments
                    .Include(x => x.Doctor)
                        .ThenInclude(d => d.Department)
                    .Include(x => x.TimeSlot)
                    .FirstOrDefaultAsync(x => x.OnlineAppointmentId == onlineAppointment.OnlineAppointmentId);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<OnlineAppointment?> GetOnlineAppointmentById(string accountId)
        {
            try
            {
                var onlineAppointment = await _context.OnlineAppointments
            .Include(x => x.Doctor)
                .ThenInclude(d => d.Department)
            .Include(x => x.TimeSlot)
            .Where(x => x.AccountId == accountId && x.Date >= DateTime.Today)
            .OrderBy(x => x.Date)
            .ThenBy(x => x.TimeSlot.StartTime)
            .FirstOrDefaultAsync();

                return onlineAppointment;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
