using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Interfaces;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PositionController> _logger;
        public PositionController(IPositionRepository positionRepository, IMapper mapper, ILogger<PositionController> logger)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost("Create-Postion")]
        public async Task<ActionResult<ApiResponse<Object>>> CreatePostion(AddingPositionRequest addingPositionRequest)
        {
            try
            {
                var position = await _positionRepository.CreatePositionAsync(addingPositionRequest);
                if(position == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,ResponseFactory.Error<Object>(Request.Path,"Invalid input",StatusCodes.Status400BadRequest));
                }
                return StatusCode(StatusCodes.Status201Created,ResponseFactory.Success(Request.Path,position,"Create a position success",StatusCodes.Status201Created));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exception occured while creating a position");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, "An exception occured while creating a position", StatusCodes.Status500InternalServerError));
            }
        }
        [HttpGet("Get-AllPositions")]
        public async Task<ActionResult<ApiResponse<Object>>> GetAllPostion()
        {
            try
            {
                var data = await _positionRepository.GetPositionsAsync();
                return StatusCode(StatusCodes.Status200OK,ResponseFactory.Success<Object>(Request.Path,data));
            }
            catch(Exception e)
            {
                _logger.LogError(e, "An exception occured while creating a position");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, "An exception occured while getting positions", StatusCodes.Status500InternalServerError));
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse<Object>>> GetPostionById(int id)
        {
            try
            {
                var position = await _positionRepository.GetPositionByIdAsync(id);
                if(position == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory.Error<Object>(Request.Path, $"A position by {id} not found"));
                }
                return StatusCode(StatusCodes.Status200OK,ResponseFactory.Success(Request.Path,position,$"Get position by {id} success",StatusCodes.Status200OK));
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"An exception occured whil getting a position by {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, $"An exception occured while getting a position", StatusCodes.Status500InternalServerError));
            }
        }

    }
}
