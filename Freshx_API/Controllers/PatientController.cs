using AutoMapper;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Patient;
using Freshx_API.Interfaces;
using Freshx_API.Models;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientController> _logger;
        public PatientController(IPatientRepository patientRepository, IMapper mapper, ILogger<PatientController> logger)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost("Create-Patient")]
        public async Task<ActionResult<ApiResponse<Object>>> CreatePatient(AddingPatientRequest addingPatientRequest)
        {
            try
            {
                var patient = await _patientRepository.CreatePatientAsync(addingPatientRequest);
                if (patient == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory.Error<Object>(Request.Path,"Invalid input"));
                }
                return StatusCode(StatusCodes.Status200OK,ResponseFactory.Success<Patient>(Request.Path,patient));
            }
            catch(Exception e)
            {
                _logger.LogError(e, "An exceptional occured while creating a patient");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, "An exceptional occured while creating a patient", StatusCodes.Status500InternalServerError));
            }
        }
    }
}
