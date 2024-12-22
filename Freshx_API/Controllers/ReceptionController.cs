//using AutoMapper;
//using Freshx_API.Dtos;
//using Freshx_API.Dtos.CommonDtos;
//using Freshx_API.DTOs;
//using Freshx_API.Interfaces;
//using Freshx_API.Models;
//using Freshx_API.Repository;
//using Microsoft.AspNetCore.Mvc;


//namespace Freshx_API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ReceptionController : ControllerBase
//    {
//        private readonly IReceptionRepository _receptionRepository;
//        private readonly IMapper _mapper; 

//        public ReceptionController(IReceptionRepository receptionRepository, IMapper mapper)
//        {
//            _receptionRepository = receptionRepository;
//            _mapper = mapper;
//        }

//        // GET: api/receptions
//        [HttpGet]
//        public async Task<ActionResult<ApiResponse<List<ReceptionDto>>>> GetAllReceptions()
//        {
//            var receptions = await _receptionRepository.GetAllReceptionsAsync();

//            if (receptions == null || receptions.Count == 0)
//            {
//                return NotFound(new ApiResponse<List<ReceptionDto>>
//                {
                   
//                    Message = "No receptions found",
//                    StatusCode = 404,
//                    Data = null,
//                    Timestamp = DateTime.UtcNow
//                });
//            }

//            var receptionDtos = _mapper.Map<List<ReceptionDto>>(receptions);

//            return Ok(new ApiResponse<List<ReceptionDto>>
//            {
              
//                Message = "Receptions retrieved successfully",
//                StatusCode = 200,
//                Data = receptionDtos,
//                Timestamp = DateTime.UtcNow
//            });
//        }

//        // GET: api/receptions/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<ApiResponse<ReceptionDto>>> GetReceptionById(int id)
//        {
//            var reception = await _receptionRepository.GetReceptionByIdAsync(id);

//            if (reception == null)
//            {
//                return NotFound(new ApiResponse<ReceptionDto>
//                {
                   
//                    Message = "Reception not found",
//                    StatusCode = 404,
//                    Data = null,
//                    Timestamp = DateTime.UtcNow
//                });
//            }

//            var receptionDto = _mapper.Map<ReceptionDto>(reception);

//            return Ok(new ApiResponse<ReceptionDto>
//            {
                
//                Message = "Reception retrieved successfully",
//                StatusCode = 200,
//                Data = receptionDto,
//                Timestamp = DateTime.UtcNow
//            });
//        }

//        // POST: api/receptions
//        [HttpPost]
//        public async Task<ActionResult<ApiResponse<ReceptionDto>>> CreateReception(CreateReceptionDto createDto)
//        {
//            var reception = _mapper.Map<Reception>(createDto);

//            await _receptionRepository.CreateReceptionAsync(reception);

//            var receptionDto = _mapper.Map<ReceptionDto>(reception);

//            return CreatedAtAction(nameof(GetReceptionById), new { id = reception.ReceptionId },
//                new ApiResponse<ReceptionDto>
//                {
                   
//                    Message = "Reception created successfully",
//                    StatusCode = 201,
//                    Data = receptionDto,
//                    Timestamp = DateTime.UtcNow
//                });
//        }

//        // PUT: api/receptions/{id}
//        [HttpPut("{id}")]
//        public async Task<ActionResult<ApiResponse<ReceptionDto>>> UpdateReception(int id, UpdateReceptionDto updateDto)
//        {
//            var reception = await _receptionRepository.GetReceptionByIdAsync(id);
//            if (reception == null)
//            {
//                return NotFound(new ApiResponse<ReceptionDto>
//                {
                    
//                    Message = "Reception not found",
//                    StatusCode = 404,
//                    Data = null,
//                    Timestamp = DateTime.UtcNow
//                });
//            }

//            _mapper.Map(updateDto, reception);
//            await _receptionRepository.UpdateReceptionAsync(reception);

//            var receptionDto = _mapper.Map<ReceptionDto>(reception);

//            return Ok(new ApiResponse<ReceptionDto>
//            {
               
//                Message = "Reception updated successfully",
//                StatusCode = 200,
//                Data = receptionDto,
//                Timestamp = DateTime.UtcNow
//            });
//        }

//        // DELETE: api/receptions/{id}
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<ApiResponse<string>>> DeleteReception(int id)
//        {
//            var reception = await _receptionRepository.GetReceptionByIdAsync(id);
//            if (reception == null)
//            {
//                return NotFound(new ApiResponse<string>
//                {
//                    Message = "Reception not found",
//                    StatusCode = 404,
//                    Data = null,
//                    Timestamp = DateTime.UtcNow
//                });
//            }

//            await _receptionRepository.DeleteReceptionAsync(id);
//            return Ok(new ApiResponse<string>
//            {
//                Message = "Reception deleted successfully",
//                StatusCode = 200,
//                Data = "Reception successfully deleted",
//                Timestamp = DateTime.UtcNow
//            });
//        }
//    }

//}
