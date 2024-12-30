using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.Patient;
using Freshx_API.Interfaces;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Interfaces.IReception;
using Freshx_API.Models;
using Microsoft.Extensions.Azure;

namespace Freshx_API.Services
{
    public class ReceptionService : IReceptionService
    {
        private readonly IReceptionRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;
        private readonly IMedicalServiceRequestRepository _requestRepository;
        private readonly ITokenRepository _tokenRepository;

        public ReceptionService(IReceptionRepository repository, IMapper mapper, IPatientRepository patientRepository, IMedicalServiceRequestRepository requestRepository, ITokenRepository tokenRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _patientRepository = patientRepository;
            _requestRepository = requestRepository;
            _tokenRepository = tokenRepository;
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
            Console.WriteLine(data);
            return data;
        }

        public async Task<ReceptionDto> AddAsync(CreateReceptionDto dto)
        {
            var reception = _mapper.Map<Reception>(dto);
            if (dto.PatientId != null)
            {
                var patien = await _patientRepository.CreatePatientAsync(dto.AddingPatient);
                reception.PatientId = patien.PatientId;
            }
            else
            {
                var UpdatePatient = _mapper.Map<UpdatingPatientRequest>(dto.AddingPatient);
                var patien = await _patientRepository.UpdatePatientByIdAsync(reception.PatientId ?? 0, UpdatePatient);
            }

            reception.IsDeleted = 0;
            reception.ReceptionDate = DateTime.Now.Date;
            reception.CreatedDate = DateTime.UtcNow;
            reception.CreatedBy = _tokenRepository.GetUserIdFromToken();
            
            var Addreception = await _repository.AddAsync(reception);

            // Ánh xạ các MedicalServiceRequests (nếu có)
            if (dto.MedicalServiceRequest != null)
            {
                foreach (var request in dto.MedicalServiceRequest)
                {
                    request.ReceptionId = Addreception.ReceptionId;
                    var serviceRequest = _mapper.Map<MedicalServiceRequest>(request);
                    var SaveService = await _requestRepository.AddAsync(serviceRequest);
                    reception.MedicalServiceRequest.Add(SaveService);
                }

            }

            await _repository.UpdateAsync(reception);
            return _mapper.Map<ReceptionDto>(reception);
        }

        public async Task UpdateAsync(CreateReceptionDto dto)
        {
            var reception = _mapper.Map<Reception>(dto);

            // Cập nhật MedicalServiceRequests
            if (dto.MedicalServiceRequest != null)
            {
                reception.MedicalServiceRequest = _mapper.Map<List<MedicalServiceRequest>>(dto.MedicalServiceRequest);
            }

            await _repository.UpdateAsync(reception);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}