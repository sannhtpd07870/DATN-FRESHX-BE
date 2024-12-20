using AutoMapper;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Reception;
using Freshx_API.Interfaces;
using Freshx_API.Models;
using Freshx_API.Repository;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionController : ControllerBase
    {
        private readonly ILogger<ReceptionController> _logger;
        private readonly IReceptionRepository _receptionRepository;
        private readonly IMapper _mapper;
        public ReceptionController(IReceptionRepository receptionRepository, IMapper mapper,ILogger<ReceptionController> logger)
        {
            _receptionRepository = receptionRepository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost("Create-Reception")]
        public async Task<ActionResult<ApiResponse<Object>>> CreateReception(AddingReceptionRequest addingReceptionRequest)
        {
            try
            {
                var reception = await _receptionRepository.CreateReceptionAsync(addingReceptionRequest);
                if (reception == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory.Error<Object>(Request.Path, "Invalid input", StatusCodes.Status400BadRequest));
                }
                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path, reception));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exceptional occured while creating a reception");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, "An exceptional occured while creating a reception", StatusCodes.Status500InternalServerError));
            }
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse<Object>>> UpdateReception(int id,UpdatingReceptionRequest updatingReceptionRequest)
        {
            try
            {
                var reception = await _receptionRepository.UpdateReceptionAsync(id, updatingReceptionRequest);
                if(reception == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory.Error<Object>(Request.Path, "Invalid input"));
                }
                return StatusCode(StatusCodes.Status200OK,ResponseFactory.Success(Request.Path,reception));
            }
            catch(Exception e)
            {
                _logger.LogError(e, "An exceptional occured");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse<Object>>> GetReceptionById(int id)
        {
            try
            {
                var reception = await _receptionRepository.GetReceptionByIdAsync(id);
                if(reception == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory.Error<Object>(Request.Path, $"Reception not found by {id}", StatusCodes.Status404NotFound));
                }
                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path, reception));
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"An exception occured while getting reception by id: {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, $"An exception occured while getting reception by id: {id}", StatusCodes.Status500InternalServerError));
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse<Object>>> DeleteReceptionById(int id)
        {
            try
            {
                var reception = await _receptionRepository.DeleteReceptionByIdAsync(id);
                if(reception == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory.Error<Object>(Request.Path, $"Data not found by {id}", StatusCodes.Status404NotFound));
                }
                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success<Object>(Request.Path,null));
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"An exception occured while deleting reception by id: {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, $"An exception occured while deleting reception by id: {id}", StatusCodes.Status500InternalServerError));
            }
        }
        [HttpGet("Get-AllReceptions")]
        public async Task<ActionResult<ApiResponse<Object>>> GetAllReceptions([FromQuery] PaginationParameters parameters)
        {
            try
            {
                if (parameters.PageNumber <= 0 || parameters.PageSize <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory.Error<Object>(Request.Path, "pageSize or pageNumber invalid", StatusCodes.Status400BadRequest));
                }
                var results = await _receptionRepository.GetReceptionsAsync(parameters);

                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path, results, "Get receptions succcess", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Get receptions failed");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, "Get Patients failed", StatusCodes.Status500InternalServerError));
            }

        }
    }
}
