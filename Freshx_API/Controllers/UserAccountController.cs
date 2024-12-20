using AutoMapper;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.Reception;
using Freshx_API.Dtos.UserAccount;
using Freshx_API.Interfaces.UserAccount;
using Freshx_API.Models;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly ILogger<UserAccountController> _logger;
        private readonly IMapper _mapper;
        public UserAccountController(IUserAccountRepository userAccountRepository,IMapper mapper,ILogger<UserAccountController> logger)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
            _logger = logger;
        }
        //quản lý nhân viên 
        //quản lý thông tin tài khoản cá nhân
        [HttpPost("Create-NewUser")]
        public async Task<ActionResult<ApiResponse<UserResponse>>> CreateNewUser([FromForm]AddingUserRequest request)
        {
            try
            {
                var newUser = await _userAccountRepository.CreateUserAsync(request);
                if (newUser == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,ResponseFactory.Error<Object>(Request.Path,"Email is existed",StatusCodes.Status400BadRequest));
                }
                var data = _mapper.Map<AppUser,UserResponse>(newUser);
                return StatusCode(StatusCodes.Status200OK,ResponseFactory.Success(Request.Path,data));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An inception occured while creating a new User");
                return StatusCode(StatusCodes.Status500InternalServerError,ResponseFactory.Error<Object>(Request.Path, "An exception occured while creating a new user",StatusCodes.Status500InternalServerError));
            }
        }
        [HttpGet("Get-AllUsers")]
        public async Task<ActionResult<ApiResponse<Object>>> GetAllUsers([FromQuery]PaginationParameters parameters)
        {
            try
            {
                var users = await _userAccountRepository.GetUsersAsync(parameters);
                return StatusCode(StatusCodes.Status200OK,ResponseFactory.Success(Request.Path,users));
            }
            catch(Exception e)
            {
                _logger.LogError(e, "An exception occured while getting all users");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, "An exception occured while getting all users", StatusCodes.Status500InternalServerError));
            }
        }
        [HttpGet]
        [Route("profile")]
        public async Task<ActionResult<ApiResponse<UserResponse>>> GetUserByIdAsync()
        {
            try
            {
                var user = await _userAccountRepository.GetUserByIdAsync();
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory.Error<Object>(Request.Path,$"Get information not found", StatusCodes.Status404NotFound));
                }
                var data = _mapper.Map<AppUser,UserResponse>(user);
                return StatusCode(StatusCodes.Status200OK,ResponseFactory.Success(Request.Path,data));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpDelete]
        
        public async Task<ActionResult<ApiResponse<UserResponse>>> DeleteUserByid()
        {
            try
            {
                var user = await _userAccountRepository.GetUserByIdAsync();
                if(user == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory.Error<Object>(Request.Path, $"Lỗi khi xóa người dùng", StatusCodes.Status404NotFound));
                }
                return StatusCode(StatusCodes.Status200OK,ResponseFactory.Success<Object>(Request.Path,null,"User deleted success",StatusCodes.Status200OK));
            }
            catch(Exception e)
            {
                _logger.LogError(e, "An exception occured while deleting user");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, "an exception occured while deleting user"));
            }
        }

        [HttpPut]
        
        public async Task<ActionResult<ApiResponse<UserResponse>>> UpdateUserById(UpdatingUserRequest request)
        {
            try
            {
                var user = await _userAccountRepository.UpdateUserByIdAsync(request);
                if(user == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory.Error<UserResponse>(Request.Path, $"Lỗi khi lấy người dùng", StatusCodes.Status404NotFound));
                }
                var data = _mapper.Map<AppUser,UserResponse>(user);
                return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path, data));
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"An exception occured while updating user fail");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<Object>(Request.Path, $"Xảy ra lỗi khi cập nhật dữ liệu", StatusCodes.Status500InternalServerError));
            }
        } 
    }
}
