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
        [HttpGet("Get-AllPatients")]
        public async Task<ActionResult<ApiResponse<Object>>> GetAllPatients([FromQuery]PaginationParameters parameters)
        {
            try
            {
                if (parameters.PageNumber <= 0 || parameters.PageSize <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory.Error<Object>(Request.Path, "pageSize or pageNumber invalid", StatusCodes.Status400BadRequest));
                }
                var results = await _patientRepository.GetPatientsAsync(parameters);

                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path, results, "Get Patients succcess", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Get users failed");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, "Get Patients failed", StatusCodes.Status500InternalServerError));
            }

        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse<Object>>> UpdatePatientById(int id,UpdatingPatientRequest updatingPatientRequest)
        {
            try
            {
                var patient = await _patientRepository.UpdatePatientByIdAsync(id, updatingPatientRequest);
                if(patient == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory.Error<Object>(Request.Path, $"Updating patient by id: {id} fail", StatusCodes.Status404NotFound));
                }
                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path,patient, $"Updating patient by id: {id} success", StatusCodes.Status200OK));
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"An exception occured while updating patient by id: {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Patient>(Request.Path, $"An exception occured while updating patient by id: {id}", StatusCodes.Status500InternalServerError));
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse<Object>>> GetPatientById(int id)
        {
            try
            {
                var patient = await _patientRepository.GetPatientByIdAsync(id);
                if(patient == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory.Error<Object>(Request.Path, $"Patient by id: {id} not found", StatusCodes.Status404NotFound));
                }
                return StatusCode(StatusCodes.Status200OK,ResponseFactory.Success(Request.Path,patient));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exceptional occured while creating a patient");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, $"An exceptional occured while get patient by {id}", StatusCodes.Status500InternalServerError));
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse<Object>>> DeletePatientById(int id)
        {
            try
            {
                var patient = await _patientRepository.DeletePatientByIdAsync(id);
                if (patient == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,ResponseFactory.Error<Object>(Request.Path,$"Deleting patient by id: {id}",StatusCodes.Status404NotFound));
                }
                return StatusCode(StatusCodes.Status200OK,ResponseFactory.Success(Request.Path, patient));
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"An exception occured while deleting by id: {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, $"An exception occured while deleting by id: {id}", StatusCodes.Status500InternalServerError));
            }
        }     
    }
}
