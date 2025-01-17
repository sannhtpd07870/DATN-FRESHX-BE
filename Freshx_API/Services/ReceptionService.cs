using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.ExamineDtos;
using Freshx_API.Dtos.Patient;
using Freshx_API.Interfaces;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Interfaces.IReception;
using Freshx_API.Interfaces.Payments;
using Freshx_API.Interfaces.Services;
using Freshx_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Freshx_API.Services
{
    public class ReceptionService : IReceptionService
    {
        private readonly IReceptionRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;
        private readonly IMedicalServiceRequestService _requestService;
        private readonly IMedicalServiceRequestRepository _requestRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IExamineService _examineService;
        private readonly ILabResultService _labResultService;
        private readonly IBillingService _billingService;
        private readonly FreshxDBContext _context;
        private readonly IEmployeeRepository _employeeRepository;
        public ReceptionService(
            IReceptionRepository repository,
            IMapper mapper,
            IPatientRepository patientRepository,
            IMedicalServiceRequestService requestService,
            IMedicalServiceRequestRepository requestRepository,
            ITokenRepository tokenRepository,
            IExamineService examine,
            ILabResultService labResultService,
            IBillingService billingService,
            FreshxDBContext context,
            IEmployeeRepository employeeRepository
            )
        {
            _repository = repository;
            _mapper = mapper;
            _patientRepository = patientRepository;
            _requestRepository = requestRepository;
            _tokenRepository = tokenRepository;
            _examineService = examine;
            _labResultService = labResultService;
            _billingService = billingService;
            _context = context;
            _employeeRepository = employeeRepository;
            _requestService = requestService;
        }

        public async Task<ReceptionDto?> GetByIdAsync(int id)
        {
            var reception = await _repository.GetByIdAsync(id);
            return _mapper.Map<ReceptionDto>(reception);
        }

        public async Task<IEnumerable<ReceptionDto>> GetAllAsync()
        {
            var receptions = await _repository.GetAllAsync();
            var data = _mapper.Map<IEnumerable<ReceptionDto>>(receptions);
            return data;
        }
        public async Task<List<ExamineHistoryDto>> GetListExamine(string? searchKey, bool isHistory)
        {
            return await _repository.GetListExamine(searchKey, isHistory);
        }

        public async Task<List<ListReceptionDto>> GetListLabResult(string? searchKey, bool isHistory)
        {
            return await _repository.GetListLabResult(searchKey, isHistory);
        }
        public async Task<ExamineHistoryDto> GetPatientHistory(int receptionId)
        {
            var data = await _repository.GetPatientHistory(receptionId);
            return data;
        }

        public async Task<ReceptionDto> AddAsync(CreateReceptionDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var reception = _mapper.Map<Reception>(dto);

                if (dto.PatientId == null && dto.AddingPatient != null)
                {
                    var patient = await _patientRepository.CreatePatientAsync(dto.AddingPatient);
                    reception.PatientId = patient.PatientId;
                }
                else if (dto.PatientId != null)
                {
                    var existingPatient = await _patientRepository.GetPatientByIdAsync(dto.PatientId.Value)
                                          ?? throw new KeyNotFoundException($"Bệnh nhân ID {dto.PatientId} không tồn tại");

                    if (dto.AddingPatient != null)
                    {
                        var updatePatient = _mapper.Map<UpdatingPatientRequest>(dto.AddingPatient);
                        await _patientRepository.UpdatePatientByIdAsync(dto.PatientId.Value, updatePatient);
                    }
                }

                reception.IsDeleted = 0;
                reception.ReceptionDate = DateTime.Now.Date;
                reception.CreatedDate = DateTime.UtcNow;
                reception.CreatedBy = _tokenRepository.GetUserIdFromToken();

                // Gán MedicalServiceRequests
                if (dto.MedicalServiceRequest?.Any() == true)
                {
                    reception.MedicalServiceRequest = dto.MedicalServiceRequest
                        .Select(request => _mapper.Map<MedicalServiceRequest>(request))
                        .ToList();
                }
                var adderReception = await _repository.AddAsync(reception);
                //_context.Receptions.Add(reception);
                //await _context.SaveChangesAsync();
                var types = await _context.MedicalServiceRequests
                    .Include(m => m.Service)
                    .ThenInclude(s => s.ServiceTypes)
                    .Where(m => m.ReceptionId == adderReception.ReceptionId)
                    .Select(m => m.Service.ServiceTypes.Code)
                   .ToListAsync();

                if (types.Contains("KB"))
                {
                    var examDto = new CreateExamDto
                    {
                        ReceptionId = reception.ReceptionId,
                        ReasonForVisit = reception.ReasonForVisit,
                        CreatedTime = DateTime.Now,
                        IsDeleted = 0,
                        IsPaid = false
                    };
                    await _examineService.AddAsync(examDto);
                }
                if (types.Contains("XN"))
                {
                    var examDto = new CreateLabResultDto
                    {
                        ReceptionId = reception.ReceptionId,
                     
                    };
                    await _labResultService.AddAsync(examDto);
                }

                await transaction.CommitAsync();
                return _mapper.Map<ReceptionDto>(reception);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<ReceptionDto> UpdateAsync(int Id, [FromForm] UpdateReceptionDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Get current reception
                var existingReception = await _repository.GetByIdAsync(Id)
                    ?? throw new FileNotFoundException($"Tiếp nhận không tồn tại {Id} not found");

                // Update reception info
                _mapper.Map(dto, existingReception);
                existingReception.UpdatedDate = DateTime.UtcNow;

                var updateUser = await _employeeRepository.GetEmployeeByAcountIdAsync(
                    _tokenRepository.GetUserIdFromToken());
                if (updateUser != null)
                {
                    existingReception.UpdatedBy = updateUser.EmployeeId;
                }

                // Handle medical service requests
                if (dto.MedicalServiceRequest != null)
                {
                    // Get existing requests using AsNoTracking to avoid tracking conflicts
                    var existingRequests = await _requestRepository
                        .GetAllByReceptionIdAsync(Id);

                    // Find requests to delete
                    var requestsToDelete = existingRequests
                        .Where(er => !dto.MedicalServiceRequest
                            .Any(nr => nr.MedicalServiceRequestId == er.MedicalServiceRequestId));

                    // Delete old requests
                    foreach (var request in requestsToDelete)
                    {
                        await _requestRepository.DeleteAsync(request.MedicalServiceRequestId);
                    }

                    // Update or add new requests
                    foreach (var newRequest in dto.MedicalServiceRequest)
                    {
                        if (newRequest.MedicalServiceRequestId > 0)
                        {
                            await _requestService.UpdateAsync(newRequest.MedicalServiceRequestId, newRequest);
                        }
                        else
                        {
                            // Add new request
                            newRequest.ReceptionId = Id;
                            var serviceRequest = _mapper.Map<MedicalServiceRequest>(newRequest);
                            var savedService = await _requestRepository.AddAsync(serviceRequest);

                            // Handle medical examination service for new request
                            var medical = await _requestRepository.GetByIdAsync(savedService.MedicalServiceRequestId);

                            var types = await _context.MedicalServiceRequests
                                  .Include(m => m.Service)
                                  .ThenInclude(s => s.ServiceTypes)
                                  .Where(m => m.ReceptionId == newRequest.ReceptionId)
                                  .Select(m => m.Service.ServiceTypes.Code)
                                 .ToListAsync();
                            if (types.Contains("KB"))
                            {
                                var examDto = new CreateExamDto
                                {
                                    ReceptionId = newRequest.ReceptionId,
                                    ReasonForVisit = dto.ReasonForVisit,
                                    CreatedTime = DateTime.Now,
                                    IsDeleted = 0,
                                    IsPaid = false
                                };
                                await _examineService.AddAsync(examDto);
                            }
                            if (types.Contains("XN"))
                            {
                                var examDto = new CreateLabResultDto
                                {
                                    ReceptionId = newRequest.ReceptionId,

                                };
                                await _labResultService.AddAsync(examDto);
                            }
                        }
                    }
                }

                await transaction.CommitAsync();
                return _mapper.Map<ReceptionDto>(existingReception);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}