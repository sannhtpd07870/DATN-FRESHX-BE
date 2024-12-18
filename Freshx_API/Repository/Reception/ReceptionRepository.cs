using AutoMapper;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Reception;
using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class ReceptionRepository : IReceptionRepository
    {
        private readonly FreshxDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ReceptionRepository> _logger;
        public ReceptionRepository(FreshxDBContext context,IMapper mapper, ILogger<ReceptionRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Reception?> CreateReceptionAsync(AddingReceptionRequest addingReceptionRequest)
        {
            try
            {
                var patientId = await _context.Patients.FindAsync(addingReceptionRequest.PatientId);
                var receptionistId = await _context.Receptionists.FindAsync(addingReceptionRequest.ReceptionistId);
                var doctorId = await _context.Doctors.FindAsync(addingReceptionRequest.AssignedDoctorId);
                if (patientId == null || receptionistId == null || doctorId == null)
                {
                    return null;
                }
                var reception = new Reception
                {
                    ReceptionNumber = addingReceptionRequest?.ReceptionNumber,
                    SequenceNumber = addingReceptionRequest?.SequenceNumber,
                    IsPriority = addingReceptionRequest?.IsPriority,
                    ReceptionLocationId = addingReceptionRequest?.ReceptionLocationId,
                    ReceptionDate = DateTime.UtcNow,
                    Note = addingReceptionRequest?.Note,
                    AssignedDoctorId = addingReceptionRequest?.AssignedDoctorId,
                    CreatedBy = addingReceptionRequest?.CreatedBy,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = addingReceptionRequest?.UpdatedBy,
                    IsDeleted = addingReceptionRequest?.IsDeleted,
                    ReasonForVisit = addingReceptionRequest?.ReasonForVisit
                };
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await _context.Receptions.AddAsync(reception);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return reception;
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                // Log exception
                _logger.LogError(e, "Error creating category");
                throw;
            }
        }
        public async Task<Reception?> UpdateReceptionAsync(int id,UpdatingReceptionRequest updatingReceptionRequest)
        {
            try
            {
                var reception = await _context.Receptions.FindAsync(id);
                if(reception != null)
                {
                    reception.ReceptionNumber = updatingReceptionRequest.ReceptionNumber;
                    reception.SequenceNumber = updatingReceptionRequest.SequenceNumber;
                    reception.IsPriority = updatingReceptionRequest.IsPriority;
                    reception.ReceptionId = updatingReceptionRequest.ReceptionId;
                    reception.ReceptionDate = updatingReceptionRequest?.ReceptionDate;
                    reception.Note = updatingReceptionRequest?.Note;
                    reception.AssignedDoctorId = updatingReceptionRequest?.AssignedDoctorId;
                    reception.CreatedBy = updatingReceptionRequest?.CreatedBy;
                    reception.CreatedDate = updatingReceptionRequest?.CreatedDate;
                    reception.UpdatedDate = updatingReceptionRequest?.UpdatedDate;
                    reception.IsDeleted = updatingReceptionRequest?.IsDeleted;
                    reception.ReasonForVisit = updatingReceptionRequest?.ReasonForVisit;
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return reception;
                    }
                }
                return null;  
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured while updating reception by id: {id}");
                throw;
            }
        }
        public async Task<Reception?> GetReceptionByIdAsync(int id)
        {
            try
            {
                return await _context.Receptions.FindAsync(id);
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"An exception occured while getting reception by id: {id}");
                throw;
            }
        }
        public async Task<Reception?> DeleteReceptionByIdAsync(int id)
        {
            try
            {
                var reception = await _context.Receptions.FindAsync(id);
                if (reception != null)
                {
                    _context.Receptions.Remove(reception);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return reception;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured while deleting reception by id: {id}");
                throw;
            }
        }
        public async Task<CustomPageResponse<IEnumerable<Reception?>>> GetReceptionsAsync(PaginationParameters parameters)
        {
            try
            {
                var query = _context.Receptions.AsQueryable();

                // Apply search filter
                if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
                {
                    query = query.Where(u =>
                        (u.Note != null && u.Note.Contains(parameters.SearchTerm)) ||
                        (u.ReasonForVisit != null && u.ReasonForVisit.Contains(parameters.SearchTerm)));
                }

                // Apply sorting
                if (parameters.SortOrderAsc ?? true)
                {
                    query = query.OrderBy(u => u.Note ?? string.Empty);
                }
                else
                {
                    query = query.OrderByDescending(u => u.Note ?? string.Empty);
                }

                // Get total count before pagination
                var totalRecords = await query.CountAsync();

                // Apply pagination
                var items = await query
                    .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                    .Take(parameters.PageSize)
                    .ToListAsync();

                return new CustomPageResponse<IEnumerable<Reception?>>(
                    items,
                    parameters.PageNumber,
                    parameters.PageSize,
                    totalRecords);
            }
            catch(Exception e )
            {
                _logger.LogError(e, $"An exception occured while getting receptions");
                throw;
            }
        }
    }
}
