using AutoMapper;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Interfaces;
using Freshx_API.Models;
using Freshx_API.Services.CommonServices;
using NuGet.Protocol.Core.Types;

namespace Freshx_API.Services
{
    public class MedicalServiceRequestService 
    {
        private readonly IMedicalServiceRequestRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<MedicalServiceRequestService> _logger;
        public MedicalServiceRequestService(
           IMedicalServiceRequestRepository repository,
           IMapper mapper,
           ILogger<MedicalServiceRequestService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ApiResponse<MedicalServiceRequestDTO>> CreateAsync(CreateMedicalServiceRequestDTO createDto)
        {
            try
            {
                var request = _mapper.Map<MedicalServiceRequest>(createDto);
                var result = await _repository.CreateAsync(request);
                var dto = _mapper.Map<MedicalServiceRequestDTO>(result);

                return ResponseFactory.Success(
                    "api/MedicalServiceRequest",
                    dto,
                    "Medical service request created successfully",
                    StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating medical service request");
                return ResponseFactory.Error<MedicalServiceRequestDTO>(
                    "api/MedicalServiceRequest",
                    "Error creating medical service request",
                    StatusCodes.Status500InternalServerError);
            }
        }
    }
    // Implement các method khác...

}
