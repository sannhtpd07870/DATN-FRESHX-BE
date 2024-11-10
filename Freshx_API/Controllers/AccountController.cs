using AutoMapper;
using Azure;
using Freshx_API.Dtos.Auth.Account;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        public AccountController(IAccountRepository accountRepository, ILogger<AccountController> logger,IMapper mapper,ITokenRepository token)
        {
            _accountRepository = accountRepository;
            _logger = logger;
            _mapper = mapper;
            _tokenRepository = token;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<ApiResponse<RegisterResponse>>> CreateAccount(AddingRegister addingRegister)
        {
            try
            {
                var account = await _accountRepository.RegisterAccount(addingRegister);
                if (account == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory.Error<RegisterResponse>(Request.Path, "Email in existed", StatusCodes.Status400BadRequest));
                }
                var data = _mapper.Map<RegisterResponse>(account);
                return StatusCode(StatusCodes.Status200OK,ResponseFactory.Success(Request.Path,data,"A new account created successfully",StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exception occured while creating a new account");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<RegisterResponse>(Request.Path, "An exception occured while creating a new account", StatusCodes.Status500InternalServerError));
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult<ApiResponse<LoginResponse>>> LoginAccount(LoginRequest loginRequest)
        {
            try
            {
                var user = await _accountRepository.LoginAccount(loginRequest);
                if( user.Succeeded )
                {
                    return StatusCode(StatusCodes.Status200OK, ResponseFactory.Success(Request.Path, user, "Login successfully", StatusCodes.Status200OK));
                }
                if(user.IsLockedOut)
                {
                    return StatusCode(StatusCodes.Status423Locked, ResponseFactory.Error<LoginResponse>(Request.Path, user.Message, StatusCodes.Status423Locked));
                }              
                return StatusCode(StatusCodes.Status403Forbidden, ResponseFactory.Error<LoginResponse>(Request.Path,user.Message, StatusCodes.Status403Forbidden));                           
            }
            catch(Exception e)
            {
                _logger.LogError(e, "An exception occured while logining account");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory.Error<LoginResponse>(Request.Path, "An exception occured while logining account", StatusCodes.Status500InternalServerError));
            }
        }
    }
}
